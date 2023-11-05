import React from 'react'
import Slider from '../component/Slider'
import Trending from '../component/Trending'
import ProductList from '../component/ProductList'
import BrandSlider from '../component/BrandSlider'
import Contact from '../component/Contact'

function Home() {
  return (
    <div className='home-container'>
      <div className='home-slider'>
        <Slider />
      </div>
      <div className='home-trending'>
        <Trending/>
      </div>
      <div className='home-product'>
        <ProductList title="sản phẩm mới nhất" product=""/>
      </div>
      <div className='home-brandslider'>
        <BrandSlider/>
      </div>
      <div className='home-bestsale'>
       <ProductList title="sản phẩm bán chạy" product=""/>
      </div>
      <div className='home-contact'>
      <Contact/>
      </div>

    </div>
  )
}

export default Home
