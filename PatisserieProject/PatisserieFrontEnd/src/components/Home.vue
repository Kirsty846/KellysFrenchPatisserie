<template>
    <div class="home">
        <div v-if="showError" class="errorStyle">
            {{errorMessage}}
        </div>
        <h1>Kelly's French Patisserie</h1>
        <h2>Products</h2>
        <b-table-simple>
            <b-thead>
                <b-tr>
                    <b-th>Name</b-th>
                    <b-th>Description</b-th>
                    <b-th>Price</b-th>
                </b-tr>
            </b-thead>
            <b-tbody>
                <b-tr v-for="(product,i) in products" :key="i">
                    <b-td>{{ product.name }}</b-td>
                    <b-td>{{ product.description }}</b-td>
                    <b-td>${{ product.price.toFixed(2) }}</b-td>
                </b-tr>
            </b-tbody>
        </b-table-simple>

    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Product from '../dataModels/product';

    @Component
    export default class Home extends Vue {
        products: any = [];
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        showError: boolean = false;
        errorMessage: string = '';

        created() {
            this.getProducts();
        }

        getProducts() {
            this.showError = false;
            var apiUrl = `${this.apiPath}/api/Products/GetProduct/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.products = event.body.result;
                }, (response) => {
                    this.showError = true;
                    this.errorMessage = 'Error loading products';
                });
        }
    }
</script>

<style scoped>
    .errorStyle{
        color: red;
    }
</style>
