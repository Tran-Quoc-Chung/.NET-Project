import React from 'react'
import { faTrash, faTag } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import watch4 from '../public/images/watch4.jpg'
import watch3 from '../public/images/watch3.jpg'
import watch2 from '../public/images/watch2.jpg'

function Cart() {
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
                        <tr>
                            <td className='td-product'>
                                <td className='trash'><FontAwesomeIcon icon={faTrash} /></td>
                                <td className='image'><img src={watch4} /></td>
                                <td className='name'><a>VERSACE VANITAS ROSE GOLD WATCH 40MM</a> </td>
                            </td>
                            <td className='td-price'><span>38,100,000 &nbsp;₫</span></td>
                            <td className='td-quantity'><input type='number' value={2} /></td>
                            <td className='td-total'><span>76,200,000&nbsp;₫</span></td>
                        </tr>
                        <tr>
                            <td className='td-product'>
                                <td className='trash'><FontAwesomeIcon icon={faTrash} /></td>
                                <td className='image'><img src={watch3} /></td>
                                <td className='name'><a>VERSACE VANITAS ROSE GOLD WATCH 40MM</a> </td>
                            </td>
                            <td className='td-price'><span>38,100,000 &nbsp;₫</span></td>
                            <td className='td-quantity'><input type='number' value={2} /></td>
                            <td className='td-total'><span>76,200,000&nbsp;₫</span></td>
                        </tr>
                        <tr>
                            <td className='td-product'>
                                <td className='trash'><FontAwesomeIcon icon={faTrash} /></td>
                                <td className='image'><img src={watch2} /></td>
                                <td className='name'><a>VERSACE VANITAS ROSE GOLD WATCH 40MM</a> </td>
                            </td>
                            <td className='td-price'><span>38,100,000 &nbsp;₫</span></td>
                            <td className='td-quantity'><input type='number' value={2} /></td>
                            <td className='td-total'><span>76,200,000&nbsp;₫</span></td>
                        </tr>
                        <tr>
                            <td className='td-product'>
                                <td className='trash'><FontAwesomeIcon icon={faTrash} /></td>
                                <td className='image'><img src={watch4} /></td>
                                <td className='name'><a>VERSACE VANITAS ROSE GOLD WATCH 40MM</a> </td>
                            </td>
                            <td className='td-price'><span>38,100,000 &nbsp;₫</span></td>
                            <td className='td-quantity'><input type='number' value={2} /></td>
                            <td className='td-total'><span>76,200,000&nbsp;₫</span></td>
                        </tr>
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
                            <td><span>88,730,000 &nbsp;₫</span></td>
                            
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
                                <span>10,123,000 &nbsp;₫</span>
                            </td>
                        </tr>
                        <tr className='order-total'>
                            <th>Tổng</th>
                            <td><span>78,730,000 &nbsp;₫</span></td>
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
                        <input placeholder='Mã ưu đãi' />
                        <button>Áp dụng</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Cart
