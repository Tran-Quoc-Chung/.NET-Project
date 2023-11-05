import React from 'react'
import { useNavigate } from 'react-router-dom'

function ProductList(props) {
  const { title, product } = props;
  const navigate = useNavigate();
  const handleClickProduct = () => {
    navigate('/product/product-detail/1')
  }
  return (
    <div className='home-product-container'>
      <div className='product-title'>
        <h2>{ title}</h2>
      </div>
      <div className='product-list'>
        <div className='product-single' onClick={()=>handleClickProduct()}>
          <div className='product-image'>
            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
          </div>
          <div className='product-info'>
            <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
            <span>7,470,000 ₫</span>
          </div>
        </div>
        <div className='product-single' onClick={()=>handleClickProduct()}>
          <div className='product-image'>
            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
          </div>
          <div className='product-info'>
            <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
            <span>7,470,000 ₫</span>
          </div>
        </div>
        <div className='product-single' onClick={()=>handleClickProduct()}>
          <div className='product-image'>
            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
          </div>
          <div className='product-info'>
            <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
            <span>7,470,000 ₫</span>
          </div>
        </div>
        <div className='product-single' onClick={()=>handleClickProduct()}>
          <div className='product-image'>
            <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
          </div>
          <div className='product-info'>
            <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
            <span>7,470,000 ₫</span>
          </div>
        </div>

      </div>
    </div>
  )
}

export default ProductList
