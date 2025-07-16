import { apiClient } from "./apiClient";

export default {

async  getlogin(email,password) {
    return await apiClient.get('getLogin?userName='+email+'&passWord='+password)
},
async getUserProfile(iempId) {
    return await apiClient.get('Profile/getUserProfile?iProfileId='+iempId)     
} 
}