import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

import { createApp, reactive } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

// Vuetify.
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { Services } from './scripts/services/services'
import { SignInService } from './scripts/services/signInService'

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

const signInService = reactive(SignInService.instance)
app.provide(Services.SignInService, signInService)

app.use(vuetify)
app.use(router)
app.mount('#app')
