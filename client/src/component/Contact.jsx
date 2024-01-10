import React from 'react'

function Contact() {
  return (
    <div className='contact-container'>
          <div className='contact-content'>
              <div className='first-content'>
                  <h2>Tư vấn mua hàng</h2>
                  <p>Hãy liên hệ ngay để được tư vấn mua hàng một cách tận tình từ đội ngũ nhân viên chuyên nghiệp của chúng tôi</p>
                  <button>Liên hệ</button>
        </div>
        
              <div className='last-content'>
                  <span>Đăng ký nhận thông tin từ chúng tôi</span>
                  <div className='contact'>
                      <input placeholder='Email'></input>
                      <button>ĐĂNG KÍ</button>
                  </div>
              </div>
      </div>
    </div>
  )
}

export default Contact
