<template>
    <div class="home">
        <h1>Kelly's French Patisserie</h1>
        <h2>Baking Owners: Kirsty and Kelly Jones</h2>
        <div class="row">
            <img :src="require('@/assets/BakingCoverPageImage.jpg')" style="width:400px;" />
        </div>
        <div>
            <p>Twilio integration</p>
            <b-button @click="openVerifyModal">
                Verify your Phone Number
            </b-button>
        </div>
        <verifyModal></verifyModal>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import VerifyModal from 
    @Component({
            components: {
                VerifyModal,
            }
        })
    export default class Home extends Vue {
        created() {
        }

        public openVerifyModal() {


        }
    }
</script>

<style scoped>

</style>
