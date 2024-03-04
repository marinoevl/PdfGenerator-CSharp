<script setup lang="ts">
import {useRouter} from "vue-router";
import {onMounted, ref} from "vue";
import {getAllTemplate} from "@/services/template.api";
import type {ITemplate} from "@/models/ITemplate";
import moment from 'moment';

const router = useRouter();

const templates = ref<ITemplate[]>()

const buttomClick = () => {
  router.push({ name: 'template' })
}
const editTemplate = (template: ITemplate) => {
  router.push({ name: 'template', params: { id: template.id }})
}

onMounted(async () => {
  const {data} = await getAllTemplate()
  console.log(data)
  templates.value =data;

})
</script>

<template>
  <main class="w-75 mx-auto">    
    <h1 class="w-100 text-center">Templates</h1>
    <div>
      <table class="table">
        <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Date</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="template in templates" :key="template.name">
          <th scope="row" @click="editTemplate(template)">{{ template.id }}</th>
          <td>{{ template.name }}</td>
          <td>{{ moment(template.createdAt).format('DD/MM/yyyy HH:mm:ss a').toLocaleUpperCase('es-DO') }}</td>
        </tr>        
        </tbody>
      </table>
    </div>
    <div class="d-flex justify-content-center">
      <input type="button" class="btn btn-primary" text="Nuevo" @click="buttomClick" value="Nuevo">
    </div>
  </main>
</template>
