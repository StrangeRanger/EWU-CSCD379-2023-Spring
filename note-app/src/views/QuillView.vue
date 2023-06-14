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
import { NoteHelper } from '@/scripts/helpers/noteHelper';
import { SignInService } from '@/scripts/services/signInService';
import { Services } from '@/scripts/services/services';
import Axios from 'axios'

const text = ref<string>('')
const title = ref<string>('')
const note = ref<NoteHelper>(new NoteHelper())
const signInService = inject(Services.SignInService) as SignInService

let id = ''
Axios.get('/User/GetUser?username=' + signInService.token.userName + '@noteapp.com').then(response => id = response.data)

const options = {
  toolbar: 'full',
  theme: 'snow'
}

function saveNote() {
  console.log(id)
  console.log(title.value)
  console.log(text.value)
    note.value.title = title.value
    note.value.content = text.value
    note.value.appUserID = id
    Axios.post('/Note/CreateOrEditNote', note.value)
    //.then( () => {
      //Make dialog that says the note was successfully saved.
    //})
  
    //Make Dialog pop up saying the title cant be empty
  
  
}
</script>
