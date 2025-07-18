<template>
    
<div class="container">
   
        <h1>Donate</h1>
        <p class="subheading">Donate blood directly to people in need.</p>
        <!-- <div class="section">
            <label class="label">🩸 Blood Donor</label>
            <div class="radio-group">
                <label><input type="radio" name="donor" value="blood" v-model="donateView.iDonarType" /> Blood Donor</label>
                <label><input type="radio" name="donor" value="platelet" v-model="donateView.iDonarType" /> Platelets Donor</label>
            </div>
            <div v-if="sDonrTypeError && !donateView.iDonarType" class="error">{{ sDonrTypeError }}</div>
        </div> -->
        <div class="section">
            <label class="label">👤 Name</label>
            <input class="input" type="text" placeholder="Enter your name" v-model="donateView.sDonorName" />
            <div v-if="sDonorNameError && !donateView.sDonorName " class="error">{{ sDonorNameError }}</div>
            <strong>Note:</strong> This is your name as a donor. 
        </div>
        <div class="section">
            <label class="label"> DOB</label>
            <input class="input" type="date" placeholder="Enter your date of birth" v-model="donateView.iDOB" />
            <div v-if="dobError && !donateView.dob" class="error">{{ dobError }}</div>
            <strong>Note:</strong> This is your date of birth. It helps us verify your eligibility to donate blood.
        </div>

        <!-- <div class="section">
             <label class="label">📞 Contact Number</label>
            <input class="input" type="text" placeholder="Enter your contact number" v-model="donateView.sContactNumber" />
            <div v-if="sContactNumberError && !donateView.sContactNumber" class="error">{{ sContactNumberError }}</div>
            <strong>Note:</strong> This is your contact number for potential donors to reach you
        </div> -->
        <div class="section">
            <label class="label">📍 Location</label>
            <input class="input" type="text" placeholder="Enter your location" v-model="donateView.iLocation" />
            <div v-if="iLocationError && !donateView.iLocation" class="error">{{ iLocationError }}</div>
            <strong>Disclaimer:</strong> Your location will be used to find donors near you.
        </div>
        <div class="section">
            <label class="label">🧬 Blood Group</label>
            <div class="grid">
                <div v-for="group in bloodGroups" :key="group"
                    :class="['blood-btn', selectedGroup === group ? 'active' : '']" @click="selectGroup(group)">
                    {{ group }}
                </div>
                <div v-if="iBloodGroupError && !donateView.iBloodGroup" class="error">{{ iBloodGroupError }}</div>
            </div>
            <strong>Note:</strong> This is your blood group. Select the appropriate group.
            <br />
            <div class="more-options">More Options ></div>
        </div>
        <div class="section">
            <label class="label">How often would you like to donate?</label>
            <div class="grid">
                <div v-for="frequency in frequencies" :key="frequency"
                    :class="['frequency-btn', selectedFrequency === frequency ? 'active' : '']"
                    @click="selectFrequency(frequency)">
                    {{ frequency }}
                </div>
                <div v-if="iFrequencyError && !donateView.iFrequency" class="error">{{ iFrequencyError }}</div>
            </div>
            <strong>Note:</strong> This is how often you would like to donate blood.
            <br />
        </div>
        <button class="submit" @click="PostDonate">Register</button>


    <!-- <div class="content">
        <p>Donate blood directly to people in need.</p>
        <p>Help save lives by donating blood.</p>
        <p>Every drop counts!</p>
        <p>Join our community of blood donors.</p>
        <p>Make a difference today.</p>
        <p>Contact us for more information.</p>
        <p>Thank you for your support!</p>
        <p>Follow us on social media for updates.</p>
        <p>Share your donation story with us.</p>
        <p>Together, we can save lives.</p>
        <p>Become a hero by donating blood.</p>
        <p>Help us spread the word about blood donation.</p>
        <p>Every donation helps someone in need.</p>
        <p>Join our mission to save lives.</p>
        <p>Thank you for considering blood donation.</p>
        <p>Your support means the world to us.</p>  
        <p>Contact us to find out how you can help.</p>
    </div> -->
    <div class="footer">
        <p>For more information, visit our website.</p>
        <p>Contact us at:
            <a href="mailto:" 
                class="email-link"></a>
               
        </p>
    </div>     
    <nav-item></nav-item>
