import axiosClient from "../utils/axiosConfig"
const authApi = {
    login: async (userInfo) => {
        return await axiosClient.post('/customer/login', userInfo);
    },
    getInfo: async () => {
        return await axiosClient.post('/customer/getCustomerInfo');
    },
    register: async (registerInfo) => {
        return await axiosClient.post('/customer/createnew',registerInfo)
    },
    getCustomerCart: async () => {
        return await axiosClient.get('/customer/getcartlist');
    },
    removeCartItem: async (id) => {
        return await axiosClient.delete(`/customer/remove-item/${id}`);
    },
    addToCart: async (model) => {
        return await axiosClient.post('/customer/addtocart',model)
    },
    usingVoucher: async (voucherCode) => {
        return await axiosClient.get(`/voucher/${voucherCode}`)
    },
    payment: async (paymentInfo) => {
        return await axiosClient.post('/invoice/create',paymentInfo)
    }

}
export default authApi