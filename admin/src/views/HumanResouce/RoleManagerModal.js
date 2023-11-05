
import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'

function RoleManagerModal(props) {
    let { type, setShowModal,data } = props;
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
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mã vai trò</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={data ? value?.roleId : ''}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên vai trò</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleName : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''}/>
                                </CCol>
                            </CRow>
                        </CCol>
    
                        
                       
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Trạng thái</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                <CFormSelect className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="nam">Kích hoạt</option>
                                        <option value="nữ">Ngưng kích hoạt</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Người tạo</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Alen</option>
                                        <option value="Ngưng hoạt động">Mark</option>
                                    </CFormSelect>
                                </CCol>
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

export default RoleManagerModal
