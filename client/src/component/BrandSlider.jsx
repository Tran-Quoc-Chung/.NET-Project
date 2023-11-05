import React from 'react'
import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import brand1 from '../public/images/brand1.png'
import brand2 from '../public/images/brand2.png'
import brand3 from '../public/images/brand3.png'
import brand4 from '../public/images/brand4.png'
import brand5 from '../public/images/brand5.png'
import brand6 from '../public/images/brand6.png'
import brand7 from '../public/images/brand7.png'

function BrandSlider() {
    const responsive = {
        superLargeDesktop: {
            // the naming can be any, depends on you.
            breakpoint: { max: 4000, min: 3000 },
            items: 4
        },
        desktop: {
            breakpoint: { max: 3000, min: 1024 },
            items: 4
        },
        tablet: {
            breakpoint: { max: 1024, min: 464 },
            items: 1
        },
        mobile: {
            breakpoint: { max: 464, min: 0 },
            items: 1
        }
    };
  return (
    <div className='brand-container'>
          <div className='brand-title'>
              <h2>CÁC THƯƠNG HIỆU NỔI TIẾNG</h2>
          </div>
          <div className='brand-carousel'>
          <Carousel
                swipeable={true}
                draggable={false}
                responsive={responsive}
                ssr={true}
                infinite={true}
                autoPlay={true}
                autoPlaySpeed={3000}
                keyBoardControl={true}
                mouseTracking={true}
                customTransition="transform 700ms ease-in-out"
                transitionDuration={1000}
                containerClass="carousel-container"
                dotListClass="custom-dot-list-style"
                itemClass="carousel-item-padding-40-px"
            >
                <img src={brand1} alt="Img not found" />
                <img src={brand2} alt="Img not found" />
                <img src={brand3} alt="Img not found" />
                <img src={brand4} alt="Img not found" />
                <img src={brand5} alt="Img not found" />
                <img src={brand6} alt="Img not found" />
                <img src={brand7} alt="Img not found" />

            </Carousel>
          </div>
    </div>
  )
}

export default BrandSlider
