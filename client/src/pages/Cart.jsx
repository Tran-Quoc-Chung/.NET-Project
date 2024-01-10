import React, { useEffect, useState } from 'react'
import { faTrash, faTag } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Cookies from 'js-cookie'
import authApi from '../service/AuthService'
import { VND } from '../utils/validateField'
import { toast } from 'react-toastify'
import { setCart } from '../features/CartSlice'
import { useDispatch } from 'react-redux'

function Cart() {
    const [cartItem, setCartItem] = useState([]);
    const [discount, setDiscount] = useState(0);
    const [totalInvoice, setTotalInvoice] = useState(0);
    const [voucherCode, setVoucherCode] = useState();
    const dispatch =useDispatch()
    useEffect(() => {
        const fetchData = async () => {
            const token = Cookies.get('customer');
            if (!token) return;
            authApi.getCustomerCart().then(result => {
                if (result.success) {
                    if (!!result.data.listProduct.length > 0) {
                        setCartItem(result.data.listProduct);
                    } else {
                        setCartItem([])
                    }
                } else {
                    setCartItem([])
                }
            })
        };
        fetchData();
    }, []);
    useEffect(() => {
        let calculatedTotal = 0;

        cartItem.forEach(item => {
            calculatedTotal += item.quantity * item.price;
        });

        // Apply discount
        // calculatedTotal -= discount;

        setTotalInvoice(calculatedTotal);
        const cartInfo = {
            total: totalInvoice,
            discount: discount,
            voucherCode: voucherCode,
            cartItem: cartItem
        }
        localStorage.setItem('usercart', JSON.stringify(cartInfo));
        
    }, [cartItem, discount]);
    
    const handleRemoveCartItem = (id) => {
        authApi.removeCartItem(id).then(result => {
            if (result.success) {
                toast.success("Xóa sản phẩm khỏi giỏ hàng thành công");
                authApi.getCustomerCart().then(result => {
                    if (result.success) {
                        if (!!result.data.listProduct.length > 0) {
                            setCartItem(result.data.listProduct);
                        } else {
                            setCartItem([])
                        }
                    }
                })
            }
        })
    };
    const handleUpdateCartItem = (id, newQuantity) => {
        const updatedCart = cartItem.map(item => {
            if (item.productId === id) {
                return { ...item, quantity: newQuantity, total: newQuantity * item.price };
            } else {
                return item;
            }
        });
        setCartItem(updatedCart);
    }
    const handleUsingVoucher = (voucherCode) => {
        authApi.usingVoucher(voucherCode).then(result => {
            if (result.success)
            {
                toast.success("Áp dụng khuyến mãi thành công")
                setDiscount(result.data.discount);
            }
            else {
                return toast.error("Không thể áp dụng khuyến mãi");
            }
        })
    }
     
    return (
        <div className='cart-container'>
            <div className='cart-product'>
                <table>
                    <thead>
                        <tr>
                            <th className='th-product'>Sản phẩm</th>
                            <th className='th-price'>Giá</th>
                            <th className='th-quantity'>Số lượng</th>
                            <th className='th-total'>Tổng</th>
                        </tr>
                    </thead>
                    <tbody>
                        {cartItem && cartItem.map(item => (
                            <tr>
                            <td className='td-product'>
                                <td className='trash' ><FontAwesomeIcon icon={faTrash} onClick={()=>handleRemoveCartItem(item.productId)}/></td>
                                <td className='image'><img src={item.image} /></td>
                                <td className='name'><a>{item.productName}</a> </td>
                            </td>
                                <td className='td-price'><span>{ VND.format(item.price)}</span></td>
                            <td className='td-quantity'><input type='number' min={1} defaultValue={item.quantity} onChange={(e)=>handleUpdateCartItem(item.productId, e.target.value)}/></td>
                                <td className='td-total'><span>{ VND.format(item.quantity * item.price)}</span></td>
                        </tr>
                       ))}

                    </tbody>
                </table>
            </div>
            <div className='cart-total'>
                <table>
                    <thead>
                        <tr>
                            <th className='th-title' >Tổng giỏ hàng</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr className='cart-subtotal'>
                            <th>Tổng phụ</th>
                            <td><span>{ VND.format(totalInvoice)}</span></td>
                            
                        </tr>
                        <tr className='cart-shipping'>
                            <th>Giao hàng</th>
                            <td>
                                Giao hàng miễn phí
                            </td>
                        </tr>
                        <tr className=''>
                            <th>Voucher</th>
                            <td>
                                <span>{ VND.format(discount*totalInvoice)}</span>
                            </td>
                        </tr>
                        <tr className='order-total'>
                            <th>Tổng</th>
                            <td><span>{ VND.format(totalInvoice-(discount*totalInvoice))}</span></td>
                        </tr>
                    </tbody>
                </table>
                <div className='button-submit'>
                    <button><a href='/user/payment'>tiến hành thanh toán</a></button>
                </div>
                <div className='cart-voucher'>
                    <div className='voucher-title'>
                        <FontAwesomeIcon icon={faTag} rotation={90} />
                        <span>Phiếu ưu đãi</span>
                    </div>
                    <div className='voucher-content'>
                        <input placeholder='Mã ưu đãi' onChange={(e)=>setVoucherCode(e.target.value)} value={voucherCode} />
                        <button onClick={()=>handleUsingVoucher(voucherCode)}>Áp dụng</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Cart
