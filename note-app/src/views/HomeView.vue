<template>
  <v-sheet
    class="d-flex align-center justify-center flex-wrap text-center mx-auto pa-10"
    elevation="1"
    height="250px"
    max-width="980px"
    width="100%"
    rounded
  >
    <h1>Welcome To Note App!</h1>
    <v-container fluid>
      <v-row>
        <v-col cols="6">
          <v-card class="card-button" to="/quill" elevation="6" variant="outlined">
            <v-card-title class="justify-center">New Note</v-card-title>
          </v-card>
        </v-col>
        <v-col cols="6">
          <v-card class="card-button" to="/mynotes" elevation="6" variant="outlined">
            <v-card-title class="justify-center">My Notes</v-card-title>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>
