<script setup lang="ts">
import {computed, onMounted, ref} from "vue";
import {useRoute, useRouter} from "vue-router";
import {createTemplate, getTemplateById, updateTemplate} from "@/services/template.api";
import type {ITemplate} from "@/models/ITemplate";

const router = useRouter()
const route = useRoute()

const id = ref<string>()
const name = ref<string>()
const content = ref<string>()


const submitTemplate = async () => {
  const contentToSubmit = btoa(`<!DOCTYPE html>
<html>
<head>
<title>Carta de Solicitud</title>
</head>
<body>${content.value}</body>
</html>`)
  
  if (id){
    await updateTemplate(id.value!.toString(), contentToSubmit)
  } else {
    await createTemplate(name.value!.toString(), contentToSubmit)
  }  
  router.push({name: 'home'})
}

onMounted(async () => {
  if (route.params.id) {
    const {data}: { data: ITemplate } = await getTemplateById(route.params?.id.toString())
    id.value = data.id
    name.value = data.name
    content.value =  atob(data.content);
  }
})

const isNew = computed(() => !!id)


</script>
<template>
  <div class="w-100">
    <h1>Plantilla</h1>
  </div>
  <div class="m-2 text-start">
    <input v-if="isNew" type="text" v-model="name" placeholder="Name">
    <span v-else class="fw-semibold">{{ name }}</span>
  </div>
  <div>
    <QuillEditor theme="snow" v-model:content="content" content-type="html" placeholder="Content"/>
  </div>
  <div class="d-flex justify-content-center m-2">
    <input class="btn btn-primary" type="button" value="Save" @click="submitTemplate"/>
  </div>
</template>

<style>

</style>