</div>
</template>
<script setup>
import { label } from '@primeuix/themes/aura/metergroup';
import NavItem from '../NavItem.vue';

import { ref,onMounted } from 'vue';
import { useRouter } from 'vue-router';

import QuickActionsService from '../../Services/QuickActionsService';
import { date } from '@primeuix/themes/aura/datepicker';
const router = useRouter();

const donateView = ref({});

const bloodGroups = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'];
const selectedGroup = ref('');

const frequencies = ['3Monthly', '4Monthly', 'Quarterly', 'Yearly'];
const selectedFrequency = ref('');
const sDonrTypeError = ref('');
const sDonorNameError = ref('');
const sContactNumberError = ref('');
const dobError = ref('');
const iLocationError = ref('');
const iBloodGroupError = ref('');
const iFrequencyError = ref('');

onMounted(() => {
    QuickActionsService.getDonateView().then((response) => {
        donateView.value = response.data;
    }).catch((error) => {
        console.error('Error fetching donate view:', error);
        alert('An error occurred while fetching donate view.');
    });
});

const selectGroup = (group) => {
    selectedGroup.value = group;
    donateView.value.iBloodGroup = group;
};
const selectFrequency = (frequency) => {
    selectedFrequency.value = frequency;
    donateView.value.iFrequency = frequency;
};
const datetoInt = (dob)  => {
    let date = new Date(dob);
    return date.getDate();
};

const validateForm = () => {
    let isValid = true;
    sDonrTypeError.value = '';
    sDonorNameError.value = '';
    sContactNumberError.value = '';
    dobError.value = '';
    iLocationError.value = '';
    iBloodGroupError.value = '';
    iFrequencyError.value = '';

    if (!donateView.value.sDonorName) {
        sDonorNameError.value = "Please enter your name.";
        isValid = false;
    }
 
    if (!donateView.value.iDOB) {
        dobError.value = "Please enter your date of birth.";
        isValid = false;
    }
    if (!donateView.value.iLocation) {
        iLocationError.value = "Please enter your location.";
        isValid = false;
    }
    if (!donateView.value.iBloodGroup) {
        iBloodGroupError.value = "Please select a blood group.";
        isValid = false;
    }
    if (!donateView.value.iFrequency) {
        iFrequencyError.value = "Please select how often you would like to donate.";
        isValid = false;
    }
    
    return isValid;
};
const PostDonate = () => {
    if (validateForm()) {
        let dob= donateView.value.iDOB;
        if (typeof dob === 'string') {
            let fromattedDate = new Date(dob);
             fromattedDate.toISOString().split('T')[0];
            donateView.value.iDOB = fromattedDate;
        }
        donateView.value.iDOB=datetoInt(donateView.value.iDOB);
        QuickActionsService.postDonate(donateView.value).then((response) => {
            if (response.data.count>0) {
                alert('Thank you for registering as a blood donor!');
                router.push('/Home');
            } else {
                alert('Failed to register. Please try again later.');
                router.push('/Home');
            }
        }).catch((error) => {
            console.error('Error during registration:', error);
            alert('An error occurred while processing your request. Please try again later.');
            router.push('/Home');
        });
    } else {
        console.warn('Form validation failed.');
    }
};
 

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
}

.subheading {
  font-size: 14px;
  color: #555;
  margin-bottom: 20px;
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

.radio-group label {
  margin-right: 20px;
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
  
.footer {
    text-align: center;
    margin-top: 20px;
    font-size: 14px;
    color: #555;
}
.email-link {
    color: #0066cc;
    text-decoration: none;
}
.btn {
    padding: 10px 20px;
    background-color: #4f46e5;
    color: #fff;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}
.btn:hover {
    background-color: #4338ca;
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
.blood-btn,
.frequency-btn {
    padding: 10px 16px;
    border-radius: 8px;
    border: 1px solid #ccc;
    background: #fff;
    cursor: pointer;
}
.blood-btn.active,
.frequency-btn.active { 
    background-color: #4f46e5;
    color: white;
    border-color: #4f46e5;
}
.more-options {
    color: #4f46e5;
    font-size: 14px;
    margin-top: 10px;
    cursor: pointer;
}
.submit {
    width: 100%;
    padding: 12px;
    background-color: #4f46e5;
    color: white;
    border: none;
    border-radius: 8px;
    cursor: pointer;
}
.submit:hover {
    background-color: #4338ca;
}




</style>