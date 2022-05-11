<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>Link data from API to Vue:</p>
        <p>{{data1}}</p>

        <p>Link data from SQL to Vue:</p>
        <p>{{data2}}</p>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        data1: string = '';
        data2: string = '';
        apiPath: string = 'https://localhost:7203'

        created() {
            this.data1 = 'hello1';
            this.data2 = 'hello2';
            this.getFromController();
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
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
