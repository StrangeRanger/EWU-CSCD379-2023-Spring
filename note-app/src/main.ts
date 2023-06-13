import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

// Vuetify.
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const themeInUse = localStorage.getItem('theme') || 'dark'
const vuetify = createVuetify({
  components,
  directives,
  icons: {
    defaultSet: 'mdi',
    sets: {
      mdi
    }
  },
  theme: {
    defaultTheme: themeInUse,
    themes: {
      dark: {
        colors: {}
      },
      light: {
        colors: {}
      }
    }
  }
})

const app = createApp(App)
app.use(vuetify)
app.use(CKEditor)
app.use(router)
app.mount('#app')
