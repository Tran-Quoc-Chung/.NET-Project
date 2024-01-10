import React, { useState,useEffect }  from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCaretDown } from '@fortawesome/free-solid-svg-icons'
import categoryApi from '../service/CategoryService'
function Category({handleSetPrice,handleSetBrand,handleSetStrapMaterial}) {
    const [toggle, setToggle] = useState(false)
    const [brand, setBrand] = useState([]);
    const [strapMaterial, setStrapMaterial] = useState([]);
    const fetchData = async () => {
        await categoryApi.getAllBrand().then(result => {
            setBrand(result.data)
        });
        await categoryApi.getAllStrapMaterial().then(result => {
            setStrapMaterial(result.data)
        });

    }
    useEffect(() => {
       fetchData() 
    },[])
    return (
        <div className='category-container'>
            <div className='filter-category '>
                <h3>Danh mục sản phẩm</h3>
                <div className='list-filter'>
                    <ul>
                        <li><a href='/product/men-watch'>Đồng hồ nam</a></li>
                        <li><a href='/product/woman-watch'>Đồng hồ nữ</a></li>
                        <li><a href='/product/couple-watch'>Đồng hồ đôi</a></li>
                        <li className='list-child'>
                            <div className='li-text'>
                                <a>Phụ kiện</a>
                                <span onClick={()=>setToggle(!toggle)} className={`${toggle ? 'isOpen' : ' '}`}><FontAwesomeIcon icon={faCaretDown}  /></span>
                            </div>
                            <ul className={`list-filter-child ${toggle ? 'isOpen' : ' '}`}>
                                <li>Dây Da Hirsch</li>
                                <li>Dây Da ZRC</li>
                                <li>Hộp Đồng Hồ</li>
                                <li>Khắc Laser Lên Đồng Hồ</li>

                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>lọc theo giá</h3>
                <div className='list-filter'>
                    <ul>
                        <li><a onClick={()=>handleSetPrice(1)}>Trên 15 triệu</a></li>
                        <li><a onClick={()=>handleSetPrice(2)}>Từ 10 đến 15 triệu</a></li>
                        <li><a onClick={() => handleSetPrice(3)}>Từ 5 đến 10 triệu</a></li>
                        <li><a onClick={()=>handleSetPrice(4)}>Dưới 5 triệu</a></li>
                        
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>thương hiệu phổ biến</h3>
                <div className='list-filter'>
                    <ul>
                        {
                            brand && brand.map(item => (
                                <li><a onClick={()=>handleSetBrand(item.brandID)}>{item.brandName}</a></li>
                            ))
                        }
                        {/* <li><a>Casio</a></li>
                        <li><a>Louis Erard</a></li>
                        <li><a>Seiko</a></li> */}
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>CHẤT LIỆU DÂY</h3>
                <div className='list-filter'>
                    <ul>
                    {
                            strapMaterial && strapMaterial.map(item => (
                                <li><a onClick={()=>handleSetStrapMaterial(item.strapMaterialID)}>{item.strapMaterialName}</a></li>
                            ))
                        }
                        {/* <li><a>Dây Da</a></li>
                        <li><a>Dây Kim Loại</a></li>
                        <li><a>Dây Nhựa / Cao Su</a></li>
                        <li><a>Dây Vải</a></li> */}
                        
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>Bài viết mới nhất</h3>
                <div className='list-filter list-blog'>
                    <ul>
                        <li>
                            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/03/banner-1200x630-150x150.jpg' />
                            <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus deserunt perspiciatis cumque odio pariatur et atque, qui animi? Vitae sit, officia quae velit temporibus eligendi perferendis hic consequuntur saepe aspernatur!</span>
                        </li>
                        <li>
                            <img src='	https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/03/banner-1200x630-150x150.jpg' />
                            <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus deserunt perspiciatis cumque odio pariatur et atque, qui animi? Vitae sit, officia quae velit temporibus eligendi perferendis hic consequuntur saepe aspernatur!</span>
                        </li>
                        <li>
                            <img src='	https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/03/banner2-1200x630-150x150.jpg' />
                            <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus deserunt perspiciatis cumque odio pariatur et atque, qui animi? Vitae sit, officia quae velit temporibus eligendi perferendis hic consequuntur saepe aspernatur!</span>
                        </li>
                        <li>
                            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/04/bg-unnamed-150x150.jpg' />
                            <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus deserunt perspiciatis cumque odio pariatur et atque, qui animi? Vitae sit, officia quae velit temporibus eligendi perferendis hic consequuntur saepe aspernatur!</span>
                        </li>
                        
                        
                    </ul>
                </div>
            </div>
            

        </div>
    )
}

export default Category
