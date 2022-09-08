<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Contact Us</h2>
        <div class="row">
            <b-card title="Phone:"
                    img-src="https://picsum.photos/600/300/?image=25"
                    img-alt="Image"
                    img-top
                    tag="article"
                    style="max-width: 20rem;"
                    class="mb-2">
                <b-card-text>
                    +44 88 99 34 5560
                </b-card-text>
            </b-card>
            <b-card title="Email:"
                    img-src="https://picsum.photos/600/300/?image=25"
                    img-alt="Image"
                    img-top
                    tag="article"
                    style="max-width: 20rem;"
                    class="mb-2">
                <b-card-text>
                    Baking@test.com
                </b-card-text>
            </b-card>
            <b-card title="Location:"
                    img-src="https://picsum.photos/600/300/?image=25"
                    img-alt="Image"
                    img-top
                    tag="article"
                    style="max-width: 20rem;"
                    class="mb-2">
                <b-card-text>
                    <p style="margin:0px">33 Baking Street, </p>
                    <p style="margin:0px">London, </p>
                    <p style="margin:0px">LD4 5TG </p>
                </b-card-text>
            </b-card>
        </div>
        
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';

    @Component
    export default class ContactUs extends Vue {
        apiPath: string = 'https://localhost:7203' //there is a better place for this
        errorMessage: string = '';
        created() {
        }    
    }
</script>

<style scoped>
</style>
