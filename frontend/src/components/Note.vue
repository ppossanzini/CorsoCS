<script lang="ts">
import { defineComponent } from 'vue';


export default defineComponent({
  name: 'Note',
  props: {
    note: {
      type: Object as () => Server.Note,
      required: true
    }
  },
  setup(props, { emit }) {


    emit('test', 'ok');

    return {
      note: props.note
    }
  }
});


</script>
<template>
  <div class="note">
    <span class="id">{{ note.id }}</span>
    <span class="title">{{ note.title }}</span>
    <span class="body">{{ note.body }}</span>
    <span class="date">{{ note.date }}</span>
  </div>
</template>

<style scoped>
.note {
  display: grid;
  gap: 0.5rem;
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  grid-template-columns: repeat(5 1fr);
  grid-template-rows: 1fr 2fr;
}

.id,
.date {
  grid-row: 1;
}

.title,
body {
  grid-row: 2;
}

.id {
  grid-column: 1/3;
}

.date {
  grid-column: 3/6;
}

.title {
  grid-column: 1/3;
}

.body {
  grid-column: 3/6;
}
</style>
