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

      <ToggleTheme />
    </v-app-bar>

    <v-spacer />

    <v-main>
      <RouterView />
    </v-main>

    <v-spacer />
  </v-app>
</template>

<script setup lang="ts">
import ToggleTheme from '@/components/Header/ToggleTheme.vue'
</script>

<style scoped>
.toolbar {
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464;
  min-height: 65px;
}
</style>
