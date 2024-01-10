import axiosClient from "../utils/axiosConfig";

const productApi = {
    getAll: async (model) => {
        return await axiosClient.post('/product/getall',model)
    },
    getById: async (id) => {
        return await axiosClient.get(`/product/${id}`)
    }
}

export default productApi;