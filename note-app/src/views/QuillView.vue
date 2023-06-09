<template>
  <div>
    <QuillEditor v-model:content="text" theme="snow" toolbar="full" />
  </div>
  <v-btn @click="getNote()">Save</v-btn>
  <v-btn @click="setNote()">Edit</v-btn>
</template>

<script setup lang="ts">
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import { ref } from 'vue';

let text = ref<string>('')
let savedText = ''

function getNote() {
  console.log(text.value)
  savedText = text.value
}

function setNote() {
  text.value = savedText
}
</script>
