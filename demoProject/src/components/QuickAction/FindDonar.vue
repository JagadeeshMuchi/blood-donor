<template>
    <div class="container">

        <RadioButton v-for="item in radiaButtionList" :key="item.value" :name="item.label" :value="item.value"
            :label="item.label"></RadioButton>
        <button>Search</button>

    </div>
    <nav-item></nav-item>
</template>
<script setup>
import NavItem from '../NavItem.vue';
import RadioButton  from 'primevue/radiobutton';
import { ref,onMounted,defineProps } from 'vue';


const radiaButtionList= ref([
    { label: 'BloodDonar', value: '0' },
    { label: 'PlateLetsDonor', value: '1' }
]);
</script>
<style scoped>
.container {    
    padding: 20px;
    background-color: #f9f9f9;
    border-radius: 8px;
    max-width: 600px;
    margin: auto;
}
.header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
}
h1 {
    font-size: 24px;
    margin-bottom: 10px;
}
p {
    font-size: 16px;
    margin-bottom: 20px;
}
input {
    width: 100%;
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
}
button {
    padding: 10px 15px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}
button:hover {
    background-color: #0056b3;
}
.results {
    margin-top: 20px;
    padding: 10px;
    background-color: #fff;
    border: 1px solid #ddd;
    border-radius: 4px;
}
.results p {
    margin: 0;
    padding: 5px 0;
    border-bottom: 1px solid #eee;
}
.results p:last-child {
    border-bottom: none;
}
</style>
