import Vue from 'vue';
import App from './App.vue';
import VueResource from 'vue-resource';
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'bootstrap/dist/css/bootstrap.css';
import VeeValidate from 'vee-validate';

Vue.use(BootstrapVue);
Vue.use(VueResource);
Vue.use(VeeValidate);
Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
