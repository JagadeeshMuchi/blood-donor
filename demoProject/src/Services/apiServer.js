import { apiClient } from "./apiClient";
import { nodeClient } from "./NodeClinet";

export default {

async  getlogin(email,password) {
    return await apiClient.get('getLogin?userName='+email+'&passWord='+password)
},
async getUserProfile(iempId) {
    return await apiClient.get('Profile/getUserProfile?iProfileId='+iempId)     
},
async getDonorList(sSearchName) {
    return await nodeClient.get('bloodDonor?sDonorName=' + sSearchName);
},
async checkLogin(email, password) {
    return await nodeClient.get('checkLogin?username=' + email + '&password=' + password)
},
async getProfile(id){
    return await nodeClient.get('getPorfile?id='+id)
},
async createAccount(logiview){
    return await nodeClient.post('createAccount', logiview, {
        headers: { 'Content-Type': 'application/json' }
    });
},
}