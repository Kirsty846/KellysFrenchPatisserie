<template>
    <div>
        <div>
            <b-navbar type="dark" variant="dark">
                <b-navbar-nav>
                    <b-nav-item href="#">Kelly's French Patisserie</b-nav-item>

                    <b-nav-item-dropdown text="Products" right>
                        <b-dropdown-item href="#">Cake</b-dropdown-item>
                        <b-dropdown-item href="#">Cup Cakes</b-dropdown-item>
                    </b-nav-item-dropdown>

                    <b-nav-item>Contact Us</b-nav-item>
                </b-navbar-nav>
            </b-navbar>
        </div>
        <div id="app">
            <div style="padding:25px">
                <Home/>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Home from './components/Home.vue';

    @Component({
        components: {
            Home
        }
    })
    export default class App extends Vue { }
</script>

<style>
</style>
