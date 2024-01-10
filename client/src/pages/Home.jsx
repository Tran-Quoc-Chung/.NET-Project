import React, { useEffect, useState } from 'react'
import Slider from '../component/Slider'
import Trending from '../component/Trending'
import ProductList from '../component/ProductList'
import BrandSlider from '../component/BrandSlider'
import Contact from '../component/Contact'
import productApi from '../service/ProductService'

function Home() {
  const [productNew, setProductNew] = useState([]);
  const [productTrending, setProductTrending] = useState([]);
  useEffect(() => {
    const modelNew = {
      Page: 1,
      Sort: 3,
      Limit:4
    }
    const modelTrending = {
      Page: 1,
      Sort: 1,
      Limit:4
    }
    const fetchData = async () => {
      const [productNewData, productTrendingData] = await Promise.all([
        productApi.getAll(modelNew),
        productApi.getAll(modelTrending)
      ]);
      setProductNew(productNewData.data.productList);
      setProductTrending(productTrendingData.data.productList)
    }
    fetchData()
    
  },[]);
  console.log('new',productNew)
  return (
    <div className='home-container'>
      <div className='home-slider'>
        <Slider />
      </div>
      <div className='home-trending'>
        <Trending/>
      </div>
      <div className='home-product'>
        <ProductList title="sản phẩm mới nhất" product={productNew} />
      </div>
      <div className='home-brandslider'>
        <BrandSlider/>
      </div>
      <div className='home-bestsale'>
        <ProductList title="sản phẩm bán chạy" product={productTrending} />
      </div>
      <div className='home-contact'>
      <Contact/>
      </div>

    </div>
  )
}

export default Home
