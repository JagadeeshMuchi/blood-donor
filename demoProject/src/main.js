import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router  from './Router'
import PrimeVue from 'primevue/config'
//import 'primevue/resources/themes/lara-light-blue/theme.css'  // or any other theme
//import 'primevue/resources/primevue.min.css'                   // core styles
import 'primeicons/primeicons.css'                             // icons
import 'primeflex/primeflex.css'    
import RadioButton  from "primevue/radiobutton";   


export let app=createApp(App)
app.component('RadioButton', RadioButton);
app.use(router);
app.use(PrimeVue, { ripple: true, inputStyle: 'filled' });
app.mount('#app')
