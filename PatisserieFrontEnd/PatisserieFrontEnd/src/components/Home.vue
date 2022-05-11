<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>Link data from API to Vue:</p>
        <p>{{data1}}</p>

        <p>Link data from SQL to Vue:</p>
        <p>{{data2}}</p>
        <p>{{data2.description}}</p>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Product from '../dataModels/product';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        data1: string = '';
        data2: any = [];
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
                    this.data2 = event.body[0];
                    this.data3 = event.body[0];
                }, (response) => {
                    this.data2 = 'error';
                });
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
