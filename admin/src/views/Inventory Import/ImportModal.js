import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';

function ImportModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    let value = data?.selectedRows?.[0] || null
    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type])
    return (
        <CModal
            show={show}
            onClose={() => { setShow(false); setShowModal(null) }}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} người dùng</CModalHeader>
            <CModalBody className='p-4' >
                <CForm >
                    <CRow md="12">
                        <CCol md="6">
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Mã phiếu</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className='input-readonly' value={data ? value?.roleId : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Đối tác</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleName : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Tổng số lượng</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Tổng thanh toán</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Nhân viên</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormSelect className={type === 'Xem' ? 'input-readonly' : ''} onChange={(e) => handleFilter(e)}>
                                            <option value=""></option>
                                            <option value="Hoạt động">Mark</option>
                                            <option value="Ngưng hoạt động">Alen</option>
                                        </CFormSelect>
                                    </CCol>
                                </CRow>
                            </CCol>

                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Ngày tạo</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <Space direction="vertical" size={17} className='w-100 '>
                                            <DatePicker size='large' className='w-100 input-readonly' />
                                        </Space>
                                    </CCol>
                                </CRow>
                            </CCol>
                            <CCol md="12" className='mb-3'>
                                <CRow>
                                    <CCol md="4" >
                                        <CFormLabel className='mt-1'>Người tạo</CFormLabel>
                                    </CCol>
                                    <CCol md="7" >
                                        <CFormInput className='input-readonly' defaultValue={!!data ? value?.roleDesc : ''} />
                                    </CCol>
                                </CRow>
                            </CCol>
                        </CCol>
                        <CCol md="6 " className='overflow-y-scroll ' style={{maxHeight:"500px"}}>
                            <CFormLabel className='fs-4 fixed text-center w-100' >Chi tiết nhập kho</CFormLabel>
                            <CRow md={12} className='mb-2 fw-medium'>
                                <CCol md={10} className='text-center'>Sản phẩm</CCol>
                                <CCol md={2}>SL</CCol>
                            </CRow>
                        <CRow md={12} className='mb-3'>
                                <CCol md={3}>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/314714/apple-watch-ultra-lte-49mm-vien-titanium-day-trail-den-thumb-1-600x600.jpg' alt='Not found' className='img-thumbnail'/>
                                </CCol>
                                <CCol md={7}>
                                    <CFormLabel className='fs-6 text-center overflow-hidden align-items-center mt-auto'>Đồng hồ thông minh Apple Watch chính hãng, giá tốt, trả góp 0% - 11/2023</CFormLabel>
                                </CCol>
                                <CCol md={2}>5</CCol>
                        </CRow>
                        <CRow md={12} className='mb-3'>
                                <CCol md={3}>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/314714/apple-watch-ultra-lte-49mm-vien-titanium-day-trail-den-thumb-1-600x600.jpg' alt='Not found' className='img-thumbnail'/>
                                </CCol>
                                <CCol md={7}>
                                    <CFormLabel className='fs-6 text-center overflow-hidden align-items-center mt-auto'>Đồng hồ thông minh Apple Watch chính hãng, giá tốt, trả góp 0% - 11/2023</CFormLabel>
                                </CCol>
                                <CCol md={2}>5</CCol>
                        </CRow>
                        <CRow md={12} className='mb-3'>
                                <CCol md={3}>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/314714/apple-watch-ultra-lte-49mm-vien-titanium-day-trail-den-thumb-1-600x600.jpg' alt='Not found' className='img-thumbnail'/>
                                </CCol>
                                <CCol md={7}>
                                    <CFormLabel className='fs-6 text-center overflow-hidden align-items-center mt-auto'>Đồng hồ thông minh Apple Watch chính hãng, giá tốt, trả góp 0% - 11/2023</CFormLabel>
                                </CCol>
                                <CCol md={2}>5</CCol>
                        </CRow>
                        <CRow md={12} className='mb-3'>
                                <CCol md={3}>
                                    <img src='https://cdn.tgdd.vn/Products/Images/7077/314714/apple-watch-ultra-lte-49mm-vien-titanium-day-trail-den-thumb-1-600x600.jpg' alt='Not found' className='img-thumbnail'/>
                                </CCol>
                                <CCol md={7}>
                                    <CFormLabel className='fs-6 text-center overflow-hidden align-items-center mt-auto'>Đồng hồ thông minh Apple Watch chính hãng, giá tốt, trả góp 0% - 11/2023</CFormLabel>
                                </CCol>
                                <CCol md={2}>5</CCol>
                        </CRow>
                        </CCol>
                    </CRow>
                </CForm>

            </CModalBody>
            <CModalFooter>
                <CButton color="primary">Lưu</CButton>{' '}
                <CButton
                    color="secondary"
                    onClick={() => { setShow(false); setShowModal(null) }}
                >Đóng</CButton>
            </CModalFooter>
        </CModal>

    )
}

export default ImportModal
