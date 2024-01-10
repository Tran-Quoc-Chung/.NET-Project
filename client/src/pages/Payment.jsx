import React from 'react'
import { useFormik } from 'formik'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useSelector } from 'react-redux';
import { VND } from '../utils/validateField';
import authApi from '../service/AuthService';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';
function Payment() {
    const cartItem = JSON.parse(localStorage.getItem('usercart'))
    const customer = Cookies.get('customer');
    const navigate = useNavigate();
    if (!customer)
    {
        toast.error("Vui lòng đăng nhập để thanh toán");
        }
    const validate = values => {
        const errors = {};
        if (!values.firstName) {
            toast.error("Tên người nhận không được để trống");
        }
        if (!values.lastName) {
            toast.error(`Tên người nhận không được để trống`);
        }
        if (!values.email) {
            toast.error(`Email không được để trống`);
        }
        if (!values.address) {
            toast.error(`Địa chỉ không được để trống`);
        }
        return errors;
    };
    const formik = useFormik({
        initialValues: {
            firstName: '',
            lastName: '',
            email: '',
            phoneNumber: '',
            address: '',
            note:'',
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    })
    const handleSubmit = (values) => {
        if (!values.firstName || !values.lastName || !values.email || !values.phoneNumber || !values.address)
        {
            return toast.error("Thông tin nhận hàng không hợp lệ");
        }
        const model = {
            Location: values.address,
            Note: values?.note,
            ListProduct: !!cartItem && cartItem?.cartItem
        }
        authApi.payment(model).then(result => {
            if (!result.success) return toast.error("Thanh toán thất bại")
            toast.success("Tạo hóa đơn thành công. Chờ phản hồi của shop nhé!!");
            
            formik.resetForm();
            navigate('/')
        })
    }
    const handlePhoneNumberChange = (e) => {
        // Chỉ cho phép nhập số
        const value = e.target.value.replace(/[^0-9]/g, '');
    
        // Cập nhật giá trị trong formik
        formik.handleChange({
          target: {
            name: 'phoneNumber',
            value,
          },
        });
      };
    return customer && (
        <div className='payment-container'>
            <div className='customer-info'>
                <h2>Thông tin thanh toán</h2>
                <form onSubmit={formik.handleSubmit}>
                    <p className='field col-2'>
                        <label>Họ *</label>
                        <input
                            id="firstName"
                            name="firstName"
                            type="text"
                            onChange={formik.handleChange}
                        />
                    </p>
                    <p className='field col-2'>
                        <label>Tên *</label>
                        <input
                            id="lastName"
                            name="lastName"
                            type="lastName"
                            onChange={formik.handleChange}
                            value={formik.values.lastName} />
                    </p>
                    <p className='field col-1'>
                        <label>Email *</label>
                        <input
                            id="email"
                            name="email"
                            type="email"
                            onChange={formik.handleChange}
                            value={formik.values.email} />
                    </p>
                    <p className='field col-1'>
                        <label>Số điện thoại *</label>
                        <input
                            id="phoneNumber"
                            name="phoneNumber"
                            type="phoneNumber"
                            onChange={handlePhoneNumberChange}
                            value={formik.values.phoneNumber} />
                    </p>
                    <p className='field col-1'>
                        <label>Địa chỉ *</label>
                        <input
                            id="address"
                            name="address"
                            type="text"
                            onChange={formik.handleChange}
                            value={formik.values.address} />
                    </p>
                    <p className='field col-1 input-area'>
                        <label>Ghi chú cho đơn hàng</label>
                        <input
                            id="note"
                            name="note"
                            type="text"
                            onChange={formik.handleChange}
                            value={formik.values.note} />
                    </p>
                    <button onSubmit={(e) => formik.handleSubmit(e)} type='submit'>Thanh toán</button>
                </form>
            </div>
            <div className='payment-invoice'>
                <h2>ĐƠN HÀNG CỦA BẠN</h2>
                <table>
                    <thead>
                        <th className=''>Sản phẩm</th>
                        <th className='product-total'>Tổng</th>
                    </thead>
                    <tbody>
                        {!!cartItem && cartItem.cartItem.map(item => (
                            <tr>
                            <td className='product-name'>{item.productName} <strong>× {item.quantity}</strong></td>
                                <td className='product-price'><span>{ VND.format(item.quantity * item.price)}</span></td>
                        </tr>
                       ))}
                    </tbody>
                </table>
                <div className='payment-total'>
                    <div className='total-info'>
                        <h3>Tổng phụ</h3>
                        <span> {VND.format(cartItem.total ) || 0}</span>
                    </div>
                    <div className='total-info'>
                        <h3>Khuyến mãi</h3>
                        <span>{ VND.format(cartItem.discount) || 0}</span>
                    </div>
                    <div className='total-info'>
                        <h3>Giao hàng</h3>
                        <span>Giao hàng miễn phí</span>
                    </div>
                    <div className='total-info'>
                        <h3>Tổng </h3>
                        <span>{ VND.format(cartItem.total-cartItem.discount)}</span>
                    </div>
                    <div className='payment-submit'>
                        <div className='payment-type'>
                            <input type='radio' checked={ true} />
                            <label>Trả tiền mặt khi nhận hàng</label>
                        </div>
                        <div className='payment-type'>
                            <input type='radio' checked={ false} />
                            <label>Chuyển khoản ngân hàng</label>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    )
}

export default Payment
