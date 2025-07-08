import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'
import Unimport from 'unimport/unplugin'

// https://vite.dev/config/
export default defineConfig({
  server:{
    
    proxy:{
      '/api':{
        target:'http://localhost:5206',
        changeOrigin:true,
        //rewrite:(path) => path.replace(/^\/api/,'')
      }
    }
  },
  plugins: [
    vue(),
    Unimport.vite({
      presets: ['vue', 'pinia'],
      addons: {
        vueTemplate: true,
      },
      imports: [
        {
          name: 'useNotification',
          from: 'notivue'          
        },
        
      ]
    })  
  ],
  
  resolve: {
    alias: {
      '@': path.resolve(__dirname, './src'),
      'stores': path.resolve(__dirname, './src/stores'),
    },
  },

 
})
