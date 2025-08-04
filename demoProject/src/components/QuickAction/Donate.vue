<template>
    
<div class="container">
    <div v-if="DonateMessage" :class="['signup-alert', DonateMessageType === 'success' ? 'signup-success' : 'signup-error']">
      {{ DonateMessage }}
      <span class="signup-alert-close" @click="DonateMessage = ''">×</span>
    </div>
   
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
            <input class="input" type="text" placeholder="Enter your name" v-model="donateView.sName" />
            <div v-if="sDonorNameError && !donateView.sName " class="error">{{ sDonorNameError }}</div>
            <strong>Note:</strong> This is your name as a donor. 
        </div>
        <div class="section">
            <label class="label">How often would you like to donate?</label>
            <div class="grid">
                <div v-for="frequency in frequencies" :key="frequency.id"
                    :class="['frequency-btn', selectedFrequency.id === frequency.id ? 'active' : '']"
                    @click="selectFrequency(frequency)">
                    {{ frequency.name }}
                </div>
                <div v-if="iFrequencyError && !donateView.iPayFrequncy" class="error">{{ iFrequencyError }}</div>
            </div>
            <strong>Note:</strong> This is how often you would like to donate blood.
            <br />
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
            <label class="label">📍 Location</label>
            <input class="input" type="text" placeholder="Enter your location" v-model="donateView.iLocation" />
            <div v-if="iLocationError && !donateView.iLocation" class="error">{{ iLocationError }}</div>
            <strong>Disclaimer:</strong> Your location will be used to find donors near you.
        </div>
        <div class="section">
            <label class="label"> DOB</label>
            <input class="input" type="date" placeholder="Enter your date of birth" v-model="donateView.iDOB" />
            <div v-if="(dobError && !donateView.iDOB)" class="error">{{ dobError }}</div>
            <div v-if="checkAgeError" class="error">{{ checkAgeError }}</div>
            <strong>Note:</strong> This is your date of birth. It helps us verify your eligibility to donate blood.
        </div>

        <!-- <div class="section">
             <label class="label">📞 Contact Number</label>
            <input class="input" type="text" placeholder="Enter your contact number" v-model="donateView.sContactNumber" />
            <div v-if="sContactNumberError && !donateView.sContactNumber" class="error">{{ sContactNumberError }}</div>
            <strong>Note:</strong> This is your contact number for potential donors to reach you
        </div> -->
        
        
        
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
import NodeApiServer from '../../Services/NodeApiServer';
import DonationCard from '../DonationCard.vue';
const router = useRouter();

const donateView = ref({});
const bloodGroups = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'];
const selectedGroup = ref('');
const DonateMessage=ref('')
const DonateMessageType=ref('')



const frequencies = [
    { id: 1, name: 'Once a month' },
    { id: 2, name: 'Every 3 months' },
    { id: 3, name: 'Every 6 months' },
    { id: 4, name: 'Once a year' }
];
const selectedFrequency = ref('');
const sDonrTypeError = ref('');
const sDonorNameError = ref('');
const sContactNumberError = ref('');
const dobError = ref('');
const iLocationError = ref('');
const iBloodGroupError = ref('');
const iFrequencyError = ref('');

onMounted(() => {
    //getLoad();
});

const getLoad=()=>{
    QuickActionsService.getDonateView().then((response) => {
        donateView.value = response.data;
    }).catch((error) => {
        console.error('Error fetching donate view:', error);
        //alert('An error occurred while fetching donate view.');
    });
}
const selectGroup = (group) => {
    selectedGroup.value = group;
    donateView.value.iBloodGroup = group;
};
const selectFrequency = (frequency) => {
    selectedFrequency.value = frequency;
    donateView.value.iPayFrequncy = frequency.id;
};
const datetoInt = (dob)  => {
    if(dob === null || dob === undefined) {
        return 0;
    }
    let date = 0;
    try{
   date= ((dob.getfullYear()* Math.pow(2,16) ) + ((dob.getMonth() * Math.pow(2,8)+1)) + dob.getDate());
    }catch (error) {
          date= new Date(dob);
        date = ((date.getFullYear() * Math.pow(2, 16)) + ((date.getMonth()+1) * Math.pow(2, 8)) + date.getDate());
        return date;
    }
    return date;
};

