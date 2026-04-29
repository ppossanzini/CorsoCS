<script setup lang="ts">
import { ref } from 'vue';
import { AxesHub } from '@/services/axesHub';

const x = ref(0);
const y = ref(0);
const d = ref(0);


const aright = ref(false);
const asidewidth = ref(300);

const hub = new AxesHub();
hub.start((m:{x:number, y:number}) => {
  x.value = m.x;
  y.value = m.y;

});

const isResizing = ref(false);



function startResize(e: PointerEvent) {
  const target = e.currentTarget as HTMLElement;
  target.setPointerCapture(e.pointerId);
  isResizing.value = true;
}

function onPointerMove(e: PointerEvent) {
  if (!isResizing.value) return;
  asidewidth.value += aright.value ? -e.movementX : e.movementX;
}

function stopResize(e: PointerEvent) {
  const target = e.currentTarget as HTMLElement;
  target.releasePointerCapture(e.pointerId);
  isResizing.value = false;
}


</script>

<template>
  <div class="main">
    <section>

      <svg viewBox="0 0 5000 5000">
        <g :transform="`rotate(${d})`" transform-origin="50% 50%">
          <rect x="0" y="0" width="5000" height="5000" fill="#fff" stroke="#333" />
          <g transform="translate(1950,500)">
            <rect x="0" y="0" width="1300" height="4000" fill="#ccc" />

            <g :transform=" `translate(0,${y})`">
              <rect :transform="`translate(${x},0)`" x="-100" y="0" width="200" height="500" fill="#33a" />
              <rect x="-100" y="0" width="1500" height="200" fill="#aaa" />
            </g>
          </g>
        </g>
      </svg>

      <router-view></router-view>
    </section>
    <aside :class="{ right: aright }" :style="{ width: `${asidewidth}px` }">
      <div 
        class="resizer" 
        @pointerdown="startResize"
        @pointermove="onPointerMove"
        @pointerup="stopResize"
        @pointercancel="stopResize"
      >
        <i class="ti ti-grip-vertical"></i>
      </div>
      <i class="ti ti-chevron-left-pipe" v-if="aright" @click="aright = !aright" />
      <i class="ti ti-chevron-right-pipe" v-if="!aright" @click="aright = !aright" />
      <span>Valore x</span>
      <input type="range" min="0" max="1300" step="1" v-model="x" />
      <span>Valore y</span>
      <input type="range" min="0" max="3700" step="1" v-model="y" />
      <span>Valore d</span>
      <input type="range" min="0" max="360" step="1" v-model="d" />
    </aside>
    <footer>
      <span> Valore x: {{ x }}</span>
      <span> Valore y: {{ y }}</span>
    </footer>
  </div>
</template>

<style scoped lang="less">
@import url(./App.less);
</style>
<style lang="less">
html,
document,
body,
#app {
  height: 100vh;
  width: 100vw;
  margin: 0;
  padding: 0;
  overflow: hidden;
  border: 0;

  color: #000;
  background: rgb(255, 255, 255);

  font-family: Arial, Helvetica, sans-serif;
  font-size: 16px;

  * {
    box-sizing: border-box;
    text-align: center;
  }
}
</style>