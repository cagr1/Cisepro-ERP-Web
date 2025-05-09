import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'

// https://vite.dev/config/
export default defineConfig({
  server:{
    open: 'Brave',
    proxy:{
      '/api':{
        target:'http://localhost:5206',
        changeOrigin:true,
        //rewrite:(path) => path.replace(/^\/api/,'')
      }
    }
  },
  plugins: [vue()],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, './src'),
      'stores': path.resolve(__dirname, './src/stores'),
    },
  },
})
