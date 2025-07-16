<template>
    <div class="container">
        <h1>Find Donar</h1>
        <p>Search for a donor by name or ID.</p>
        <input type="text" placeholder="Enter donor name or ID" />
        <button>Search</button>
        <nav-item></nav-item>
    </div>
</template>
<script setup>
import NavItem from '../NavItem.vue';   
</script>
<style scoped>
.container{
    padding: 20px;
    background-color: #f9f9f9;
    border-radius: 8px;
    max-width: 600px;
    margin: auto;
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
}
</style>