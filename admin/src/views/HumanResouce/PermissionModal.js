import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow, CFormCheck } from '@coreui/react';
import React, { useEffect, useState } from 'react'

function PermissionModal(props) {
  let { type, setShowModal, data } = props;
  const [show, setShow] = useState(false);
  let value = data?.selectedRows?.[0] || null

  useEffect(() => {
    type !== null ? setShow(true) : setShow(false);
  }, [type])
  return (
    <CModal
      onClose={() => { setShow(false); setShowModal(null) }}
      visible={show}
      className='modal-xl'
    >
      <CModalHeader closeButton>{type} người dùng</CModalHeader>
      <CModalBody className='p-4' >
        <CForm >
          <CRow className='mb-3'>
            <CRow className='fs-5  fw-semibold'>Nhân sự</CRow>
            <CRow className='d-flex justify-content-start m-1'>
              <CCol md="4" className='mt-2' >
                <CFormCheck id="flexCheckChecked" label="Xem người dùng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Tạo mới người dùng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Chỉnh sửa người dùng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Xóa người dùng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Phân quyền người dùng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Xem vai trò" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Tạo vai trò" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Chỉnh sửa vai trò" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Xóa vai trò" />
              </CCol>
            </CRow>
          </CRow>
          <CRow className='mb-3'>
            <CRow className='fs-5  fw-semibold'>Bán hàng</CRow>
            <CRow className='d-flex justify-content-start m-1'>
              <CCol md="4" className='mt-2' >
                <CFormCheck id="flexCheckChecked" label="Xem dữ liệu" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Bán hàng" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Cập nhật" />
              </CCol>
            </CRow>
          </CRow>
          <CRow className='mb-3'>
            <CRow className='fs-5  fw-semibold'>Tồn kho</CRow>
            <CRow className='d-flex justify-content-start m-1'>
              <CCol md="4" className='mt-2' >
                <CFormCheck id="flexCheckChecked" label="Xem" />
              </CCol>
              <CCol md="4" className='mt-2'>
                <CFormCheck id="flexCheckChecked" label="Nhập kho" />
              </CCol>
            </CRow>
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

export default PermissionModal
