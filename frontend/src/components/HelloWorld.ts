

import { defineComponent, reactive, ref } from 'vue'


export default defineComponent({
  name: 'HelloWorld',
  props: {
    msg: String
  },
  setup(props, ctx) {

    const faiqualcosa = () => { count.value = count.value + 1 }


    const obj = ref({
      titolo: 'Ciao',
    });

    //obj.titolo = 'Ciao2';
    obj.value.titolo = 'Ciao3';

    const count = ref(0);
    count.value++;
    count.value++;


    return { count, faiqualcosa };
  },
})


