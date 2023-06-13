<template>
  <v-app>
    <v-app-bar class="py-1 px-6 toolbar" :elevation="3">
      <v-toolbar-title>
        <RouterLink to="/">
          <v-icon icon="mdi-book-open-page-variant" />
          Note App
        </RouterLink>
      </v-toolbar-title>

      <v-spacer />

      <v-btn>
        <span v-if="!signInService.isSignedIn" @click="signIn">Not signed in</span>
        <span v-else>{{ signInService.token.userName }}</span>
      </v-btn>

      <v-btn v-if="signInService.isSignedIn" @click="signInService.signOut()">Sign Out</v-btn>

      <ToggleTheme />

    </v-app-bar>

    <v-main>
      <SignInDialog v-model="showSignInDialog"></SignInDialog>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import ToggleTheme from '@/components/Header/ToggleTheme.vue'
import type { SignInService } from './scripts/signInService'
import { ref, inject } from 'vue'
import { Services } from './scripts/services'
import SignInDialog from './components/SignInDialog.vue'

const signInService = inject(Services.SignInService) as SignInService
const showSignInDialog = ref(false);

function signIn() {
  showSignInDialog.value = true;
}
</script>

<style scoped>
.toolbar {
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464;
  min-height: 65px;
}

.v-main {
  padding-top: 94px;
}
</style>
