<template>
  <div class="bg-white rounded-lg p-3 text-center shadow">
    <div class="text-2xl">{{ icon }}</div>
    <p class="text-sm mt-2 font-medium">{{ title }}</p>
  </div>
</template>

<script setup>
defineProps(['title', 'icon'])
</script>
