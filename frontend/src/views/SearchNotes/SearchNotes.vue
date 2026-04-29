<template>
  <div class="search">
    <header>
      <input v-model="searchText">
    </header>
    <section>

      <Note v-for="note in foundNotes?.items" :key="note.id.toString()" :note="note" paolo="ok" />

      <!-- <div class="note" v-for="note in foundNotes?.items" :key="note.id.toString()">
        <h3>{{ note.title }}</h3>
        <p>{{ note.body }}</p>
      </div> -->


    </section>
  </div>
</template>
<script lang="ts" src="./SearchNotes.ts"></script>
<style scoped>
@import url(./SearchNotes.css);
</style>