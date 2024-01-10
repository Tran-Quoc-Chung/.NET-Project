import React,{useEffect, useState} from 'react'
import watch4 from '../public/images/watch4.jpg';
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";
import ReactStars from "react-rating-stars-component";
import { faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ProductSlider from '../component/ProductSlider';
import ImageGallery from "react-image-gallery";
import { useParams } from 'react-router-dom';
import productApi from '../service/ProductService';
import { VND } from '../utils/validateField';
import { useFormik } from 'formik';
import authApi from '../service/AuthService';
import Cookies from 'js-cookie';
import { toast } from 'react-toastify';

function SingleProduct() {
  let [star, setStar] = useState();
  const [showDelete, setShowDelete] = useState(false);
  const params = useParams();
  const [productInfo, setProductInfo] = useState();
  useEffect(() => {
    fetchData()
  }, []);
  const fetchData = async () => {
    if (!!params.id) {
      productApi.getById(params.id).then(result => {
        setProductInfo(result.data)
      })
    } 
  }
  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      Quantity: 1,
      ProductId: params.id
    },
    onSubmit: values => {
      handleSubmit(values)
    },
  });
  const handleSubmit = async (values) => {
    const customerLogin = Cookies.get('customer');
    if (!customerLogin) return toast.error("Vui lòng đăng nhập trước khi thêm vào giỏ hàng");

    await authApi.addToCart(values).then(result => {
      if (result.success)
      {
        toast.success("Thêm sản phẩm vào giỏ hàng thành công");
      } else {
        toast.error("Thêm sản phẩm vào giỏ hàng thất bại");
        }
    })
  }
  // const images = [
  //   {
  //     original: watch4,
  //     thumbnail: watch4,
  //     description: 'Ảnh sản phẩm',
  //   },
  //   {
  //     original: watch3,
  //     thumbnail: watch3,

  //   },
  //   {
  //     original: watch2,
  //     thumbnail: watch2,

  //   },
  //   {
  //     original: watch1,
  //     thumbnail: watch1,

  //   },
  // ];
  const images = productInfo && productInfo.productImage.map((item) => (
    {
      original: item.imagesUrl,
      thumbnail: item.imagesUrl,
      description: 'Ảnh sản phẩm',
    }
  ))
  const configImage = {
    showPlayButton: false,
    showVideo: false,
  }
  return productInfo && (
    <div className='product-detail-container'>
      <div className='product'>
        <div className='desc'>
          <div className='image'>
            <ImageGallery
              items={images}
              showPlayButton={false}
              showBullets={false}
              showIndex={false}
              showNav={false}
            />
          </div>
          <div className='info'>
            <div className='info-category'>
            <h5>Trang chủ / đồng hồ nam</h5>
            </div>
            <h2 >{ productInfo.product.productName}</h2>
            <span> </span>
            <h2 id='price'>{ VND.format(productInfo.product.sellPrice)}</h2>

            <p className='pdesc'>
              Mẫu Tissot T41.1.183.34 vẻ ngoài giản dị của chiếc đồng hồ 3 kim nhưng lại khoác lên sự trang nhã với nền
              mặt số được phối tông màu trắng trước bề mặt kính Sapphire kết hợp cùng tổng thể chiếc đồng hồ kim loại màu bạc đầy
              sang trọng.
              <br/>
              › Sản phẩm nhập khẩu chính hãng.
              <br/>
              › Thanh toán sau khi nhận hàng.
              <br/>
              › Bảo hành chính hãng toàn cầu.
              <br />
              › Gọi <strong>1900 1999</strong> để đặt hàng
            </p>
            <div className='quantity'>
              <p>Số lượng:</p>
              <input type='number' step={1} min={1} max={999} size={4} value={formik.values.Quantity} name='Quantity' onChange={formik.handleChange}></input>
              <button onClick={()=>handleSubmit(formik.values)}>Thêm vào giỏ</button>
            </div>
            <p className='idproduct'>Mã: T41.1-{productInfo.product.productID }</p>
            <p className='idproduct'>Danh mục: Đồng hồ nam</p>
          </div>
        </div>
        <div className='tabdesc'>
          <Tabs defaultIndex={0} >
            <TabList>
              <Tab style={{ color: "#4e4444", fontSize: "16px", fontWeight: "bolder" ,height:"45px",  }} >THÔNG TIN BỔ SUNG</Tab>
              <Tab style={{ color: "#4e4444", fontSize: "16px", fontWeight: "bolder"  ,height:"45px"}}>ĐÁNH GIÁ</Tab>
              <Tab style={{ color: "#4e4444", fontSize: "16px", fontWeight: "bolder" ,height:"45px",  }}>CHÍNH SÁCH BẢO HÀNH</Tab>
            </TabList>
            <TabPanel>
              <div className='infoproduct'>
                <table className='table'>
                  <tbody><tr>
                    <th>Bộ máy &amp; Năng lượng</th>
                    <td>Cơ (Automatic)</td>
                  </tr>
                    <tr>
                      <th>Chất liệu dây</th>
                      <td>Dây Kim Loại</td>
                    </tr>
                    <tr>
                      <th>Chất liệu mặt kính</th>
                      <td>Kính Sapphire</td>
                    </tr>
                    <tr>
                      <th>Giới tính</th>
                      <td>Nam</td>
                    </tr>
                    <tr>
                      <th>Hình dạng mặt số</th>
                      <td>Tròn </td>
                    </tr>
                    <tr>
                      <th>Kích thước mặt số</th>
                      <td>29 mm</td>
                    </tr>
                    <tr>
                      <th>Màu mặt số</th>
                      <td>Trắng</td>
                    </tr>
                    <tr>
                      <th>Mức chống nước</th>
                      <td>Đi Mưa Nhỏ (3 ATM) </td>
                    </tr>
                    <tr>
                      <th>Thương hiệu</th>
                      <td>Tissot</td>
                    </tr>
                    <tr>
                      <th>Xuất xứ</th>
                      <td>Thụy Sĩ</td>
                    </tr>
                  </tbody></table>
              </div>
            </TabPanel>
            <TabPanel>
              <div className='rating'>
                <div className='comment'>
                  <div className='singlecomment'>
                    <div className='userinfo'>
                      <div className='ratinginfo'>
                        <p>User 1</p>
                        <p>22:45 16/8/2023</p>
                      </div>
                      <div className='rating-count'>
                      <div className='countstar'>
                        <ReactStars
                          count={5}
                          onChange={setStar}
                          size={24}
                          activeColor="#ffd700"
                        />
                      </div>
                      <div className='show-delete'>
                        <span><FontAwesomeIcon icon={faTrashCan}/></span>
                      </div>
                      </div>
                    </div>
                    <div className='content'>
                      <div className='textcontent'>
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Hic debitis saepe perferendis explicabo veniam enim labore maiores corrupti quod, dignissimos
                      </div>
                      <div className='imgcontent'>
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                      </div>
                    </div>
                  </div>
                  <div className='singlecomment'>
                  <div className='userinfo'>
                      <div className='ratinginfo'>
                        <p>User 1</p>
                        <p>22:45 16/8/2023</p>
                      </div>
                      <div className='rating-count'>
                      <div className='countstar'>
                        <ReactStars
                          count={5}
                          onChange={setStar}
                          size={24}
                          activeColor="#ffd700"
                        />
                      </div>
                      <div className='show-delete div-hide'>
                       <span> <FontAwesomeIcon icon={faTrashCan}/></span>
                      </div>
                      </div>
                    </div>
                    <div className='content'>
                      <div className='textcontent'>
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Hic debitis saepe perferendis explicabo veniam enim labore maiores corrupti quod, dignissimos
                      </div>
                      <div className='imgcontent'>
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                      </div>
                    </div>
                  </div>
                  <div className='singlecomment'>
                  <div className='userinfo'>
                      <div className='ratinginfo'>
                        <p>User 1</p>
                        <p>22:45 16/8/2023</p>
                      </div>
                      <div className='rating-count'>
                      <div className='countstar'>
                        <ReactStars
                          count={5}
                          onChange={setStar}
                          size={24}
                          activeColor="#ffd700"
                        />
                      </div>
                      <div className='show-delete div-hide'>
                        <FontAwesomeIcon icon={faTrashCan}/>
                      </div>
                      </div>
                    </div>
                    <div className='content'>
                      <div className='textcontent'>
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Hic debitis saepe perferendis explicabo veniam enim labore maiores corrupti quod, dignissimos
                      </div>
                      <div className='imgcontent'>
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                        <img
                          src={watch4}
                          width={60}
                          height={60}
                          alt='not found'

                        />
                      </div>
                    </div>
                  </div>
                  

                </div>
                <div className='post'>

                  <div className='rating-star'>
                  <textarea
                    placeholder="Nhập bình luận của bạn..." />
                        <ReactStars
                          count={5}
                          onChange={setStar}
                          size={24}
                          activeColor="#ffd700"
                        />
                   </div>
                  <input type="file" accept="image/*" />

                  <button >Đăng bình luận</button>
                </div>
              </div>
            </TabPanel>
            <TabPanel>
              <div className='warranty'>
                <p>Chính sách bảo hành của riêng mỗi hãng:</p>
                <p>CASIO: Bảo hành chính hãng máy 1 năm, pin 1,5 năm</p>
                <p>CITIZEN: Bảo hành chính hãng toàn cầu máy 1 năm, pin 1 năm</p>
                <p>SEIKO: Bảo hành chính hãng toàn cầu máy 1 năm, pin 1 năm</p>
                <p>ORIENT: Bảo hành chính hãng toàn cầu máy 1 năm, pin 1 năm</p>
                <p>OP: Bảo hành chính hãng máy 2 năm, pin 1 năm</p>
                <p>RHYTHM:&nbsp;Bảo hành chính hãng máy 1 năm, pin 1 năm</p>
                <p>OGIVAL:&nbsp;Bảo hành chính hãng máy 2 năm, pin 1 năm</p>
                <p>ELLE:&nbsp;Bảo hành chính hãng máy 2 năm, pin 2 năm</p>
                <p>TISSOT:&nbsp;Bảo hành chính hãng máy 2 năm, pin 1 năm</p>			</div>
            </TabPanel>
          </Tabs>
        </div>
      </div>
      <div className='product-relate'>
       <ProductSlider />
      </div>
    </div>
  )
}

export default SingleProduct
