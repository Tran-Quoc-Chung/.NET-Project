import React, { useState } from 'react'

function Login() {
    const [activeTab,setActiveTab]=useState('login')
    return (
        <div className='login-container'>
            <div className={`login-type ${activeTab === 'login' ? '' : 'div-hide'}`} >
                <div className='login-header'>
                    <h2>ĐĂNG NHẬP TÀI KHOẢN</h2>
                    <span>Nhập email và mật khẩu của bạn:</span>
                </div>
                <div className='login-input'>
                    <input placeholder='Email' />
                    <input placeholder='Mật khẩu' />
                    <span>This site is protected by reCAPTCHA and the Google <a href='https://policies.google.com/privacy'>Privacy Policy</a > and <a href='https://policies.google.com/terms'>Terms of Service</a > apply.</span>
                    <button>Đăng nhập</button>
                </div>
                <div className='login-footer'>
                    <span>Khách hàng mới? &nbsp;<strong onClick={()=>setActiveTab('register')}>Tạo tài khoản</strong></span>
                    <span>Quên mật khẩu? &nbsp;<strong onClick={()=>setActiveTab('forgot-password')}>Khôi phục mật khẩu</strong></span>
                </div>
            </div>
            <div className={`register-type ${activeTab === 'register' ? '' : 'div-hide'}`}>
                <div className='login-header'>
                    <h2>Đăng kí tài khoản</h2>
                    <span>Nhập các thông tin:</span>
                </div>
                <div className='login-input'>
                    <input placeholder='Họ'/>
                    <input placeholder='Tên'/>
                    <input placeholder='Email'/>
                    <input placeholder='Mật khẩu' />
                    <input placeholder='Nhập lại mật khẩu' />
                    <span>This site is protected by reCAPTCHA and the Google <a href='https://policies.google.com/privacy'>Privacy Policy</a > and <a href='https://policies.google.com/terms'>Terms of Service</a > apply.</span>
                    <button>Đăng nhập</button>
                </div>
                <div className='login-footer'>
                <span>Đã có tài khoản? &nbsp;<strong onClick={()=>setActiveTab('login')}>Đăng nhập</strong></span>
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
                    <span>Bạn đã nhớ mật khẩu? <strong onClick={()=>setActiveTab('login')}>Trở về đăng nhập</strong></span>
                </div>
            </div>
        </div>
    )
}

export default Login
