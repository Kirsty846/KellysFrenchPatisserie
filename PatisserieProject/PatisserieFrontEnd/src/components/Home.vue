<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Products</h2>
        <b-button @click="$bvModal.show('addEditProductModal')">Add New Product</b-button>
        <b-table-simple>
            <b-thead>
                <b-tr>
                    <b-th>Name</b-th>
                    <b-th>Description</b-th>
                    <b-th>Price</b-th>
                    <b-th>Actions</b-th>
                </b-tr>
            </b-thead>
            <b-tbody>
                <b-tr v-for="(product,i) in products" :key="i">
                    <b-td>{{ product.name }}</b-td>
                    <b-td>{{ product.description }}</b-td>
                    <b-td>${{ product.price.toFixed(2) }}</b-td>
                    <b-td>
                        <b-button @click="editProduct(product)">Edit</b-button>
                        <b-button @click="$bvModal.show('deleteProductModal'),setProduct(product)">Delete</b-button>
                    </b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>
        <b-modal hide-footer id="addEditProductModal">
            <template #modal-title>
                Add/Edit Product
            </template>
            <div class="d-block text-center">
                <label for="productName">Name</label>
                <div>
                    <input id="productName" type="text" name="productName"
                           v-validate="'required|max:250'"
                           v-model="addEditProduct.name"
                           data-vv-as="Product Name" />
                    <div class="errorStyle" v-show="errors.has('productName')">{{ errors.first('productName') }}</div>
                </div>
                <label for="productDescription">Description</label>
                <div>
                    <input id="productDescription" type="text" name="productDescription"
                           v-validate="'required|max:250'"
                           v-model="addEditProduct.description"
                           data-vv-as="Product Description" />
                    <div class="errorStyle" v-show="errors.has('productDescription')">{{ errors.first('productDescription') }}</div>
                </div>
                <label for="productPrice">Price</label>
                <div>
                    <input id="productPrice" type="number" name="productPrice"
                           v-validate="'required'"
                           v-model="addEditProduct.price"
                           data-vv-as="Product Price" />
                    <div class="errorStyle" v-show="errors.has('productPrice')">{{ errors.first('productPrice') }}</div>
                </div>
            </div>
            <b-button @click="addNewProduct">Save</b-button>
            <b-button @click="$bvModal.hide('addEditProductModal')">Cancel</b-button>
        </b-modal>

        <b-modal hide-footer id="deleteProductModal">
            <template #modal-title>
                Delete Product
            </template>
            <div class="d-block text-center">
                <h3>Are you sure you want to delete this product?</h3>
            </div>
            <b-button @click="deleteProduct">Yes</b-button>
            <b-button @click="$bvModal.hide('deleteProductModal')">Cancel</b-button>
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
    import Product from '../dataModels/product';

    @Component
    export default class Home extends Vue {
        products: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        addEditProduct: Product = new Product();
        created() {
            this.getProducts();
        }    

        getProducts() {
            var apiUrl = `${this.apiPath}/api/Products/GetProducts/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.products = event.body.result;
                }, (response) => {
                    this.errorMessage = 'Error loading products';
                });
        }

        async addNewProduct() {
            const validationPassed = await this.$validator.validateAll();
            if (validationPassed) {
                if (!this.addEditProduct.id) {
                    var apiUrl = `${this.apiPath}/api/Products/AddProduct/`;
                    this.$http.post(apiUrl, this.addEditProduct)
                        .then((event: any) => {
                            this.getProducts();
                            this.$bvModal.hide('addEditProductModal');
                            this.addEditProduct = new Product;
                        }, (response) => {
                            this.showError('Error adding new product', 'addEditProductModal');
                        });
                }
                else {
                    var apiUrl = `${this.apiPath}/api/Products/EditProduct/`;
                    this.$http.put(apiUrl, this.addEditProduct)
                        .then((event: any) => {
                            this.getProducts();
                            this.$bvModal.hide('addEditProductModal');
                            this.addEditProduct = new Product;
                        }, (response) => {
                            this.showError('Error editing product', 'addEditProductModal');
                        });             
                }
            }
        }

        editProduct(product: Product) {
            this.addEditProduct = JSON.parse(JSON.stringify(product));
            this.$bvModal.show('addEditProductModal')
        }

        setProduct(product: Product) {
            this.addEditProduct = JSON.parse(JSON.stringify(product));
        }

        deleteProduct() {
            var apiUrl = `${this.apiPath}/api/Products/DeleteProduct/${this.addEditProduct.id}`;
            this.$http.delete(apiUrl)
                .then((event: any) => {
                    this.getProducts();
                    this.$bvModal.hide('deleteProductModal');
                    this.addEditProduct = new Product;
                }, (response) => {
                    this.showError('Error deleting product', 'deleteProductModal');
                });
        }

        showError(errorMessage: string, closeModal: string) {
            this.$bvModal.show('errorModal');
            this.$bvModal.hide(closeModal);
            this.errorMessage = errorMessage;
            this.addEditProduct = new Product;
        }

    }
</script>

<style scoped>
    .errorStyle{
        color: red;
    }

</style>
