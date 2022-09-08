<template>
    <b-modal hide-footer id="verifyModal">
        <template #modal-title>
            Add/Edit Celebration Cake
        </template>
        <div class="d-block text-center row">
            <b-row class="moreVerticalSpacing">
                <b-col>
                    <label for="phoneNumberId">Phone Number: +44</label>
                </b-col>
                <b-col cols="8">
                    <b-form-input id="phoneNumberId" type="text" name="phoneNumberName"
                                  v-validate="'required|min:10|max:11'"
                                  v-model="phoneNumber"
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
            <div>SMS will be send to +44 {{phoneNumber}}</div>
            <div v-if="codeSent">
                <b-form-input id="verificationCodeId" type="text" name="verificationCodeName"
                              v-validate="'required|min:6|max:6'"
                              :disabled="verificationComplete"
                              v-model="verificationCode"
                              data-vv-as="Verification Code">
                </b-form-input>
                <div class="errorStyle" v-show="errors.has('verificationCodeName')">{{ errors.first('verificationCodeName') }}</div>
                <b-button v-if="isValidPhoneNumber">
                    Send Verification Code
                </b-button>
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
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';

    @Component
    export default class VerifyModal extends Vue {
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        phoneNumber: string = '';
        codeSent: boolean = false;
        verificationComplete: boolean = false;
        twilioServiceId: string = "";
        created() {
        }

        public async isValidPhoneNumber(): Promise<boolean> {
            return await this.$validator.validateAll();
        }

        public async sendVerificationCode(): Promise<void> {
            var apiUrl = `${this.apiPath}/api/Users/sendVerificationCode`, phoneNumber;
            this.$http.post(apiUrl)
                .then((event: any) => {
                }, (response) => {
                    this.twilioServiceId = response.body;
                    this.showError('Error adding new product', 'verifyModal');
                });
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
