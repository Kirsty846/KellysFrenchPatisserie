<template>
    <div class="home">
        <h1>{{productType}}</h1>
        <b-button @click="showAddCelebrationCake">Add New {{productType}}</b-button>
        <b-table-simple>
            <b-thead>
                <b-tr>
                    <b-th>Name</b-th>
                    <b-th>Description</b-th>
                    <b-th>Price</b-th>
                    <b-th>Tiers</b-th>
                    <b-th>Icing Flavour</b-th>
                    <b-th>Flavour</b-th>
                    <b-th>Actions</b-th>
                </b-tr>
            </b-thead>
            <b-tbody>
                <b-tr v-for="(celebrationCake,i) in celebrationCakes" :key="i">
                    <b-td>{{ celebrationCake.name }}</b-td>
                    <b-td>{{ celebrationCake.description }}</b-td>
                    <b-td>${{ celebrationCake.price.toFixed(2) }}</b-td>
                    <b-td>{{ celebrationCake.tiers }}</b-td>
                    <b-td>{{ celebrationCake.icingFlavour }}</b-td>
                    <b-td>{{ celebrationCake.flavour.name }}</b-td>
                    <b-td>
                        <b-button @click="editCelebrationCake(celebrationCake)">Edit</b-button>
                        <b-button @click="$bvModal.show('deleteCelebrationCakeModal'),setCelebrationCake(celebrationCake)">Delete</b-button>
                    </b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>
        <div v-if="celebrationCakes.length == 0">
            No products
        </div>
        <b-modal hide-footer id="addEditCelebrationCakeModal">
            <template #modal-title>
                Add/Edit Celebration Cake
            </template>
            <div class="d-block text-center row">
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakeName">Name:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="celebrationCakeName" type="text" name="celebrationCakeName"
                                      v-validate="'required|max:250'"
                                      v-model="addEditCelebrationCake.name"
                                      data-vv-as="Celebration Cake Name">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('celebrationCakeName')">{{ errors.first('celebrationCakeName') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakeDescription">Description:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="celebrationCakeDescription" type="text" name="celebrationCakeDescription"
                                      v-validate="'required|max:250'"
                                      v-model="addEditCelebrationCake.description"
                                      data-vv-as="Celebration Cake Description">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('celebrationCakeDescription')">{{ errors.first('celebrationCakeDescription') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakePrice">Price(&#163):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="celebrationCakePrice" type="number" name="celebrationCakePrice"
                                           v-validate="'required'"
                                           v-model="addEditCelebrationCake.price"
                                           data-vv-as="Celebration Cake Price">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('celebrationCakePrice')">{{ errors.first('celebrationCakePrice') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakeTiers">Tiers:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="celebrationCakeTiers" type="number" name="celebrationCakeTiers"
                                      v-validate="'required'"
                                      v-model="addEditCelebrationCake.tiers"
                                      data-vv-as="Celebration Cake Tiers">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('celebrationCakeTiers')">{{ errors.first('celebrationCakeTiers') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakeIcingFlavour">Icing Flavour:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="celebrationCakeIcingFlavour" type="text" name="celebrationCakeIcingFlavour"
                                      v-validate="'required|max:250'"
                                      v-model="addEditCelebrationCake.icingFlavour"
                                      data-vv-as="Celebration Cake Icing Flavour">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('celebrationCakeIcingFlavour')">{{ errors.first('celebrationCakeIcingFlavour') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="celebrationCakeFlavour">Flavour:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-select class="form-select"
                                        id="celebrationCakeFlavour"
                                        name="celebrationCakeFlavour"
                                        v-validate="'required'"
                                        v-model="flavourMultiSelect.selectedItem"
                                        :options="flavourMultiSelect.options"
                                        @change="flavourMultiSelect_select"
                                        data-vv-as="Celebration Cake Flavour">
                        </b-form-select>
                        <div class="errorStyle" v-show="errors.has('celebrationCakeFlavour')">{{ errors.first('celebrationCakeFlavour') }}</div>
                    </b-col>
                </b-row>
            </div>
            <b-button @click="addNewCelebrationCake">Save</b-button>
            <b-button @click="$bvModal.hide('addEditCelebrationCakeModal')">Cancel</b-button>
        </b-modal>

        <b-modal hide-footer id="deleteCelebrationCakeModal">
            <template #modal-title>
                Delete Celebration Cake
            </template>
            <div class="d-block text-center">
                <h3>Are you sure you want to delete this celebration cake?</h3>
            </div>
            <b-button @click="deleteCelebrationCake">Yes</b-button>
            <b-button @click="$bvModal.hide('deleteCelebrationCakeModal')">Cancel</b-button>
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
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import CelebrationCakeModel from '../dataModels/celebrationCake';
    import FlavourModel from '../dataModels/flavour';
    import Multiselect from 'vue-multiselect'

    @Component({
        components: { Multiselect }
    })
    export default class CelebrationCake extends Vue {
        @Prop({ required: true }) productType!: string;
        celebrationCakes: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        addEditCelebrationCake: CelebrationCakeModel = new CelebrationCakeModel();
        flavourMultiSelect: any = {
            options: [],
            selectedItem: null
        };
        created() {
            this.getCelebrationCakes();
            this.getFlavourOptions();
        }    

        getCelebrationCakes() {
            var apiUrl = `${this.apiPath}/api/Products/celebrationCakes/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.celebrationCakes = event.body.result;
                }, (response) => {
                    this.errorMessage = 'Error loading products';
                });
        }

        async addNewCelebrationCake() {
            const validationPassed = await this.$validator.validateAll();
            if (validationPassed) {
                if (!this.addEditCelebrationCake.id) {
                    console.log(this.addEditCelebrationCake)
                    var apiUrl = `${this.apiPath}/api/Products/celebrationCake/`;
                    this.$http.post(apiUrl, this.addEditCelebrationCake)
                        .then((event: any) => {
                            this.getCelebrationCakes();
                            this.$bvModal.hide('addEditCelebrationCakeModal');
                            this.addEditCelebrationCake = new CelebrationCakeModel;
                        }, (response) => {
                            this.showError('Error adding new product', 'addEditCelebrationCakeModal');
                        });
                }
                else {
                    var apiUrl = `${this.apiPath}/api/Products/celebrationCake/`;
                    this.$http.put(apiUrl, this.addEditCelebrationCake)
                        .then((event: any) => {
                            this.getCelebrationCakes();
                            this.$bvModal.hide('addEditCelebrationCakeModal');
                            this.addEditCelebrationCake = new CelebrationCakeModel;
                        }, (response) => {
                            this.showError('Error editing product', 'addEditCelebrationCakeModal');
                        });             
                }
            }
        }

        editCelebrationCake(celebrationCake: CelebrationCake) {
            this.addEditCelebrationCake = JSON.parse(JSON.stringify(celebrationCake));
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditCelebrationCakeModal')
        }

        setCelebrationCake(celebrationCake: CelebrationCake) {
            this.addEditCelebrationCake = JSON.parse(JSON.stringify(celebrationCake));
        }

        deleteCelebrationCake() {
            var apiUrl = `${this.apiPath}/api/Products/celebrationCake/${this.addEditCelebrationCake.id}`;
            this.$http.delete(apiUrl)
                .then((event: any) => {
                    this.getCelebrationCakes();
                    this.$bvModal.hide('deleteCelebrationCakeModal');
                    this.addEditCelebrationCake = new CelebrationCakeModel;
                }, (response) => {
                    this.showError('Error deleting product', 'deleteCelebrationCakeModal');
                });
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
            this.addEditCelebrationCake = new CelebrationCakeModel;
        }

        public getFlavourOptions(): void {
            var apiUrl = `${this.apiPath}/api/Products/flavours`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.flavourMultiSelect.options = event.body.result;
                    this.populateFlavourSelectSelectedItem();
                }, (response) => {
                    this.showError('Error getting flavours', 'addEditCelebrationCakeModal');
                });
        }

        public flavourMultiSelect_select(item: any): void {
            this.addEditCelebrationCake.flavourId = item;
            this.addEditCelebrationCake.flavour.id = item;
        }

        public populateFlavourSelectSelectedItem(): void {
            if (this.addEditCelebrationCake.id != null && this.addEditCelebrationCake.flavour.id != null) {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options.find((item: any) => item.value == this.addEditCelebrationCake.flavour.id).value;
            }
            else {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options[0].value;
            }
        }

        public showAddCelebrationCake() {
            this.addEditCelebrationCake = new CelebrationCakeModel();
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditCelebrationCakeModal');
        }
    }
</script>

<style scoped>
    .errorStyle{
        color: red;
    }
    .moreVerticalSpacing{
        padding: 5px 0px;
    }
</style>
