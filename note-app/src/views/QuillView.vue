<template>
  <!--<v-card style="max-width: 1280px;" id="quillEditor">-->
  <div>
    <v-text-field v-model="title" label="Title"></v-text-field>
  </div>
  <v-card style="height: 90%; max-width: 1280px" id="quillEditor" elevation="4">
    <QuillEditor v-model:content="text" v-bind="options" />
  </v-card>
  <br />
  <div class="text-center">
    <v-btn @click="saveNote()" elevation="4">Save</v-btn>
  </div>
</template>

<script setup lang="ts">
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import { ref } from 'vue'

const text = ref<string>('')
const title = ref<string>('')
let savedText = ''
const options = {
  toolbar: 'full',
  theme: 'snow'
}

function saveNote() {
  console.log(text.value)
  savedText = text.value
}

function setNote() {
  text.value = savedText
}
</script>
