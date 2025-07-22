<template>
    <div class="container">
        <h1>Find Donar</h1>
        <p>Search for a donor by name or ID.</p>
        <input type="text" placeholder="Enter donor name or ID" @click="getLoad()" v-model="NameSearch" />
        <button @click="getLoad()" >Search</button>
        <table v-if="searchResultsValue" class="search-results">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Blood Group</th>
                    <th>Location</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="donor in searchResults" :key="donor.iDonateId">
                    <td>{{ donor.sName }}</td>
                    <td>{{ donor.iBloodGroup }}</td>
                    <td>{{ donor.iLocation }}</td>
                    <td>
                        <a href="#" @click.prevent="router.push(`/donor/${donor.iDonateId}`)" v-tooltip="'View Donor Details'">👁️View</a>
                        <button class="action-card" @click="RequestSent()" v-tooltip="'Request Blood'">Request Blood</button>
                    </td>

                </tr>
            </tbody>
        </table>

        <!-- <DataTable></DataTable>
        <div class="results">
            <p v-for="result in searchResults" :key="result.iDonateId">{{ result.sName }} - {{ result.iBloodGroup }}</p>
        </div> -->
        <div class="error" v-if="searchError">{{ searchError }}</div>
        <div class="loading" v-if="!searchResults && !searchError">Loading...</div>
        <nav-item></nav-item>
    </div>
</template>
<script setup>
import NavItem from '../NavItem.vue';   
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import QuickActionsService from '../../Services/QuickActionsService';
const router = useRouter();

const searchQuery = ref('');
const searchResults = ref({});
const searchError = ref('');
const NameSearch = ref('');
const searchResultsValue = ref(false);
const getLoad = () => {
    var searchKey=document.querySelector('input[type="text"]').value;
    if (!NameSearch.value) {
        searchError.value = 'Please enter a search key.';
        return;
    }
    else {    
    QuickActionsService.getSearchResults(NameSearch.value).then((res) => {
        if (res.data) {
            searchResults.value = res.data;
            searchError.value = '';
            searchResultsValue.value = true;
        } else {
            searchError.value = 'No results found for the given search key.';
            searchResultsValue.value = false;
        }
    }).catch((error) => {
        console.error("Error fetching search results:", error);
        searchError.value = 'An error occurred while fetching search results.';
        searchResultsValue.value = false;
    });
}
};
const RequestSent = () => {
    alert('Request sent successfully!');
    // Here you can add logic to handle the request, like updating the database or notifying the user.
};

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
.search-results {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}
.search-results th, .search-results td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: left;
}
.search-results th {
    background-color: #f2f2f2;
}
.error {
    color: red;
    font-size: 14px;
    margin-top: 10px;
}
.loading {
    font-size: 14px;
    color: #888;
    margin-top: 10px;
}
.action-card {
    display: inline-block;
    padding: 2px 4px;
    background-color: #28a745;
    color: white;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    margin-left: 15px;
}
.action-card:hover {
    background-color: #218838;
}
.th a{
    color: #007bff;
    text-decoration: none;
}
</style>