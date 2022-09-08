<template>
    <div class="home">
        <h1>{{productType}}</h1>
        <b-button @click="showAddMacaroon">Add New {{productType}}</b-button>
        <b-table-simple>
            <b-thead>
                <b-tr>
                    <b-th>Name</b-th>
                    <b-th>Description</b-th>
                    <b-th>Price</b-th>
                    <b-th>Size</b-th>
                    <b-th>Flavour</b-th>
                    <b-th>Actions</b-th>
                </b-tr>
            </b-thead>
            <b-tbody>
                <b-tr v-for="(macaroon,i) in macaroons" :key="i">
                    <b-td>{{ macaroon.name }}</b-td>
                    <b-td>{{ macaroon.description }}</b-td>
                    <b-td>${{ macaroon.price.toFixed(2) }}</b-td>
                    <b-td>{{ macaroon.size }} (cm<sup>2</sup>)</b-td>
                    <b-td>{{ macaroon.flavour.name }}</b-td>
                    <b-td>
                        <b-button @click="editMacaroon(macaroon)">Edit</b-button>
                        <b-button @click="$bvModal.show('deleteMacaroonModal'),setMacaroon(macaroon)">Delete</b-button>
                    </b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>
        <div v-if="macaroons.length == 0">
            No products
        </div>
        <b-modal hide-footer id="addEditMacaroonModal">
            <template #modal-title>
                Add/Edit Macaroon
            </template>
            <div class="d-block text-center row">
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="macaroonName">Name:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="macaroonName" type="text" name="macaroonName"
                                      v-validate="'required|max:250'"
                                      v-model="addEditMacaroon.name"
                                      data-vv-as="Macaroon Name">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('macaroonName')">{{ errors.first('macaroonName') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="macaroonDescription">Description:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="macaroonDescription" type="text" name="macaroonDescription"
                                      v-validate="'required|max:250'"
                                      v-model="addEditMacaroon.description"
                                      data-vv-as="Macaroon Description">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('macaroonDescription')">{{ errors.first('macaroonDescription') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="macaroonPrice">Price(&#163):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="macaroonPrice" type="number" name="macaroonPrice"
                                      v-validate="'required'"
                                      v-model="addEditMacaroon.price"
                                      data-vv-as="Macaroon Price">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('macaroonPrice')">{{ errors.first('macaroonPrice') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="macaroonSize">Size(cm<sup>2</sup>):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="macaroonSize" type="number" name="macaroonSize"
                                      v-validate="'required'"
                                      v-model="addEditMacaroon.size"
                                      data-vv-as="Macaroon Size">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('macaroonSize')">{{ errors.first('macaroonSize') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="macaroonFlavour">Flavour:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-select class="form-select"
                                       id="macaroonFlavour"
                                       name="macaroonFlavour"
                                       v-validate="'required'"
                                       v-model="flavourMultiSelect.selectedItem"
                                       :options="flavourMultiSelect.options"
                                       @change="flavourMultiSelect_select"
                                       data-vv-as="Macaroon Flavour">
                        </b-form-select>
                        <div class="errorStyle" v-show="errors.has('macaroonFlavour')">{{ errors.first('macaroonFlavour') }}</div>
                    </b-col>
                </b-row>
            </div>
            <b-button @click="addNewMacaroon">Save</b-button>
            <b-button @click="$bvModal.hide('addEditMacaroonModal')">Cancel</b-button>
        </b-modal>

        <b-modal hide-footer id="deleteMacaroonModal">
            <template #modal-title>
                Delete Macaroon
            </template>
            <div class="d-block text-center">
                <h3>Are you sure you want to delete this celebration cake?</h3>
            </div>
            <b-button @click="deleteMacaroon">Yes</b-button>
            <b-button @click="$bvModal.hide('deleteMacaroonModal')">Cancel</b-button>
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
    import MacaroonModel from '../dataModels/macaroon';
    import Multiselect from 'vue-multiselect'

    @Component({
        components: { Multiselect }
    })
    export default class Macaroon extends Vue {
        @Prop({ required: true }) productType!: string;
        macaroons: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        addEditMacaroon: MacaroonModel = new MacaroonModel();
        flavourMultiSelect: any = {
            options: [],
            selectedItem: null
        };
        created() {
            this.getMacaroons();
            this.getFlavourOptions();
        }

        getMacaroons() {
            var apiUrl = `${this.apiPath}/api/Products/macaroons/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.macaroons = event.body.result;
                }, (response) => {
                    this.errorMessage = 'Error loading products';
                });
        }

        async addNewMacaroon() {
            const validationPassed = await this.$validator.validateAll();
            if (validationPassed) {
                if (!this.addEditMacaroon.id) {
                    var apiUrl = `${this.apiPath}/api/Products/macaroon/`;
                    this.$http.post(apiUrl, this.addEditMacaroon)
                        .then((event: any) => {
                            this.getMacaroons();
                            this.$bvModal.hide('addEditMacaroonModal');
                            this.addEditMacaroon = new MacaroonModel;
                        }, (response) => {
                            this.showError('Error adding new product', 'addEditMacaroonModal');
                        });
                }
                else {
                    var apiUrl = `${this.apiPath}/api/Products/macaroon/`;
                    this.$http.put(apiUrl, this.addEditMacaroon)
                        .then((event: any) => {
                            this.getMacaroons();
                            this.$bvModal.hide('addEditMacaroonModal');
                            this.addEditMacaroon = new MacaroonModel;
                        }, (response) => {
                            this.showError('Error editing product', 'addEditMacaroonModal');
                        });
                }
            }
        }

        editMacaroon(macaroon: Macaroon) {
            this.addEditMacaroon = JSON.parse(JSON.stringify(macaroon));
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditMacaroonModal')
        }

        setMacaroon(macaroon: Macaroon) {
            this.addEditMacaroon = JSON.parse(JSON.stringify(macaroon));
        }

        deleteMacaroon() {
            var apiUrl = `${this.apiPath}/api/Products/macaroon/${this.addEditMacaroon.id}`;
            this.$http.delete(apiUrl)
                .then((event: any) => {
                    this.getMacaroons();
                    this.$bvModal.hide('deleteMacaroonModal');
                    this.addEditMacaroon = new MacaroonModel;
                }, (response) => {
                    this.showError('Error deleting product', 'deleteMacaroonModal');
                });
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
            this.addEditMacaroon = new MacaroonModel;
        }

        public getFlavourOptions(): void {
            var apiUrl = `${this.apiPath}/api/Products/flavours`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.flavourMultiSelect.options = event.body.result;
                    this.populateFlavourSelectSelectedItem();
                    this.flavourMultiSelect_select(this.flavourMultiSelect.selectedItem);
                }, (response) => {
                    this.showError('Error getting flavours', 'addEditMacaroonModal');
                });
        }

        public flavourMultiSelect_select(item: any): void {
            this.addEditMacaroon.flavourId = item;
            this.addEditMacaroon.flavour.id = item;
        }

        public populateFlavourSelectSelectedItem(): void {
            if (this.addEditMacaroon.id != null && this.addEditMacaroon.flavour.id != null) {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options.find((item: any) => item.value == this.addEditMacaroon.flavour.id).value;
            }
            else {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options[0].value;
            }
            this.flavourMultiSelect_select(this.flavourMultiSelect.selectedItem);
        }

        public showAddMacaroon() {
            this.addEditMacaroon = new MacaroonModel();
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditMacaroonModal');
        }
    }
</script>

<style scoped>
    .errorStyle {
        color: red;
    }

    .moreVerticalSpacing {
        padding: 5px 0px;
    }
</style>
