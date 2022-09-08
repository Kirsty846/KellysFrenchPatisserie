<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Cart</h2>
        <p>Coming soon!</p>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Cart extends Vue {
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        created() {
        }    

    }
</script>

<style scoped>
</style>
