import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import slider2 from '../public/images/slider2.webp';
import slider3 from '../public/images/slider3.webp';
import slider4 from '../public/images/slider4.webp';
import slider5 from '../public/images/slider5.webp';
import React from "react";
function ProductSlider() {
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
            items: 4
        },
        mobile: {
            breakpoint: { max: 464, min: 0 },
            items: 4
        }
    };
    return (
        <div className="slider-product-container" >
            <div className="slider-title">
                <h2>SẢN PHẨM TƯƠNG TỰ</h2>
                <span></span>
            </div>
            <Carousel
                swipeable={true}
                draggable={false}
                responsive={responsive}
                ssr={true}
                infinite={true}
                autoPlay={true}
                autoPlaySpeed={5000}
                keyBoardControl={true}
                mouseTracking={true}
                customTransition="transform 700ms ease-in-out"
                transitionDuration={1000}
                containerClass="carousel-container"
                dotListClass="custom-dot-list-style"
                itemClass="carousel-item-padding-40-px"
            >

                <div className='product-single'>
                    <div className='product-image'>
                        <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
                    </div>
                    <div className='product-info'>
                        <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
                        <span>7,470,000 ₫</span>
                    </div>
                </div>
                <div className='product-single'>
                    <div className='product-image'>
                        <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
                    </div>
                    <div className='product-info'>
                        <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
                        <span>7,470,000 ₫</span>
                    </div>
                </div>
                <div className='product-single'>
                    <div className='product-image'>
                        <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
                    </div>
                    <div className='product-info'>
                        <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
                        <span>7,470,000 ₫</span>
                    </div>
                </div>
                <div className='product-single'>
                    <div className='product-image'>
                        <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
                    </div>
                    <div className='product-info'>
                        <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
                        <span>7,470,000 ₫</span>
                    </div>
                </div>
                <div className='product-single'>
                    <div className='product-image'>
                        <img src='https://mauweb.monamedia.net/luxshopping/wp-content/uploads/2018/11/sp7-nam-300x300.jpg' />
                    </div>
                    <div className='product-info'>
                        <h3>MICHAEL KORS BRECKEN CHRONOGRAPH WATCH 44MM</h3>
                        <span>7,470,000 ₫</span>
                    </div>
                </div>


            </Carousel>
        </div>

    )
}

export default ProductSlider
