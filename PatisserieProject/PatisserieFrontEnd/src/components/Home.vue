<template>
    <div class="home">
        <h1>Kellys French Patisserie</h1>
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
                    <b-td>{{ product.description}}</b-td>
                    <b-td>${{ product.price.toFixed(2)}}</b-td>
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
        @Prop() private msg!: string;
        data1: string = '';
        products: any = [];
        data3: Product = new Product;
        apiPath: string = 'https://localhost:7203' //there is a better place for this

        created() {
            this.getFromController();
            this.getFromController2()
        }

        getFromController() {
            var apiUrl = `${this.apiPath}/api/Products/GetProduct/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    this.data1 = event.body;
                }, (response) => {
                    this.data1 = 'error';
                });
        }

        getFromController2() {
            var apiUrl = `${this.apiPath}/api/Products/GetSqlProduct/`;
            this.$http.get(apiUrl)
                .then((event: any) => {
                    console.log(event.body)
                    console.log(event.body.result)
                    this.products = event.body.result;
                    this.data3 = event.body.result[0];
                }, (response) => {
                    this.products = 'error';
                });
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
