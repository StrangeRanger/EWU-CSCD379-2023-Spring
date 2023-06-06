import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import CKEditorView from '@/views/CKEditorView.vue'
import QuillView from '@/views/QuillView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/ckeditor',
      name: 'ckeditor',
      component: CKEditorView
    },
    {
      path: '/quill',
      name: 'quill',
      component: QuillView
    }
  ]
})

export default router
