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
import { inject, ref } from 'vue'
import { Note } from '@/scripts/models/note'
import { SignInService } from '@/scripts/services/signInService'
import { Services } from '@/scripts/services/services'
import Axios from 'axios'
import router from "@/router";

const signInService = inject(Services.SignInService) as SignInService

let id = ''
let text = ref<string>('')
let title = ref<string>('')
let note = ref<Note>(new Note())

// TODO: Modify so we don't hardcode the email address...
Axios.get('User?username=' + signInService.token.userName + '@noteapp.com').then(
  (response) => (id = response.data)
)

const options = {
  toolbar: 'full',
  theme: 'snow'
}

console.log(router.currentRoute.value.params.text)


function saveNote() {
  if (title.value == null || title.value == '') {
    title.value = 'Untitled'
  }

  note.value.title = title.value
  note.value.content = JSON.stringify(text.value)
  note.value.appUserID = id
  // TODO: Modify console log of response...
  Axios.post('/Note/CreateOrEditNote', note.value).then((response) => {
    console.log(response)
  })
}
</script>
