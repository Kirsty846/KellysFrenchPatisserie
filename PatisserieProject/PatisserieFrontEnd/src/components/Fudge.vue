<template>
    <div class="home">
        <h1>{{productType}}</h1>
        <b-button @click="showAddFudge">Add New {{productType}}</b-button>
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
                <b-tr v-for="(fudge,i) in fudges" :key="i">
                    <b-td>{{ fudge.name }}</b-td>
                    <b-td>{{ fudge.description }}</b-td>
                    <b-td>${{ fudge.price.toFixed(2) }}</b-td>
                    <b-td>{{ fudge.size }} (cm<sup>2</sup>)</b-td>
                    <b-td>{{ fudge.flavour.name }}</b-td>
                    <b-td>
                        <b-button @click="editFudge(fudge)">Edit</b-button>
                        <b-button @click="$bvModal.show('deleteFudgeModal'),setFudge(fudge)">Delete</b-button>
                    </b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>
        <div v-if="fudges.length == 0">
            No products
        </div>
        <b-modal hide-footer id="addEditFudgeModal">
            <template #modal-title>
                Add/Edit Fudge
            </template>
            <div class="d-block text-center row">
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="fudgeName">Name:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="fudgeName" type="text" name="fudgeName"
                                      v-validate="'required|max:250'"
                                      v-model="addEditFudge.name"
                                      data-vv-as="Fudge Name">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('fudgeName')">{{ errors.first('fudgeName') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="fudgeDescription">Description:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="fudgeDescription" type="text" name="fudgeDescription"
                                      v-validate="'required|max:250'"
                                      v-model="addEditFudge.description"
                                      data-vv-as="Fudge Description">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('fudgeDescription')">{{ errors.first('fudgeDescription') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="fudgePrice">Price(&#163):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="fudgePrice" type="number" name="fudgePrice"
                                      v-validate="'required'"
                                      v-model="addEditFudge.price"
                                      data-vv-as="Fudge Price">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('fudgePrice')">{{ errors.first('fudgePrice') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="fudgeSize">Size(cm<sup>2</sup>):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="fudgeSize" type="number" name="fudgeSize"
                                      v-validate="'required'"
                                      v-model="addEditFudge.size"
                                      data-vv-as="Fudge Size">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('fudgeSize')">{{ errors.first('fudgeSize') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="fudgeFlavour">Flavour:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-select class="form-select"
                                       id="fudgeFlavour"
                                       name="fudgeFlavour"
                                       v-validate="'required'"
                                       v-model="flavourMultiSelect.selectedItem"
                                       :options="flavourMultiSelect.options"
                                       @change="flavourMultiSelect_select"
                                       data-vv-as="Fudge Flavour">
                        </b-form-select>
                        <div class="errorStyle" v-show="errors.has('fudgeFlavour')">{{ errors.first('fudgeFlavour') }}</div>
                    </b-col>
                </b-row>
            </div>
            <b-button @click="addNewFudge">Save</b-button>
            <b-button @click="$bvModal.hide('addEditFudgeModal')">Cancel</b-button>
        </b-modal>

        <b-modal hide-footer id="deleteFudgeModal">
            <template #modal-title>
                Delete Fudge
            </template>
            <div class="d-block text-center">
                <h3>Are you sure you want to delete this celebration cake?</h3>
            </div>
            <b-button @click="deleteFudge">Yes</b-button>
            <b-button @click="$bvModal.hide('deleteFudgeModal')">Cancel</b-button>
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
    import FudgeModel from '../dataModels/fudge';
    import Multiselect from 'vue-multiselect'

    @Component({
        components: { Multiselect }
    })
    export default class Fudge extends Vue {
        @Prop({ required: true }) productType!: string;
        fudges: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        addEditFudge: FudgeModel = new FudgeModel();
        flavourMultiSelect: any = {
            options: [],
            selectedItem: null
        };
        created() {
            this.getFudges();
            this.getFlavourOptions();
        }

        getFudges() {
            var apiUrl = `${this.apiPath}/api/Products/fudges/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.fudges = event.body.result;
                }, (response) => {
                    this.errorMessage = 'Error loading products';
                });
        }

        async addNewFudge() {
            const validationPassed = await this.$validator.validateAll();
            if (validationPassed) {
                if (!this.addEditFudge.id) {
                    var apiUrl = `${this.apiPath}/api/Products/fudge/`;
                    this.$http.post(apiUrl, this.addEditFudge)
                        .then((event: any) => {
                            this.getFudges();
                            this.$bvModal.hide('addEditFudgeModal');
                            this.addEditFudge = new FudgeModel;
                        }, (response) => {
                            this.showError('Error adding new product', 'addEditFudgeModal');
                        });
                }
                else {
                    var apiUrl = `${this.apiPath}/api/Products/fudge/`;
                    this.$http.put(apiUrl, this.addEditFudge)
                        .then((event: any) => {
                            this.getFudges();
                            this.$bvModal.hide('addEditFudgeModal');
                            this.addEditFudge = new FudgeModel;
                        }, (response) => {
                            this.showError('Error editing product', 'addEditFudgeModal');
                        });
                }
            }
        }

        editFudge(fudge: Fudge) {
            this.addEditFudge = JSON.parse(JSON.stringify(fudge));
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditFudgeModal')
        }

        setFudge(fudge: Fudge) {
            this.addEditFudge = JSON.parse(JSON.stringify(fudge));
        }

        deleteFudge() {
            var apiUrl = `${this.apiPath}/api/Products/fudge/${this.addEditFudge.id}`;
            this.$http.delete(apiUrl)
                .then((event: any) => {
                    this.getFudges();
                    this.$bvModal.hide('deleteFudgeModal');
                    this.addEditFudge = new FudgeModel;
                }, (response) => {
                    this.showError('Error deleting product', 'deleteFudgeModal');
                });
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
            this.addEditFudge = new FudgeModel;
        }

        public getFlavourOptions(): void {
            var apiUrl = `${this.apiPath}/api/Products/flavours`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.flavourMultiSelect.options = event.body.result;
                    this.populateFlavourSelectSelectedItem();
                    this.flavourMultiSelect_select(this.flavourMultiSelect.selectedItem);
                }, (response) => {
                    this.showError('Error getting flavours', 'addEditFudgeModal');
                });
        }

        public flavourMultiSelect_select(item: any): void {
            this.addEditFudge.flavourId = item;
            this.addEditFudge.flavour.id = item;
        }

        public populateFlavourSelectSelectedItem(): void {
            if (this.addEditFudge.id != null && this.addEditFudge.flavour.id != null) {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options.find((item: any) => item.value == this.addEditFudge.flavour.id).value;
            }
            else {
                this.flavourMultiSelect.selectedItem = this.flavourMultiSelect.options[0].value;
            }
            this.flavourMultiSelect_select(this.flavourMultiSelect.selectedItem);
        }

        public showAddFudge() {
            this.addEditFudge = new FudgeModel();
            this.populateFlavourSelectSelectedItem();
            this.$bvModal.show('addEditFudgeModal');
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
