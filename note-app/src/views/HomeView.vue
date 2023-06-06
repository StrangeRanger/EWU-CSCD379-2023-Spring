<template>
  <!-- TODO: Change min width of v-responsive. -->
  <v-responsive min-width="300px">
    <v-card>
      <v-card-title class="justify-center">Thing for thing......</v-card-title>
      <v-card-item>
        <v-card-text>
          CKEditor is a WYSIWYG rich text editor which enables writing content directly inside of
          Vue components.
        </v-card-text>
        <v-card-actions class="justify-center">
          <v-btn to="/ckeditor" variant="tonal" rounded="xl" elevation="6">CKEditor</v-btn>
        </v-card-actions>
      </v-card-item>

      <v-card-item>
        <v-card-text> CKEditor is another options........... </v-card-text>
        <v-card-actions class="justify-center">
          <v-btn to="/quill" variant="tonal" rounded="xl" elevation="6">Vue Quill</v-btn>
        </v-card-actions>
      </v-card-item>
    </v-card>
  </v-responsive>
</template>
