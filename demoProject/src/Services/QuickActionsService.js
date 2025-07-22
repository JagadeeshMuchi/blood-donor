import { apiClient } from "./apiClient";

export default { 
    async getFindDonorView() {
        return await apiClient.get("QuickActions/GetFindDonar");
    },
    async postFindDonor(findDonorView) {
        // var model=new FormData();
        // model.append("model", JSON.stringify(findDonorView));
        return await apiClient.post("QuickActions/postFindDonor", findDonorView);
    },
    async getOrderBloodView() {
        return await apiClient.get("QuickActions/getOrderBlood");
    },
    async postOrderBlood(orderBloodView) {
        // var model=new FormData();
        // model.append("model", JSON.stringify(orderBloodView));
        return await apiClient.post("QuickActions/postOrderBlood", orderBloodView);
    },
    async getDonateView() {
        return await apiClient.get("Donote/getBloodDonor");
    },
     async postDonate(donateView) {
        const formdata=new FormData();
        formdata.append("model", JSON.stringify(donateView));
        return await apiClient.post("Donote/postBloodDonor", formdata, {
            headers: { 'Content-Type': 'multipart/form-data' }
        });
    },
    async getSearchResults(searchParams) {
        return await apiClient.get("QuickActions/getSearchResults?searchKey="+searchParams);
    },

    // async getDonorDetails(donorId) {
    //     return await apiClient.get(`donorDetails?donorId=${donorId}`);
    // }
}