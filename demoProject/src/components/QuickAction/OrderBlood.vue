<template>
<div class="container">
    <div class="header">
        <h1>OrderBlood</h1>
    </div>
    <div class="subheading">
        <p>Order Blood from the nearest blood bank</p>
        <p>Fill below details accurately to help you better</p>
    </div>
     <div class="section">
        <label class="label">👤 Name</label>
            <input class="input" type="text" placeholder="Enter your name" v-model="orderBloodView.sName"  />
            <div v-if="sNameError && !orderBloodView.sName" class="error">{{ sNameError }}</div>
        </div>
        <div class="section">
            <label class="label">📍 Location</label>
            <input class="input" type="text" placeholder="Enter your location" v-model="orderBloodView.sLocation"  />
            <div v-if="sLocationError && !orderBloodView.sLocation" class="error">{{ sLocationError }}</div>

            <strong>Disclaimer:</strong> Your location will be used to find blood banks near you.
        </div>
       
         <div class="section">
            <label class="label">🩸 Blood Group</label>
            <div class="grid">
                <div v-for="group in bloodGroups" :key="group"
                    :class="['blood-btn', selectedGroup === group ? 'active' : '']" @click="selectGroup(group)">
                    {{ group }}
                </div>
                <div v-if="iBloodGroupError && !findDonorView.iBloodGroup" class="error">{{ iBloodGroupError }}</div>
            </div>
            <strong>Note:</strong> This is the blood group of the patient. Select the appropriate group.
            <br />
            <!-- <div class="more-options">More Options ></div> -->
        </div>

        <div class="section">
            <label class="label">🧾 How many Units of Blood you need?</label>
            <div class="grid">
                <div v-for="unit in units" :key="unit" :class="['unit-btn', selectedUnit === unit ? 'active' : '']"
                    @click="selectUnit(unit)">
                    {{ unit }}
            </div>
                <div v-if="iUnitsError && !findDonorView.iUnits" class="error">{{ iUnitsError }}</div>   
            </div>
            <strong>Note:</strong> This is the number of blood units needed. Select the appropriate number.
            <br />

        </div>

        <div class="section">
            <label class="label">🧾 AddNote</label>
            <textarea class="input" placeholder="Add any additional notes or requirements" v-model="orderBloodView.sDescription"></textarea>  
            <br />
            <strong>Note:</strong> This is optional, but can help blood banks understand your needs better.
            </div>
        <button class="submit" @click="PostOrderBlood">Order Blood</button>
    <nav-item></nav-item>
   
</div>
</template>

<script setup>
import { label } from '@primeuix/themes/aura/metergroup';
import NavItem from '../NavItem.vue';
import { ref } from 'vue';
import { onMounted } from 'vue';
import QuickActionsService from '../../Services/QuickActionsService';

onMounted(()=>{
    QuickActionsService.getOrderBloodView().then((response) => {
        orderBloodView.value = response.data;
    }).catch((error) => {
        console.error('Error fetching order blood view:', error);
        alert('An error occurred while fetching order blood view.');
    });
})

const orderBloodView = ref({});
const sBloodGroupError = ref('');
const sLocationError = ref('');
const sNameError = ref('');
const bloodGroups = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'];
const selectedGroup = ref('');
const selectGroup = (group) => {
    selectedGroup.value = group;
    orderBloodView.value.sBloodGroup = group; 
};
const units = ['1', '2', '3', '4', '5'];
const selectedUnit = ref('');
const selectUnit = (unit) => {
    selectedUnit.value = unit;
    orderBloodView.value.iUnits = unit; 
};
const PostOrderBlood = () => {
    if (!orderBloodView.value.sBloodGroup) {
        sBloodGroupError.value = 'Please enter blood group';
        return;
    }
    if (!orderBloodView.value.sLocation) {
        sLocationError.value = 'Please enter your location';
        return;
    }
    if (!orderBloodView.value.sName) {
        sNameError.value = 'Please enter your name';
        return;
    }

    apiServer.postOrderBlood(orderBloodView.value).then((res) => {
        if (res.data.success) {
            alert('Order placed successfully!');
            // Reset form
            orderBloodView.value = { sBloodGroup: '', sLocation: '', sName: '' };
        } else {
            alert('Failed to place order. Please try again.');
        }
    }).catch((error) => {
        console.error('Error placing order:', error);
        alert('An error occurred while placing the order.');
    });
};
</script>
<style scoped>
.container {
  max-width: 700px;
  margin: 0 auto;
  padding: 10px;
  font-family: sans-serif;
}
h1 {
  font-size: 28px;
  font-weight: bold;
  display: flex;
  justify-content: left;
}

.subheading {
  font-size: 14px;
  color: #555;
  margin-bottom: 10px;
  display: flex;
  justify-content: left;
}

.section {
  margin-bottom: 25px;
}

.label {
  font-weight: bold;
  display: flex;
  justify-content: left; 
  margin-bottom: 10px;
}
.input {
  width: 100%;
  padding: 10px;
  border-radius: 8px;
  border: 1px solid #ccc;
}

.grid {
  display: flex;
  flex-wrap: wrap;
  gap: 25px;
}

.blood-btn,
.unit-btn {
  padding: 10px 16px;
  border-radius: 8px;
  border: 1px solid #ccc;
  background: #fff;
  cursor: pointer;
}
.blood-btn.active,
.unit-btn.active {
  background-color: #e4314d;
  color: white;
  border-color: #e4314d;
}
.error {
    color: red;
    font-size: 12px;
}
.submit {
  width: 100%;
  padding: 12px;
  background-color: #e4314d;
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 16px;
  cursor: pointer;
  margin-top: 20px;
}
.disclaimer {
  font-size: 12px;
  color: #888;
  margin-top: 10px;
  text-align: center;
}
.error {
  color: red;
  font-size: 12px;
  margin-top: 5px;
  display: flex;
  justify-content: left;
  font-weight: bold;
  margin-bottom: 10px;
}

</style>