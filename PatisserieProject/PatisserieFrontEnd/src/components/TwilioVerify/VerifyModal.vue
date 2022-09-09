<template>
    <div>
    <b-modal hide-footer id="verifyModal">
        <template #modal-title>
            Add/Edit Celebration Cake
        </template>
        <div class="d-block text-center row">
            <b-row class="moreVerticalSpacing">
                <b-col>
                    <label for="phoneNumberId">Phone Number: +44</label>
                </b-col>
                <b-col cols="7">
                    <b-form-input id="phoneNumberId" type="text" name="phoneNumberName"
                                  v-validate="'required|min:10|max:11'"
                                  v-model="phoneNumber.phoneNumber"
                                  data-vv-as="Phone Number">
                    </b-form-input>
                    <div class="errorStyle" v-show="errors.has('phoneNumberName')">{{ errors.first('phoneNumberName') }}</div>
                </b-col>
            </b-row>
            <b-button v-if="isValidPhoneNumber"
                      @click="sendVerificationCode"
                      :disabled="verificationComplete">
                Send Verification Code
            </b-button>
            <div v-if="isValidPhoneNumber">SMS will be send to +44 {{phoneNumber.phoneNumber}}</div>
            <div v-if="codeSent">
                <b-form-input id="verificationCodeId" type="text" name="verificationCodeName"
                              v-validate="'required|min:6|max:6'"
                              :disabled="verificationComplete"
                              v-model="verificationCode"
                              data-vv-as="Verification Code">
                </b-form-input>
                <div class="errorStyle" v-show="errors.has('verificationCodeName')">{{ errors.first('verificationCodeName') }}</div>
                <b-button @click="verifyVerificationCode">
                    Verify Code
                </b-button>
                <div>
                    {{message}}
                </div>
            </div>
        </div>
    </b-modal>
    <b-modal hide-footer id="errorModal">
        <template #modal-title>
            Error
        </template>
        <div class="d-block text-center errorStyle">
            {{errorMessage}}
        </div>
        <b-button @click="$bvModal.hide('errorModal')">OK</b-button>
    </b-modal>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue, Watch } from 'vue-property-decorator';
    import VerificationModel from '../../dataModels/TwilioVerify/verificationModel';
    import PhoneNumberModel from '../../dataModels/TwilioVerify/phoneNumberModel';

    @Component
    export default class VerifyModal extends Vue {
        @Prop({ required: true }) showModal!: boolean;
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        phoneNumber: PhoneNumberModel = new PhoneNumberModel();
        codeSent: boolean = false;
        verificationComplete: boolean = false;
        verificationCode: string = "";
        message: string = "";
        created() {
        }

        @Watch("showModal", { immediate: true })
        onShowModalChange() {
            if (this.showModal == true) {
                this.$bvModal.show("verifyModal");
            }
        }

        get isValidPhoneNumber(): boolean {
            return this.phoneNumber.phoneNumber.length >= 10 && this.phoneNumber.phoneNumber.length <= 11;
        }

        public async sendVerificationCode(): Promise<void> {
            var apiUrl = `${this.apiPath}/api/Users/sendVerificationCode`;
            this.$http.post(apiUrl, this.phoneNumber)
                .then((event: any) => {
                    if (event.body == true) {
                        this.codeSent = true;
                    }
                    else {
                        this.showError('Error sending verification code', 'verifyModal');
                    }
                }, (response) => {
                    this.showError('Error sending verification code', 'verifyModal');
                });
        }

        public async verifyVerificationCode(): Promise<void> {
            let validated = await this.$validator.validateAll();
            if (validated) {
                var verificationObject = new VerificationModel();
                verificationObject.verificationCode = this.verificationCode;
                verificationObject.phoneNumber = this.phoneNumber.phoneNumber;
                var apiUrl = `${this.apiPath}/api/Users/verifyVerificationCode`;
                this.$http.post(apiUrl, verificationObject)
                    .then((event: any) => {
                        if (event.body == true) {
                            this.verificationComplete = true;
                            this.message = "Phone number is verified!"
                        }
                        else {
                            this.message = "Invalid code, try again."
                        }
                    }, (response) => {
                        this.showError('Error verifying verification code', 'verifyModal');
                    });
            }           
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
        }
    }
</script>

<style scoped>
</style>
