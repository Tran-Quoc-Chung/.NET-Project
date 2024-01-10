import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';
import { useFormik } from 'formik';
import partnerApi from 'src/service/PartnerService';
function PartnerModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    const [partnerInfo, setPartnerInfo] = useState();

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData()
    }, [data]);

    const fetchData = async () => {
        if (data !== null) {
            await partnerApi.getByID(data.selectedRows[0].partnerID).then(result => setPartnerInfo(result.data))
        }
    }
    const handleSubmit = async (values) => {
        if (data !== null) {
            const update = await partnerApi.update(values);
            if (update.success == true) {
                handleCloseModal();
            }

        } else {
            const create = await partnerApi.create(values);
            if (create.success == true) {
                handleCloseModal();
            }
        }
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            PartnerID: !!partnerInfo ? partnerInfo.partnerID : '',
            DisplayName: !!partnerInfo ? partnerInfo.displayName : '',
            Email: !!partnerInfo ? partnerInfo.email : '',
            Address: !!partnerInfo ? partnerInfo.address : '',
            Phone: !!partnerInfo ? partnerInfo.phone :''
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleCloseModal = () => {
        setShow(false);
        setShowModal(null);
        setPartnerInfo(null);
    }
    return (
        <CModal
            show={show}
            onClose={() => handleCloseModal()}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} mức chống nước</CModalHeader>
            <CModalBody className='p-4' >
            <CForm onSubmit={formik.handleSubmit} id='form'>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>ID</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={formik.values.PartnerID}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên đối tác</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='DisplayName' value={formik.values.DisplayName} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Địa chỉ</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='Address' value={formik.values.Address} onChange={formik.handleChange}/>
                                </CCol>
                            </CRow>
                        </CCol>
 
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Email</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} type= 'email' name='Email' value={formik.values.Email} onChange={formik.handleChange}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Số điện thoại</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className= {type === 'Xem' ? 'input-readonly' : ''} name='Phone' value={formik.values.Phone} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                    </CRow>
                </CForm>

            </CModalBody>
            <CModalFooter>
                <CButton color="primary" type='submit' form='form'>Lưu</CButton>{' '}
                <CButton
                    color="secondary"
                    onClick={() => { setShow(false); setShowModal(null) }}
                >Đóng</CButton>
            </CModalFooter>
        </CModal>

    )
}

export default PartnerModal
