<template>
  <div class="create-note">
    <header>Creazione di una nuova nota</header>
    <section>
      <input type="text" v-model="note.title" />
      <input type="date" v-model="note.date" readonly />
      <textarea v-model="note.body" />
    </section>
    <footer>
      <button @click="saveNote">Salvease-outa</button>
      <button @click="discardNote">Annulla</button>
    </footer>
  </div>




</template>
<script lang="ts" src="./CreateNote.ts"></script>
<style scoped>
@import url('./CreateNote.css');
</style>