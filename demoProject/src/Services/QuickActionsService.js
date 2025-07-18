import { apiClient } from "./apiClient";

export default { 
    async getFindDonorView() {
        return await apiClient.get("FindDonar/GetFindDonar");
    },
    async postFindDonor(findDonorView) {
        var model=new FormData();
        model.append("model", JSON.stringify(findDonorView));
        return await apiClient.post("FindDonar/postFindDonor", findDonorView);
    },
    async getOrderBloodView() {
        return await apiClient.get("FindDonar/getOrderBlood");
    },
    async postOrderBlood(orderBloodView) {
        var model=new FormData();
        model.append("model", JSON.stringify(orderBloodView));
        return await apiClient.post("FindDonar/postOrderBlood", orderBloodView);
    },
    async getDonateView() {
        return await apiClient.get("BloodDonor/getBloodDonor");
    },
     async postDonate(donateView) {
        var model=new FormData();
        model.append("model", JSON.stringify(donateView));
        return await apiClient.post("BloodDonor/postBloodDonor", donateView);
    },
    // async getDonorDetails(donorId) {
    //     return await apiClient.get(`donorDetails?donorId=${donorId}`);
    // }
}