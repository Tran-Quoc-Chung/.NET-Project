import React from 'react'
import { useFormik } from 'formik'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function Payment() {
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
        validate,
        onSubmit: values => {
            if (validate===true) {
                toast.success("Payment successully")
            }
        }
    })
    return (
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
                            onChange={formik.handleChange}
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
                        <tr>
                            <td className='product-name'>BIG BANG 465.OS.1118.VR.1704.MXM18 SANG BLEU 39 <strong>× 1</strong></td>
                            <td className='product-price'><span>739,370,000 &nbsp;₫</span></td>
                        </tr>
                    </tbody>
                </table>
                <div className='payment-total'>
                    <div className='total-info'>
                        <h3>Tổng phụ</h3>
                        <span>751,900,000  &nbsp;₫</span>
                    </div>
                    <div className='total-info'>
                        <h3>Khuyến mãi</h3>
                        <span>1,900,000  &nbsp;₫</span>
                    </div>
                    <div className='total-info'>
                        <h3>Giao hàng</h3>
                        <span>Giao hàng miễn phí</span>
                    </div>
                    <div className='total-info'>
                        <h3>Tổng </h3>
                        <span>751,900,000  &nbsp;₫</span>
                    </div>
                    <div className='payment-submit'>
                        <div className='payment-type'>
                            <input type='radio' />
                            <label>Trả tiền mặt khi nhận hàng</label>
                        </div>
                        <div className='payment-type'>
                            <input type='radio' />
                            <label>Chuyển khoản ngân hàng</label>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    )
}

export default Payment
