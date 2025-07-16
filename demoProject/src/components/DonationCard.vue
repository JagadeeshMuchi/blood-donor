<template>
  <div class="bg-gray-100 rounded-md p-3">
    <div class="flex justify-between items-center">
      <div class="flex items-center">
        <div class="bg-red-500 text-white px-3 py-1 rounded-full font-bold mr-3">
          {{ bloodType }}
        </div>
        <div>
          <p class="font-semibold">{{ name }}</p>
          <p class="text-xs text-gray-600">{{ units }} • {{ distance }} away</p>
        </div>
      </div>
      <div class="text-xs text-gray-400">{{ time }}</div>
    </div>
    <div v-if="tag" class="text-xs bg-red-200 text-red-800 inline-block px-2 py-1 rounded mt-2">
      {{ tag }}
    </div>
  </div>
</template>

<script setup>
defineProps(['name', 'units', 'distance', 'time', 'bloodType', 'tag'])
</script>
