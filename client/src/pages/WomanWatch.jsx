import React, { useEffect, useState } from 'react'
import Category from '../component/Category'
import ProductList from '../component/ProductList'
import productApi from '../service/ProductService';


function WomanWatch() {
    const [product, setProduct] = useState([]);
    const [showMore, setShowMore] = useState();
    useEffect(() => {
        fetchData();
    }, []);

    const modelSearch = {
        Page: 1,
        Gender: 2,
        Price: null,
        Sort:null
    }
    const fetchData = async () => {
        await productApi.getAll(modelSearch).then(result => {
            setProduct(result.data.productList)
            setShowMore(result.data.remainProduct)
        });
    }
    return (
        <div className='product-container'>
            <div className='page-title'>
                <div className='title-category'>
                    <span><a href='localhost:4000'>Trang chủ / </a></span>
                    <span>Đồng hồ nữ</span>
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
                    {
                        product && <>
                            <ProductList product={product} />
                            <div className={`view-more ${showMore <= 0  ? `div-hide` : '' }`} >
                                <a>
                                    Xem thêm <span>{ showMore > 8 ? 8 : 0 }</span> sản phẩm
                                </a>
                            </div>
                        </>
                    }

                </div>
            </div>
        </div>
    )
}

export default WomanWatch
