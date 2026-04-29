import { defineComponent, ref, watch } from "vue";
import { noteService } from "@/services/noteService";
import Note from "@/components/Note.vue";


export default defineComponent({
  name: "SearchNotes",
  components: {
    Note
  },
  setup(props, ctx) {

    const searchText = ref<string>('');
    const foundNotes = ref<Server.PagedResults<Server.Note> | null>(null);

    watch(searchText, async (newValue) => {
      foundNotes.value = await noteService.getNotes(newValue, newValue);
    });

    return {
      searchText,
      foundNotes
    }
  },
});