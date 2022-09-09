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
        <verifyModal :showModal="showVerifyModal"></verifyModal>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import VerifyModal from './TwilioVerify/VerifyModal.vue';

    @Component({
            components: {
                VerifyModal,
            }
        })
    export default class Home extends Vue {
        showVerifyModal = false;
        created() {
        }

        public openVerifyModal() {
            this.showVerifyModal = true;
        }
    }
</script>

<style scoped>

</style>
