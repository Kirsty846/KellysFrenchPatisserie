<template>
    <div>
        <b-tabs type="dark" variant="dark">
            <b-tab v-for="tab in tabs"
                   :name="tab.title"
                   :key="tab.title"
                   :title="tab.title">
                <span slot="label">{{tab.title}}</span>
                <div>
                    <component v-bind:is="tab.content"
                                :key="tab.key"></component>
                </div>
            </b-tab>
        </b-tabs>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Home from './components/Home.vue';
    import CatalogueTabs from './components/CatalogueTabs.vue';
    import ContactUs from './components/ContactUs.vue';
    import Cart from './components/Cart.vue';

    @Component({
        components: {
            Home,
            CatalogueTabs,
            ContactUs,
            Cart,
        }
    })
    export default class App extends Vue {
        tabs: any;

        constructor() {
            super();
            this.tabs = [
                { title: 'Kellys French Patisserie', content: 'home', key: 1 },
                { title: 'Catalogue', content: 'catalogue-tabs', key: 2 },
                { title: 'Contact Us', content: 'contact-us', key: 3, },
                { title: 'Cart', content: 'cart', key: 4 },
                /*{ title: 'Sign up', content: 'sign-up', key: 5 },*/               
            ]
        }
    }
</script>

<style>
</style>
