<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Baking Owners: Kirsty and Kelly Jones</h2>
        <div class="row">
            <img :src="require('@/assets/BakingCoverPageImage.jpg')" style="width:400px;" />
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        created() {
        }    
    }
</script>

<style scoped>

</style>
