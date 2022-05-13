<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Products</h2>
        <b-tabs type="dark" variant="dark">
            <b-tab v-for="tab in tabs"
                   :name="tab.title"
                   :key="tab.title"
                   :title="tab.title">
                <span slot="label">{{tab.title}}</span>
                <div>
                    <component v-bind:is="tab.content"
                               :key="tab.key"
                               :productType="tab.productType"></component>
                </div>
            </b-tab>
        </b-tabs>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Catalogue from './Catalogue.vue';
    import Enum from '../utilities/enum';

    @Component({
        components: {
            Catalogue,
        }
    })
    export default class CatalogueTabs extends Vue {
        tabs: any;

        constructor() {
            super();
            this.tabs = [
                { title: Enum.productTypes.celebrationCakes, content: 'catalogue', productType: Enum.productTypes.celebrationCakes, key: 1 },
                { title: Enum.productTypes.fudge, content: 'catalogue', productType: Enum.productTypes.fudge, key: 2 },
                { title: Enum.productTypes.macaroons, content: 'catalogue', productType: Enum.productTypes.macaroons, key: 3 },
                { title: Enum.productTypes.miniTart, content: 'catalogue', productType: Enum.productTypes.miniTart, key: 4 },
            ]
        }
    }
</script>

<style scoped>

</style>
