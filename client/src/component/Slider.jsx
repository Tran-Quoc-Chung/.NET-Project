import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import slider2 from '../public/images/slider2.webp';
import slider3 from '../public/images/slider3.webp';
import slider4 from '../public/images/slider4.webp';
import slider5 from '../public/images/slider5.webp';
const Slider = () => {
    const responsive = {
        superLargeDesktop: {
            // the naming can be any, depends on you.
            breakpoint: { max: 4000, min: 3000 },
            items: 1
        },
        desktop: {
            breakpoint: { max: 3000, min: 1024 },
            items: 1
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
        <div className="slider-container" >
            <Carousel
                swipeable={true}
                draggable={false}
                showDots={true}
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
              
                <img src={slider2} alt="Img not found" />
                <img src={slider3} alt="Img not found" />
                <img src={slider4} alt="Img not found" />
                <img src={slider5} alt="Img not found" />

            </Carousel>
        </div>

    )
}
export default Slider;
