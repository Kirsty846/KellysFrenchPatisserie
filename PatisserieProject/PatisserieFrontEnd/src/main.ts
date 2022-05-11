import Vue from 'vue';
import App from './App.vue';
import VueResource from 'vue-resource';
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'bootstrap/dist/css/bootstrap.css';

Vue.use(BootstrapVue);
Vue.use(VueResource);
Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
