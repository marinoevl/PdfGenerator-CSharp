import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.js';
import 'sweetalert2/dist/sweetalert2.min.css';
import 'vue3-loading-overlay/dist/vue3-loading-overlay.css';
import "vue-wysiwyg/dist/vueWysiwyg.css";

const app = createApp(App)

app.component('QuillEditor', QuillEditor)

app.use(createPinia())
app.use(router)

app.mount('#app')
