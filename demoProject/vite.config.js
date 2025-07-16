import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
   dataServer:{
 Proxy:{
  'api/':{
    target:'http://bloodDonar:8080/',
    changeOrigin:true
  }
 }
  }
})