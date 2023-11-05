import React from 'react'
import { CButton, CCardBody, CCardHeader, CCol, CContainer, CFormInput, CFormLabel, CFormSelect, CRow } from '@coreui/react';
import { DatePicker, Radio, Space } from 'antd';
import CIcon from '@coreui/icons-react';
import { cilDelete } from '@coreui/icons'
function ImportProduct() {
    return (
        <CContainer className='max-vh-100 position-relative mb-3 overflow-y-scroll'>
            <CFormLabel className='w-100 text-center fs-4 fw-semibold'>Nhập kho</CFormLabel>
            <CRow md={12} className='h-100 w-100'>
                <CCol md={7} className='border-end border-end-secondary border-3 '>
                    <CRow md={12} className='w-100 h-50 border-bottom border-bottom-secondary border-3'>
                        {/* //title */}
                        <CRow md={12} className='mb-2'>
                            <CCol md={2} className='fs-7 fw-medium text-center '>ID sản phẩm</CCol>
                            <CCol md={4} className='fs-7 fw-medium text-center '>Tên sản phẩm</CCol>
                            <CCol md={3} className='fs-7 fw-medium text-center '>Số lượng</CCol>
                            <CCol md={2} className='fs-7 fw-medium text-center '>Đơn giá</CCol>
                        </CRow>
                        <CRow className='mt-2'>
                            <CCol md={2} className='text-center'>1</CCol>
                            <CCol md={4} className='text-center'>Đồng hồ Apple Watch chính hãng, giá rẻ, ưu đãi trả góp 0% - 11/2023</CCol>
                            <CCol md={3} className='text-center'><CFormInput type='number' className='w-50 mx-auto'></CFormInput></CCol>
                            <CCol md={2} className='text-center'>1700000</CCol>
                            <CCol md={1} className='text-center'><CIcon icon={cilDelete} /></CCol>

                        </CRow>
                        <CRow className='mt-2'>
                            <CCol md={2} className='text-center'>1</CCol>
                            <CCol md={4} className='text-center'>Đồng hồ Apple Watch chính hãng, giá rẻ, ưu đãi trả góp 0% - 11/2023</CCol>
                            <CCol md={3} className='text-center'><CFormInput type='number' className='w-50 mx-auto'></CFormInput></CCol>
                            <CCol md={2} className='text-center'>1700000</CCol>
                            <CCol md={1} className='text-center'><CIcon icon={cilDelete} /></CCol>

                        </CRow>
                        <CRow className='mt-2'>
                            <CCol md={2} className='text-center'>1</CCol>
                            <CCol md={4} className='text-center'>Đồng hồ Apple Watch chính hãng, giá rẻ, ưu đãi trả góp 0% - 11/2023</CCol>
                            <CCol md={3} className='text-center'><CFormInput type='number' className='w-50 mx-auto'></CFormInput></CCol>
                            <CCol md={2} className='text-center'>1700000</CCol>
                            <CCol md={1} className='text-center'><CIcon icon={cilDelete} /></CCol>

                        </CRow>
                        <CRow className='mt-2'>
                            <CCol md={2} className='text-center'>1</CCol>
                            <CCol md={4} className='text-center'>Đồng hồ Apple Watch chính hãng, giá rẻ, ưu đãi trả góp 0% - 11/2023</CCol>
                            <CCol md={3} className='text-center'><CFormInput type='number' className='w-50 mx-auto'></CFormInput></CCol>
                            <CCol md={2} className='text-center'>1700000</CCol>
                            <CCol md={1} className='text-center'><CIcon icon={cilDelete} /></CCol>

                        </CRow>
                    </CRow>
                    <CRow md={12} className='w-100 '>
                        <CRow md={12} className='mt-2' >
                            <CCol md={2} className='mt-2 fw-semibold'>Filter:</CCol>
                            <CCol md={5}><CFormInput type='text' placeholder='ID sản phẩm'></CFormInput> </CCol>
                            <CCol md={5}> <CFormInput type='text' placeholder='Tên sản phẩm'></CFormInput></CCol>
                        </CRow>
                        <CFormLabel className='mt-2 text-center'>Danh sách sản phẩm</CFormLabel>
                        <CRow md={12} className='mt-2 p-1 w-100 '>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                            <CCol md={3} className='border border-white mx-3 my-2 ' style={{ height: 150,  padding:'5px' }} >
                                <CRow className='h-75 w-100 m-auto'>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png' alt='Not found image' className='img-thumbnail h-100' />
                                </CRow>
                                <CRow className='h-25'>
                                    <CFormLabel className='mt-1 h-100 text-truncate' style={{ whiteSpace: 'normal', overflow: 'hidden', textOverflow: 'ellipsis', fontSize: '13px' }}>Apple Watch Series 9 GPS + Cellular, Vỏ Thép Không Gỉ Màu Gold 41mm với Dây Quấn Milan</CFormLabel>
                                </CRow>
                            </CCol>
                        </CRow>
                    </CRow>
                </CCol>
                <CCol md={5}>
                    <CRow md={12}>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Ngày nhập kho</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <Space direction="vertical" size={17} className='w-100' >
                                <DatePicker size='large' className='w-100 input-readonly' />
                            </Space>
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Nhân viên</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormSelect name='createBy' onChange={(e) => handleFilter(e)}>
                                <option value=""></option>
                                <option value="Hoạt động">Mark</option>
                                <option value="Ngưng hoạt động">Alen</option>
                            </CFormSelect>
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Đối tác</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Tổng số lượng</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Thành tiền</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Chiết khấu</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Thanh toán</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput />
                        </CCol>
                    </CRow>
                    <CRow md={12} className='mt-3'>
                        <CCol md={5}>
                            <CFormLabel className='mt-1'>Người tạo</CFormLabel>
                        </CCol>
                        <CCol md={7}>
                            <CFormInput className='input-readonly' />
                        </CCol>
                    </CRow>
                    <CRow  className='mt-5 w-75 m-auto'> <CButton  color="primary" className='w-100'>Nhập hàng</CButton></CRow>
                </CCol>
            </CRow>
        </CContainer>
    )
}

export default ImportProduct
