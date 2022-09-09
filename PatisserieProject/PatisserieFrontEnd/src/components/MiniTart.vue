<template>
    <div class="home">
        <h1>{{productType}}</h1>
        <b-button @click="showAddMiniTart">Add New {{productType}}</b-button>
        <b-table-simple>
            <b-thead>
                <b-tr>
                    <b-th>Name</b-th>
                    <b-th>Description</b-th>
                    <b-th>Price</b-th>
                    <b-th>Type</b-th>
                    <b-th>Actions</b-th>
                </b-tr>
            </b-thead>
            <b-tbody>
                <b-tr v-for="(miniTart,i) in miniTarts" :key="i">
                    <b-td>{{ miniTart.name }}</b-td>
                    <b-td>{{ miniTart.description }}</b-td>
                    <b-td>${{ miniTart.price.toFixed(2) }}</b-td>
                    <b-td>{{ miniTart.type }}</b-td>
                    <b-td>
                        <b-button @click="editMiniTart(miniTart)">Edit</b-button>
                        <b-button @click="$bvModal.show('deleteMiniTartModal'),setMiniTart(miniTart)">Delete</b-button>
                    </b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>
        <div v-if="miniTarts.length == 0">
            No products
        </div>
        <b-modal hide-footer id="addEditMiniTartModal">
            <template #modal-title>
                Add/Edit MiniTart
            </template>
            <div class="d-block text-center row">
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="miniTartName">Name:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="miniTartName" type="text" name="miniTartName"
                                      v-validate="'required|max:250'"
                                      v-model="addEditMiniTart.name"
                                      data-vv-as="MiniTart Name">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('miniTartName')">{{ errors.first('miniTartName') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="miniTartDescription">Description:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="miniTartDescription" type="text" name="miniTartDescription"
                                      v-validate="'required|max:250'"
                                      v-model="addEditMiniTart.description"
                                      data-vv-as="MiniTart Description">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('miniTartDescription')">{{ errors.first('miniTartDescription') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="miniTartPrice">Price(&#163):</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="miniTartPrice" type="number" name="miniTartPrice"
                                      v-validate="'required'"
                                      v-model="addEditMiniTart.price"
                                      data-vv-as="MiniTart Price">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('miniTartPrice')">{{ errors.first('miniTartPrice') }}</div>
                    </b-col>
                </b-row>
                <b-row class="moreVerticalSpacing">
                    <b-col>
                        <label for="miniTartType">Type:</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="miniTartType" type="text" name="miniTartType"
                                      v-validate="'required'"
                                      v-model="addEditMiniTart.type"
                                      data-vv-as="MiniTart Type">
                        </b-form-input>
                        <div class="errorStyle" v-show="errors.has('miniTartType')">{{ errors.first('miniTartType') }}</div>
                    </b-col>
                </b-row>               
            </div>
            <b-button @click="addNewMiniTart">Save</b-button>
            <b-button @click="$bvModal.hide('addEditMiniTartModal')">Cancel</b-button>
        </b-modal>

        <b-modal hide-footer id="deleteMiniTartModal">
            <template #modal-title>
                Delete MiniTart
            </template>
            <div class="d-block text-center">
                <h3>Are you sure you want to delete this celebration cake?</h3>
            </div>
            <b-button @click="deleteMiniTart">Yes</b-button>
            <b-button @click="$bvModal.hide('deleteMiniTartModal')">Cancel</b-button>
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
    import MiniTartModel from '../dataModels/miniTart';
    import Multiselect from 'vue-multiselect'

    @Component({
        components: { Multiselect }
    })
    export default class MiniTart extends Vue {
        @Prop({ required: true }) productType!: string;
        miniTarts: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        addEditMiniTart: MiniTartModel = new MiniTartModel();       
        created() {
            this.getMiniTarts();
        }

        getMiniTarts() {
            var apiUrl = `${this.apiPath}/api/Products/miniTarts/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.miniTarts = event.body;
                }, (response) => {
                    this.errorMessage = 'Error loading products';
                });
        }

        async addNewMiniTart() {
            const validationPassed = await this.$validator.validateAll();
            if (validationPassed) {
                if (!this.addEditMiniTart.id) {
                    var apiUrl = `${this.apiPath}/api/Products/miniTart/`;
                    this.$http.post(apiUrl, this.addEditMiniTart)
                        .then((event: any) => {
                            this.getMiniTarts();
                            this.$bvModal.hide('addEditMiniTartModal');
                            this.addEditMiniTart = new MiniTartModel;
                        }, (response) => {
                            this.showError('Error adding new product', 'addEditMiniTartModal');
                        });
                }
                else {
                    var apiUrl = `${this.apiPath}/api/Products/miniTart/`;
                    this.$http.put(apiUrl, this.addEditMiniTart)
                        .then((event: any) => {
                            this.getMiniTarts();
                            this.$bvModal.hide('addEditMiniTartModal');
                            this.addEditMiniTart = new MiniTartModel;
                        }, (response) => {
                            this.showError('Error editing product', 'addEditMiniTartModal');
                        });
                }
            }
        }

        editMiniTart(miniTart: MiniTart) {
            this.addEditMiniTart = JSON.parse(JSON.stringify(miniTart));
            this.$bvModal.show('addEditMiniTartModal')
        }

        setMiniTart(miniTart: MiniTart) {
            this.addEditMiniTart = JSON.parse(JSON.stringify(miniTart));
        }

        deleteMiniTart() {
            var apiUrl = `${this.apiPath}/api/Products/miniTart/${this.addEditMiniTart.id}`;
            this.$http.delete(apiUrl)
                .then((event: any) => {
                    this.getMiniTarts();
                    this.$bvModal.hide('deleteMiniTartModal');
                    this.addEditMiniTart = new MiniTartModel;
                }, (response) => {
                    this.showError('Error deleting product', 'deleteMiniTartModal');
                });
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
            this.addEditMiniTart = new MiniTartModel;
        }

        public showAddMiniTart() {
            this.addEditMiniTart = new MiniTartModel();
            this.$bvModal.show('addEditMiniTartModal');
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
