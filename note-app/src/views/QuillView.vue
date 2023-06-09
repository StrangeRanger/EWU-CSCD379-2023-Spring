<template>
  <!--<v-card style="max-width: 1280px;" id="quillEditor">-->
  <v-card style="height: 90%; max-width: 1280px" id="quillEditor" elevation="4">
    <QuillEditor v-model:content="text" v-bind="options" />
  </v-card>
  <br />
  <div class="text-center">
    <v-btn @click="getNote()" elevation="4">Save</v-btn>
    <v-btn @click="setNote()" elevation="4">Edit</v-btn>
  </div>
</template>

<script setup lang="ts">
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import { ref } from 'vue'

let text = ref<string>('')
let savedText = ''
const options = {
  toolbar: 'full',
  theme: 'snow'
}

function getNote() {
  console.log(text.value)
  savedText = text.value
}

function setNote() {
  text.value = savedText
}
</script>
