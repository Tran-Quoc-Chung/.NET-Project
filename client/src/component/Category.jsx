import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCaretDown } from '@fortawesome/free-solid-svg-icons'
function Category() {
    const [toggle,setToggle]=useState(false)
    return (
        <div className='category-container'>
            <div className='filter-category '>
                <h3>Danh mục sản phẩm</h3>
                <div className='list-filter'>
                    <ul>
                        <li><a>Đồng hồ nam</a></li>
                        <li><a>Đồng hồ nữ</a></li>
                        <li><a>Đồng hồ đôi</a></li>
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
                        <li><a>Trên 15 triệu</a></li>
                        <li><a>Từ 10 đến 15 triệu</a></li>
                        <li><a>Từ 5 đến 10 triệu</a></li>
                        <li><a>Dưới 5 triệu</a></li>
                        
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>thương hiệu phổ biến</h3>
                <div className='list-filter'>
                    <ul>
                        <li><a>Casio</a></li>
                        <li><a>Louis Erard</a></li>
                        <li><a>Seiko</a></li>
                    </ul>
                </div>
            </div>
            <div className='filter-category '>
                <h3>CHẤT LIỆU DÂY</h3>
                <div className='list-filter'>
                    <ul>
                        <li><a>Dây Da</a></li>
                        <li><a>Dây Kim Loại</a></li>
                        <li><a>Dây Nhựa / Cao Su</a></li>
                        <li><a>Dây Vải</a></li>
                        
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
