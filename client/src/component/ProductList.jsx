import React from 'react'
import { useNavigate } from 'react-router-dom'
import noImage from '../public/images/no-image.jpg';
import { VND } from '../utils/validateField';
function ProductList(props) {
  const { title, product } = props;
  const navigate = useNavigate();
  const handleClickProduct = (id) => {
    navigate(`/product/product-detail/${id}`)
  }
  return (
    <div className='home-product-container'>
      <div className='product-title'>
        <h2>{title}</h2>
      </div>
      <div className='product-list'>
        {
          product && product.map(item => (
            <div className='product-single' onClick={() => handleClickProduct(item.productID)}>
              <div className='product-image'>
                <img src={item?.images || noImage} />
              </div>
              <div className='product-info'>
                <h3>{ item?.productName}</h3>
                <span>{ VND.format(item.price)}</span>
              </div>
            </div>
          ))
        }

      </div>
    </div>
  )
}

export default ProductList
