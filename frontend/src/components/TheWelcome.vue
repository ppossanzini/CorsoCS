<script setup lang="ts">
import WelcomeItem from './WelcomeItem.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import ToolingIcon from './icons/IconTooling.vue'
import EcosystemIcon from './icons/IconEcosystem.vue'
import CommunityIcon from './icons/IconCommunity.vue'
import SupportIcon from './icons/IconSupport.vue'
import { ref } from 'vue'

const num = ref(0);
setInterval(() => {
  num.value += 100;
  if (num.value > 3000) {
    num.value = 0;
  }
}, 100);
const openReadmeInEditor = () => fetch('/__open-in-editor?file=README.md')
</script>

<template>
  <input type="number" v-model="num" />
  <svg viewBox="0 0 4000 4000" fill="white" xmlns="http://www.w3.org/2000/svg">

    <g transform="translate(300, 300)">
      <rect width="1300" height="3000" fill="#999" />
      <g class="transform" :transform="`translate(0,${num})`">
        <rect x="-50" y="10" width="1400" height="250" fill="#fff" />
      </g>
    </g>
  </svg>
</template>
<style scoped>
.transform {
  transition: transform 0.1s ease-in-out;
}
</style>