/** @type {import('tailwindcss').Config} */


export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
      ],
  important: true,
  corePlugins: {
    preflight: true,
  },
  theme: {
    extend: {
      colors: {
        primary:{
          50: '#f0f9ff',
          100: '#e0f2fe',
          200: '#bae6fd',
          300: '#7dd3fc',
          400: '#38bdf8',
          500: '#30a9f6',
          600: '#2563eb',
          700: '#0369a1',
          800: '#075985',
          900: '#0c4a6e',
        },
        boxshadow: {
          checkbox: '0 1px 2px 0 rgba(0, 0, 0, 0.05)',
        'checkbox-focus': '0 0 0 3px rgba(59, 130, 246, 0.5)'
      },
        
        checkbox: {
          DEFAULT: '#2563eb', // blue-600
          checked: '#2563eb', // blue-600
          border: '#d1d5db', // gray-300
          focus: '#3b82f6', // blue-500
        }
      }
    },
  },
  plugins: [],
}

