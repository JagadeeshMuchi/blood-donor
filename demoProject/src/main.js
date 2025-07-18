import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router  from './Router'
import PrimeVue from 'primevue/config';
import Aura from '@primeuix/themes/aura';
          
import 'primeicons/primeicons.css'       
import 'primeflex/primeflex.css'
import RadioButton  from "primevue/radiobutton";   
import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import Checkbox from 'primevue/checkbox'


export let  app=createApp(App)
app.use(PrimeVue, {
    theme: {
        preset: Aura
    }
});
app.component('InputText', InputText)
app.component('RadioButton', RadioButton)
app.component('Checkbox', Checkbox)
app.component('Button', Button);
app.use(router);

app.mount('#app')
