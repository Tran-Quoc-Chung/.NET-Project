import React from 'react'
import Category from '../component/Category'
import ProductList from '../component/ProductList'

function AccessoryWatch() {
    
    return (
        <div className='product-container'>
            <div className='page-title'>
                <div className='title-category'>
                    <span><a href='localhost:4000'>Trang chủ / </a></span>
                    <span>Phụ kiện</span>
                </div>
                <div className='title-filter'>
                    <span>Hiển thị một kết quả duy nhất</span>
                    <select>
                        <option value="1">Thứ tự mặc định</option>
                        <option value="1">Thứ tự theo mức độ phổ biến</option>
                        <option value="1">Thứ tự theo điểm đánh giá</option>
                        <option value="1">Mới nhất</option>
                        <option value="1">Thứ tự theo giá: thấp đến cao</option>
                        <option value="1">Thứ tự theo giá: cao xuống thấp</option>
                    </select>
                </div>
            </div>
            <div className='page-content'>
            <div className='page-category'>
                <Category />
            </div>
            <div className='page-productlist'>
                    <ProductList />
                    <div className='view-more div-hide' >
                        <a>
                            Xem thêm <span>5</span> sản phẩm 
                        </a>
                    </div>
            </div>
            </div>
        </div>
    )
}

export default AccessoryWatch
