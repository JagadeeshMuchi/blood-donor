import { nodeClient } from "./NodeClinet";

export default {
 
  async postBloodDonor(donteview){
    return await  nodeClient.post('BloodDonorPost',donteview ,{ headers: { 'Content-Type': 'application/json' }});
  },

}


