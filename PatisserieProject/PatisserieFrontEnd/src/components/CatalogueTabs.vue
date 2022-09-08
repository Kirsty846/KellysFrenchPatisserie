<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Products</h2>
        <b-tabs>
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
    import { Component, Vue } from 'vue-property-decorator';
    import CelebrationCake from './CelebrationCake.vue';
    import Fudge from './Fudge.vue';
    import MiniTart from './MiniTart.vue';
    import Macaroon from './Macaroon.vue';
    import Enum from '../utilities/enum';

    @Component({
        components: {
            CelebrationCake,
            Fudge,
            MiniTart,
            Macaroon,
        }
    })
    export default class CatalogueTabs extends Vue {
        tabs: any;

        constructor() {
            super();
            this.tabs = [
                { title: Enum.productTypes.celebrationCakes, content: 'celebration-cake', productType: Enum.productTypes.celebrationCakes, key: 1 },
                { title: Enum.productTypes.fudge, content: 'fudge', productType: Enum.productTypes.fudge, key: 2 },
                { title: Enum.productTypes.macaroons, content: 'macaroon', productType: Enum.productTypes.macaroons, key: 3 },
                { title: Enum.productTypes.miniTart, content: 'mini-tart', productType: Enum.productTypes.miniTart, key: 4 },
            ]
        }
    }
</script>

<style scoped>

</style>
