import axiosClient from "../utils/axiosConfig";

const categoryApi = {
    getAllBrand: async () => {
        return await axiosClient.get('/brand')
    },
    getAllStrapMaterial: async () => {
        return await axiosClient.get('/strapmaterial')
    }
}

export default categoryApi;