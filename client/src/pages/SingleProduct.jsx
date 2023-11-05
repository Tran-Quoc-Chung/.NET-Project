import React,{useState} from 'react'
import watch4 from '../public/images/watch4.jpg';
import watch1 from '../public/images/watch1.jpg';
import watch3 from '../public/images/watch3.jpg';
import watch2 from '../public/images/watch2.jpg';
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";
import ReactStars from "react-rating-stars-component";
import { faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ProductSlider from '../component/ProductSlider';
import ImageGallery from "react-image-gallery";

function SingleProduct() {
  let [star, setStar] = useState();
  const [showDelete, setShowDelete] = useState(false);
  const images = [
    {
      original: watch4,
      thumbnail: watch4,
      description: 'Ảnh sản phẩm',
    },
    {
      original: watch3,
      thumbnail: watch3,

    },
    {
      original: watch2,
      thumbnail: watch2,

    },
    {
      original: watch1,
      thumbnail: watch1,

    },
  ];
  const configImage = {
    showPlayButton: false,
    showVideo: false,
  }
  return (
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
            <h5>Trang chủ / đồng hồ nữ</h5>
            </div>
            <h2 >ĐỒNG HỒ TISSOT T41.1.183.34 NỮ TỰ ĐỘNG DÂY INOX</h2>
            <span> </span>
            <h2 id='price'>17,640,000 ₫</h2>

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
              <input type='number' step={1} min={1} max={999} size={4} defaultValue={1}></input>
              <button>Thêm vào giỏ</button>
            </div>
            <p className='idproduct'>Mã: T41.1.183.34</p>
            <p className='idproduct'>Danh mục: Đồng hồ nữ</p>
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
                      <td>Nữ</td>
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
