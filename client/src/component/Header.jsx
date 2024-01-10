import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faFacebook, faTwitter, faInstagram, faThinkPeaks } from '@fortawesome/free-brands-svg-icons';
import { faCartShopping, faMagnifyingGlass, faTrashCan, faCaretUp } from '@fortawesome/free-solid-svg-icons'
import logo from '../public/images/logoheader.png';
import hotline from '../public/images/hotline.gif'
import Login from './Login';
import { useNavigate } from 'react-router-dom';
import { useFormik } from 'formik'
import authApi from '../service/AuthService';
import Cookies from 'js-cookie';
import { useEffect } from 'react';
import {VND} from '../utils/validateField'
import { toast } from 'react-toastify';
import { useDispatch } from 'react-redux';
import { setCart } from '../features/CartSlice';
function Header() {
    const navigate = useNavigate();
    const [isLogin, setIsLogin] = useState(false);
    const [userInfo, setUserInfo] = useState();
    const [userCart, setUserCart] = useState();
    let cartTotal=0;
    const handleRollBackHome = () => {
        navigate('/')
    }
    useEffect(() => {
        const fetchData = async () => {
            const token = Cookies.get('customer');
            if (token) {
                authApi.getInfo().then(result => {
                    if (result.success) {
                        var userData = JSON.stringify(result.data);
                        localStorage.setItem('CustomerInfo', userData);
                        setUserInfo(result.data);
                        authApi.getCustomerCart().then(result => {
                            if (result.success) {
                                if (!!result.data.listProduct.length>0) {
                                    setUserCart(result.data.listProduct);
                                } else {
                                    setUserCart([])
                                }
                            }
                        })
                    }
                    else {
                        localStorage.removeItem('CustomerInfo')
                    }
                })
            } else {
                localStorage.removeItem('CustomerInfo')
            }
        }
        fetchData()
    }, []);
    const handleRemoveCartItem = async (productId) => {
        await authApi.removeCartItem(productId).then(result => {
            if (result.success) {
                toast.success("Xóa sản phẩm khỏi giỏ hàng thành công");
                authApi.getCustomerCart().then(result => {
                    if (result.success) {
                        if (!!result.data.listProduct.length>0) {
                            setUserCart(result.data.listProduct);
                        } else {
                            setUserCart([])
                        }
                    }
                })
            } else {
                toast.error("Xóa sản phẩm khỏi giỏ hàng thất bại");
            }
        })
    }
        userCart && userCart.forEach(item => {
            cartTotal=item.price+cartTotal
        });
    const resetHeader = () => {
        setUserInfo(null);
        setUserCart(null);

    }
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
                    <img src={logo} alt='not fount' onClick={handleRollBackHome} />
                </div>
                <div className='logo-userinfo'>
                    <ul className='userinfo-ul' >
                        <li onClick={() => setIsLogin(!isLogin)}>{!!userInfo ? userInfo.displayName : 'Đăng nhập '}</li>
                        <li><a href='/user/cart'>Giỏ hàng / { VND.format(cartTotal ||0 )}</a></li>
                        <div className={`drop-login ${isLogin ? '' : 'div-hide'}`} >

                            <span className='caret-up'><FontAwesomeIcon icon={faCaretUp} style={{ color: "#ffffff", }} /></span>
                            <Login resetPage={ resetHeader} />
                        </div>
                    </ul>
                    <div className='logo-cart'>
                        <div class='cart-icon'>
                            <FontAwesomeIcon icon={faCartShopping} />
                            <div class='item-count'>{ userCart && userCart.length > 0 ? userCart.length : 0  }</div>
                        </div>
                        <div className='drop-cart'>
                            <ul>
                                {userCart && userCart.map(item => (
                                    <li>
                                    <div className='li-image'>
                                        <img src={item.image} alt='not found' />
                                    </div>
                                    <div className='li-content'>
                                        <h4>{item.productName}</h4>
                                        <div className='content-price'>
                                            <span>{item.quantity} &nbsp;</span>
                                            <span>x &nbsp;</span>
                                                <h4>{ VND.format(item.price)} </h4>
                                        </div>
                                    </div>
                                    <div className='li-trash'>
                                        <button onClick={()=>handleRemoveCartItem(item.productId)}>{<FontAwesomeIcon icon={faTrashCan} />}</button>
                                    </div>
                                </li>
                               ))}

                            </ul>
                            <div className='drop-total'>
                                <span>Tổng phụ:&nbsp; </span>
                                <h4>{ VND.format(cartTotal || 0 )}</h4>
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