//check age based on date of birth
const checkAgeError = ref('');
const iEmpId= localStorage.getItem('ProfileId');
const  checkAge = () => {
    if (!donateView.value.iDOB) return false;
    const today = new Date();
    const birthDate = new Date(donateView.value.iDOB);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    if( age < 18) {
        checkAgeError.value = "You must be at least 18 years old to donate blood.";
        return false;
    } else {
        checkAgeError.value = '';
        return true;
    }
     // Minimum age to donate blood is 18
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

    if (!donateView.value.sName) {
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
    if (!donateView.value.iPayFrequncy) {
        iFrequencyError.value = "Please select how often you would like to donate.";
        isValid = false;
    }
    
    return isValid;
};
const clearData=()=>{
    donateView.value.sName='';
    donateView.value.iLocation='';
    donateView.value.iBloodGroup='';
    donateView.value.iDOB='';
    donateView.value.iPayFrequncy='';
    donateView.value.UserId=0;
    selectedGroup.value='';
    selectedFrequency.value=''
}
const PostDonate = () => {
    if (validateForm() && checkAge()) {
        //donateView.value.iDOB=datetoInt(donateView.value.iDOB);
       
        QuickActionsService.postDonate(donateView.value).then((response) => {
            if (response.data.count>0) {
                alert('Thank you for registering as a blood donor!');
               router.push('/Home');
            } else {
                alert('Failed to register. Please try again later.');
                getLoad();
               // router.push('/Home');
            }
        }).catch((error) => { 
           alert("Posted data through node.js server Due to MVC server is Busy ");
           donateView.value.UserId=iEmpId;
        NodeApiServer.postBloodDonor(donateView.value).then((response)=>{
          if(response.data!=undefined && response.data>0){
            DonateMessage.value="Thank you for your selfless donation! Your generosity is truly inspiring and you have made a real difference in someone's life."
            DonateMessageType.value="success"
           clearData();
          }else{
            DonateMessage.value="Thank you for your willingness to help! Please wait a moment while we connect you with someone in need. If there is a delay, rest assured your generosity will make a difference soon.";
            DonateMessageType.value='error'
              clearData();
          }
        //   setTimeout(() => {
        //     DonateMessage.value = '';
        //   }, 3000);
        })
            //router.push('/Home');
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
 .signup-success {
   color: #2ea44f;
   font-size: 15px;
   margin-top: 16px;
   font-weight: 600;
 }
 .signup-error {
   color: #d73a49;
   font-size: 15px;
   margin-top: 16px;
   font-weight: 600;
 }
 .signup-alert {
   position: fixed;
   top: 0;
   left: 3;
   width: 30%;
   padding: 16px 9px;
   text-align: left;
   font-size: 16px;
   font-weight: 600;
   z-index: 200;
   border-radius: 0 0 8px 8px;
   box-shadow: 0 2px 8px rgba(0,0,0,0.08);
   display: flex;
   justify-content: center;
   align-items: center;
   margin: 0rem 0rem 0rem 35rem;
 }
 .signup-success.signup-alert {
   background: #e6f4ea;
   color: #22863a;
   border-bottom: 2px solid #2ea44f;
 }
 .signup-error.signup-alert {
   background: #fbeaea;
   color: #d73a49;
   border-bottom: 2px solid #d73a49;
 }
 .signup-alert-close {
   margin-left: 16px;
   cursor: pointer;
   font-size: 22px;
   color: #888;
   font-weight: bold;
   background: none;
   border: none;
 }





</style>