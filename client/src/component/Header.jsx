import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faFacebook, faTwitter, faInstagram, faThinkPeaks } from '@fortawesome/free-brands-svg-icons';
import { faCartShopping, faMagnifyingGlass, faTrashCan,faCaretUp } from '@fortawesome/free-solid-svg-icons'
import logo from '../public/images/logoheader.png';
import watch1 from '../public/images/watch1.jpg';
import watch2 from '../public/images/watch2.jpg';
import watch3 from '../public/images/watch3.jpg';
import watch4 from '../public/images/watch4.jpg';
import hotline from '../public/images/hotline.gif'
import Login from './Login';
function Header() {
    const [isLogin, setIsLogin]=useState(false)
    return (
        <div className='container-header'>
            <div className='header-info'>
                <div className=' info-slogan'>
                    <span>{<FontAwesomeIcon icon={faThinkPeaks} size="2xl" />} &nbsp;&nbsp;&nbsp; Đồng hồ - Điểm nhấn của thời gian.</span>
                </div>
                <div className='info-contact'>
                    <img src={hotline} alt='not found' />
                    <span> Hotline: 1900 68 68</span>
                    <ul>
                        <li><FontAwesomeIcon icon={faFacebook} /></li>
                        <li><FontAwesomeIcon icon={faTwitter} /></li>
                        <li><FontAwesomeIcon icon={faInstagram} /></li>
                    </ul>
                </div>
            </div>
            <div className='header-logo'>
                <div className='img-logo'>
                    <img src={logo} alt='not fount' />
                </div>
                <div className='logo-userinfo'>
                    <ul className='userinfo-ul' >
                        <li onClick={()=>setIsLogin(!isLogin)}>Đăng nhập</li>
                        <li><a href='/user/cart'>Giỏ hàng / 0đ</a></li>
                        <div className={`drop-login ${isLogin ? '' : 'div-hide'}`} >
                            
                        <span className='caret-up'><FontAwesomeIcon icon={faCaretUp} style={{color: "#ffffff",}} /></span>
                            <Login/>
                        </div>
                    </ul>
                    <div className='logo-cart'>
                        <div class='cart-icon'>
                            <FontAwesomeIcon icon={faCartShopping} />
                            <div class='item-count'>1</div>
                        </div>
                        <div className='drop-cart'>
                            <ul>
                                <li>
                                    <div className='li-image'>
                                        <img src={watch1} alt='not found' />
                                    </div>
                                    <div className='li-content'>
                                        <h4>OMEGA 234.10.39.20.01.001 SEAMASTER 39MM</h4>
                                        <div className='content-price'>
                                            <span>1 &nbsp;</span>
                                            <span>x &nbsp;</span>
                                            <h4>18.999.999 &nbsp; <u>đ</u></h4>
                                        </div>
                                    </div>
                                    <div className='li-trash'>
                                        <button>{<FontAwesomeIcon icon={faTrashCan} />}</button>
                                    </div>
                                </li>
                                <li>
                                    <div className='li-image'>
                                        <img src={watch2} alt='not found' />
                                    </div>
                                    <div className='li-content'>
                                        <h4>LONGINES MASTER L2.628.5.77.7 WATCH 38.5MM</h4>
                                        <div className='content-price'>
                                            <span>1 &nbsp;</span>
                                            <span>x &nbsp;</span>
                                            <h4>12.999.999 &nbsp; <u>đ</u></h4>
                                        </div>
                                    </div>
                                    <div className='li-trash'>
                                        <button>{<FontAwesomeIcon icon={faTrashCan} />}</button>
                                    </div>
                                </li>
                                
                                <li>
                                    <div className='li-image'>
                                        <img src={watch3} alt='not found' />
                                    </div>
                                    <div className='li-content'>
                                        <h4>FOSSIL ME3104 TOWNSMAN AUTOMATIC LEATHER WATCH 44MM</h4>
                                        <div className='content-price'>
                                            <span>1 &nbsp;</span>
                                            <span>x &nbsp;</span>
                                            <h4>20.000.000 &nbsp; <u>đ</u></h4>
                                        </div>
                                    </div>
                                    <div className='li-trash'>
                                        <button>{<FontAwesomeIcon icon={faTrashCan} />}</button>
                                    </div>
                                </li>
                                <li>
                                    <div className='li-image'>
                                        <img src={watch4} alt='not found' />
                                    </div>
                                    <div className='li-content'>
                                        <h4>FREDERIQUE CONSTANT FC-312V4S4 SLIMLINE AUTO WATCH 40MM</h4>
                                        <div className='content-price'>
                                            <span>1 &nbsp;</span>
                                            <span>x &nbsp;</span>
                                            <h4>16.999.999 &nbsp; <u>đ</u></h4>
                                        </div>
                                    </div>
                                    <div className='li-trash'>
                                        <button>{<FontAwesomeIcon icon={faTrashCan} />}</button>
                                    </div>
                                </li>
                            </ul>
                            <div className='drop-total'>
                                <span>Tổng phụ:&nbsp; </span>
                                <h4>18.999.999 <u>đ</u></h4>
                            </div>
                            <div className='drop-button'>
                                <a href='/user/cart'>Xem giỏ hàng</a>
                                <a href='/user/payment'>Thanh toán</a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div className='header-taskbar'>
                <ul>
                    <li><a href='/product/woman-watch'>đồng hồ nữ</a></li>
                    <li><a href='http://localhost:4000/product/men-watch'>đồng hồ nam</a></li>
                    <li><a href='/product/couple-watch'>đồng hồ cặp đôi</a></li>
                    <li><a href='/product/popular-watch'>sản phẩm hot</a></li>
                    <li><a href='/product/accessory-watch'>phụ kiện</a></li>
                </ul>
                <div className='taskbar-search'>
                    <input placeholder='Tìm kiếm...'></input>
                    <button>{<FontAwesomeIcon icon={faMagnifyingGlass} />}</button>
                </div>
            </div>

        </div>
    )
}

export default Header
