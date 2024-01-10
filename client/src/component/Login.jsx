import { useFormik } from 'formik';
import React, { useState } from 'react'
import authApi from '../service/AuthService';
import { toast } from 'react-toastify';
import Cookies from 'js-cookie';
function Login({resetPage}) {

    const [activeTab, setActiveTab] = useState('login');

    const handleSubmit = async (values) => {
        await authApi.login(values).then(result => {
            if (result.success) {
                return toast.success("Đăng nhập thành công");
            } else {
                return toast.error("Đăng nhập thất bại");
            }
        })
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            Email: '',
            Password: '',
            DisplayName: '',
            Password: '',
            PasswordConfirm: '',
            Address: '',
            Phone: '',
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleRegister = async (values) => {
        console.log(values)
        if (values.Password !== values.PasswordConfirm) {
            return toast.error("Không trùng khớp mật khẩu");
        }
        if (!values.DisplayName || !values.Email || !values.Password) {
            return toast.error("Thông tin đăng kí không hợp lệ");
        }
        authApi.register(values).then(result => {
            if (result.user.success) {
                formik.resetForm();
                return toast.success("Đăng kí người dùng thành công!!");


            }
            else {
                return toast.error("Đăng kí người dùng thất bại. " + result.user.message);
            }
        })
    }
    const customer = JSON.parse(localStorage.getItem('CustomerInfo'));
    const handleLogout = () => {
        Cookies.remove('customer');
        localStorage.removeItem('CustomerInfo');
        localStorage.removeItem('usercart');
        toast.success("Đăng xuất thành công");
    }
    return (
        <div className='login-container'>
            {
                !!customer ?
                    <>
                        <div className='login-input'>
                            <h4>{ `Xin chào ${customer.displayName}`}</h4>
                            <button onClick={()=>handleLogout()}>Đăng xuất</button>
                        </div>
                    </>
                    :
                    <>
                        <div className={`login-type ${activeTab === 'login' ? '' : 'div-hide'}`} >
                            <div className='login-header'>
                                <h2>ĐĂNG NHẬP TÀI KHOẢN</h2>
                                <span>Nhập email và mật khẩu của bạn:</span>
                            </div>
                            <div className='login-input'>
                                <input placeholder='Email' onChange={formik.handleChange} name='Email' type='Email' />
                                <input placeholder='Mật khẩu' onChange={formik.handleChange} name='Password' type='password' />
                                <span>This site is protected by reCAPTCHA and the Google <a href='https://policies.google.com/privacy'>Privacy Policy</a > and <a href='https://policies.google.com/terms'>Terms of Service</a > apply.</span>
                                <button onClick={formik.handleSubmit}>Đăng nhập</button>
                            </div>
                            <div className='login-footer'>
                                <span>Khách hàng mới? &nbsp;<strong onClick={() => setActiveTab('register')}>Tạo tài khoản</strong></span>
                                <span>Quên mật khẩu? &nbsp;<strong onClick={() => setActiveTab('forgot-password')}>Khôi phục mật khẩu</strong></span>
                            </div>
                        </div>
                        <div className={`register-type ${activeTab === 'register' ? '' : 'div-hide'}`}>
                            <div className='login-header'>
                                <h2>Đăng kí tài khoản</h2>
                                <span>Nhập các thông tin:</span>
                            </div>
                            <div className='login-input'>
                                <input placeholder='Tên hiển thị' name='DisplayName' onChange={formik.handleChange} value={formik.values.DisplayName} />
                                <input placeholder='Email' name='Email' type='email' onChange={formik.handleChange} value={formik.values.Email} />
                                <input placeholder='Số điện thoại' name='Phone' onChange={formik.handleChange} value={formik.values.Phone} />
                                <input placeholder='Địa chỉ' name='Address' onChange={formik.handleChange} value={formik.values.Address} />
                                <input placeholder='Mật khẩu' name='Password' type='password' onChange={formik.handleChange} value={formik.values.Password} />
                                <input placeholder='Nhập lại mật khẩu' name='PasswordConfirm' type='password' onChange={formik.handleChange} value={formik.values.PasswordConfirm} />
                                <span>This site is protected by reCAPTCHA and the Google <a href='https://policies.google.com/privacy'>Privacy Policy</a > and <a href='https://policies.google.com/terms'>Terms of Service</a > apply.</span>
                                <button onClick={() => handleRegister(formik.values)}>Đăng nhập</button>
                            </div>
                            <div className='login-footer'>
                                <span>Đã có tài khoản? &nbsp;<strong onClick={() => setActiveTab('login')}>Đăng nhập</strong></span>
                            </div>
                        </div>
                        <div className={`forgot-password-type ${activeTab === 'forgot-password' ? '' : 'div-hide'}`}>
                            <div className='login-header'>
                                <h2>KHÔI PHỤC MẬT KHẨU</h2>
                                <span>Nhập email của bạn:</span>
                            </div>
                            <div className='login-input'>
                                <input placeholder='Email' />
                                <span>This site is protected by reCAPTCHA and the Google <a href='https://policies.google.com/privacy'>Privacy Policy</a > and <a href='https://policies.google.com/terms'>Terms of Service</a > apply.</span>
                                <button>Khôi phục</button>

                            </div>
                            <div className='login-footer'>
                                <span>Bạn đã nhớ mật khẩu? <strong onClick={() => setActiveTab('login')}>Trở về đăng nhập</strong></span>
                            </div>
                        </div>
                    </>
            }
        </div>
    )
}

export default Login
