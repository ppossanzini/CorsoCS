import { defineComponent, ref, type Ref } from 'vue';
import { noteService } from '@/services/noteService';


export default defineComponent({
  name: 'CreateNote',
  setup() {
    // const title = ref('');
    // const body = ref('');
    // const date = ref(new Date());
    // const note: Ref<Server.Note> = ref({});
    const note = ref<Server.CreateNote>({
      body: '',
      date: new Date(),
      title: ''
    });

    async function saveNote(evt: PointerEvent) {
      await noteService.createNote(note.value);

    }

    const discardNote = () => {
      note.value = {
        body: '',
        date: new Date(),
        title: ''
      };
    };

    return { note, saveNote, discardNote };
  }
});
