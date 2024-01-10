import React, { useState,useEffect } from 'react'
import Category from '../component/Category'
import ProductList from '../component/ProductList'
import productApi from '../service/ProductService';

function MenWatch() {
    const [product, setProduct] = useState([]);
    const [showMore, setShowMore] = useState();
    const [modelSearch,setModelSearch]=useState({ Page: 1, Gender: 1,})
    useEffect(() => {
        fetchData();
    }, [modelSearch]);
    
    const fetchData = async () => {
        await productApi.getAll(modelSearch).then(result => {
            setProduct(result.data.productList)
            setShowMore(result.data.remainProduct)
        });
    }
    const handleSetPage = () => {
        setModelSearch({
            ...modelSearch,
            Page: modelSearch.Page +1
        });
    }
    const handleSetSort = (id) => {
        setModelSearch({
            ...modelSearch,
            Sort: id
        });
    }
    const handleSetPrice = (number) => {
        setModelSearch({
            ...modelSearch,
            Price: number
        });
    }
    const handleSetBrand = (idBrand) => {
        setModelSearch({
            ...modelSearch,
            Brand: idBrand
        });
    }
    const handleSetStrapMaterial = (id) => {
        setModelSearch({
            ...modelSearch,
            StrapMaterial: id
        });
    }
    return (
        <div className='product-container'>
            <div className='page-title'>
                <div className='title-category'>
                    <span><a href='/'>Trang chủ / </a></span>
                    <span>Đồng hồ nam</span>
                </div>
                <div className='title-filter'>
                    <span>Hiển thị một kết quả duy nhất</span>
                    <select onClick={(e)=>handleSetSort(e.target.value)}>
                        <option value="0">Thứ tự mặc định</option>
                        <option value="1">Thứ tự theo mức độ phổ biến</option>
                        <option value="2">Thứ tự theo điểm đánh giá</option>
                        <option value="3">Mới nhất</option>
                        <option value="4">Thứ tự theo giá: thấp đến cao</option>
                        <option value="5">Thứ tự theo giá: cao xuống thấp</option>
                    </select>
                </div>
            </div>
            <div className='page-content'>
            <div className='page-category'>
                    <Category handleSetPrice={handleSetPrice} handleSetBrand={ handleSetBrand} handleSetStrapMaterial={handleSetStrapMaterial} />
            </div>
            <div className='page-productlist'>
                    <ProductList product={ product} />
                    <div className={`view-more ${showMore <= 0  ? `div-hide` : '' }`} onClick={()=>handleSetPage()} >
                        <a>
                            Xem thêm <span>{ showMore > 8 ? 8 : showMore }</span> sản phẩm 
                        </a>
                    </div>
            </div>
            </div>
        </div>
    )
}

export default MenWatch
