<template>
    <div class="container">
        <h1>Find Donors</h1>
        <p class="subheading">Raise Blood Request. Fill below details accurately to help you better</p>

        <div class="section">
            <label class="label">🩸 Blood Donor</label>
            <div class="radio-group">
                <label><input type="radio" name="donor" value="blood" v-model="findDonorView.iDonarType" /> Blood Donor</label>
                <label><input type="radio" name="donor" value="platelet" v-model="findDonorView.iDonarType" /> Platelets Donor</label>
            </div>
            <div v-if="sDonrTypeError && !findDonorView.iDonarType" class="error">{{ sDonrTypeError }}</div>
        </div>

        <div class="section">
            <label class="label">👤 Name</label>
            <input class="input" type="text" placeholder="Enter patient’s name" v-model="findDonorView.sPatinetName" required/>
            <div v-if="sPatinetNameError && !findDonorView.sPatinetName " class="error">{{ sPatinetNameError }}</div>
            <!-- <strong>Note:</strong> This is the name of the patient who needs blood. -->
        </div>

        <div class="section">
            <label class="label">🧬 Blood Group</label>
            <div class="grid">
                <div v-for="group in bloodGroups" :key="group"
                    :class="['blood-btn', selectedGroup === group ? 'active' : '']" @click="selectGroup(group)">
                    {{ group }}
                </div>
                <div v-if="iBloodGroupError && !findDonorView.iBloodGroup" class="error">{{ iBloodGroupError }}</div>
            </div>
            <strong>Note:</strong> This is the blood group of the patient. Select the appropriate group.
            <br />
            <div class="more-options">More Options ></div>
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
            <label class="label">📍 Location</label>
            <input class="input" type="text" placeholder="Enter your location" v-model="findDonorView.iLocation"  />
            <div v-if="iLocationError && !findDonorView.iLocation" class="error">{{ iLocationError }}</div>
            <strong>Disclaimer:</strong> Your location will be used to find donors near you.
        </div>
        <div class="section">
            <label class="label">🧾 AddNote</label>
            <textarea class="input" placeholder="Add any additional notes or requirements" v-model="findDonorView.sDescription"></textarea>
            <div v-if="sDescriptionError && !findDonorView.sDescription" class="error">{{ sDescriptionError }}</div>
            <br />
            <strong>Note:</strong> This is optional, but can help donors understand your needs better.
        </div>
        
        <button class="submit" @click="PostFindDonor()">Post Request</button>

        <p class="disclaimer">
            <strong>Disclaimer:</strong> Any raised Blood request is live till 7 days. Your Blood request is live till
            {{disclaimerMessage}}.

        </p>
        <nav-item></nav-item>
    </div>
</template>

<script setup>
import { onMounted, ref, warn } from 'vue'
import NavItem from '../NavItem.vue';
import { useRouter } from 'vue-router';
import InputText from 'primevue/inputtext'
import RadioButton from 'primevue/radiobutton'
import Checkbox from 'primevue/checkbox'
//import findDonorService from '../Services/findDonorService';
import findDonorService from '../../Services/QuickActionsService';

const router = useRouter();

const donorType = ref('blood')
const name = ref('')
const selectedGroup = ref('')
const selectedUnit = ref(null)
const location = ref('')
const findDonorView=ref({});
const sDonrTypeError=ref('');
const sPatinetNameError=ref('');
const iBloodGroupError=ref('');
const iLocationError=ref('');
const sDescriptionError=ref('');
const iUnitsError=ref('');
const disclaimerMessage=ref('');

disclaimerMessage.value = new Date(new Date().getTime() + 7 * 24 * 60 * 60 * 1000).toLocaleDateString();



const bloodGroups = ['A+', 'A-', 'B+', 'B-', 'O+', 'O-', 'AB+', 'AB-']
const units = [1, 2, 3, 4, 5, 6, 8]


onMounted(()=>{
  getLoad();
})
const getLoad = () => {
    findDonorService.getFindDonorView().then((response) => {
        findDonorView.value = response.data;
    }).catch((error) => {
        console.error('Error fetching find donor view:', error);
        alert('An error occurred while fetching find donor view.');
    });
};
const selectGroup = (group) => {
   selectedGroup.value = group;
   findDonorView.value.iBloodGroup= group;
}

const selectUnit = (unit) => {
 selectedUnit.value = unit
  findDonorView.value.iUnits= unit;
}
function PostFindDonor() {
  if(!isValid()) {
    //alert("Please fill all required fields.");
     //toast.add({ severity: 'info', summary: 'Info', detail: 'Please fill all required fields.', life: 3000 });
    return;
  }
    findDonorService.postFindDonor(findDonorView.value).then((response) => {
     if(response.data.count>0){
        alert("Your request has been posted successfully.");
        router.push('/Home');
     } else {
        alert("Failed to post your request. Please try again.");
        getLoad();
     }
    }).catch((error) => {
        console.error("Error posting find donor request:", error);
        alert("An error occurred while posting your request. Please try again.");
        getLoad();
       // router.push('/Home')
    });
  
}
const isValid = () => {
  let isValid = true;
  if(!findDonorView.value.iDonarType){
    sDonrTypeError.value = "Please select a donor type.";
    //warn("Please select a donor type.");
     isValid = false;
  }
  if(!findDonorView.value.sPatinetName){
    sPatinetNameError.value = "Please enter the patient's name.";
    //findDonorView.value.sPatinetName = '';
   // warn("Please enter the patient's name.");
     isValid= false;
  }
  if(!findDonorView.value.iBloodGroup){
    iBloodGroupError.value = "Please select a blood group.";
    //warn("Please select a blood group.");
     isValid=false;
  }
  if(!findDonorView.value.iLocation){
    iLocationError.value = "Please enter your location.";
    
   // warn("Please enter your location.");
     isValid=false;
  }
  if(!findDonorView.value.iUnits){
    iUnitsError.value = "Please select the number of units needed.";
    // warn("Please select the number of units needed.");
     isValid=false;
  }
  if(!findDonorView.value.sDescription){
    sDescriptionError.value = "Please add a note or description.";
    //warn("Please add a note or description.");
     isValid=false;
  }
  return isValid;
    // return findDonorView.value.iDonarType && findDonorView.value.sPatinetName && findDonorView.value.iBloodGroup &&
    //        findDonorView.value.iLocation && findDonorView.value.iUnits;
}
</script>

<style scoped>
.container {
  max-width: 700px;
  margin: 0 auto;
  padding: 20px;
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
  margin-bottom: 5px;
  display: flex;
  justify-content: left;
}

.section {
  margin-bottom: 20px;
}

.label {
  font-weight: bold;
  display: flex;
  justify-content: left; 
  margin-bottom: 10px;
}
.radio-group {
  display: flex;
  gap: 25px;
  margin-bottom: 10px;
}

.radio-group label {
  margin-right: 10px;
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
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

.more-options {
  color: #e4314d;
  font-size: 14px;
  margin-top: 10px;
  cursor: pointer;
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
