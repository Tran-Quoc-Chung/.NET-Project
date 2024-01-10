import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';
import { useFormik } from 'formik';
import moment from 'moment';
import strapMaterialApi from 'src/service/StrapMaterialService';
function StrapMaterialModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    const [strapMaterialInfo, setStrapMaterialInfo] = useState();

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData()
    }, [data]);

    const fetchData = async () => {
        if (data !== null) {
            await strapMaterialApi.getByID(data.selectedRows[0].strapMaterialID).then(result => setStrapMaterialInfo(result.data))
        }
    }
    const handleSubmit = async (values) => {
        if (data !== null) {
            const update = await strapMaterialApi.update(values);
            if (update.success == true) {
                handleCloseModal();
            }

        } else {
            const create = await strapMaterialApi.create(values);
            if (create.success == true) {
                handleCloseModal();
            }
        }
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            StrapMaterialID: !!strapMaterialInfo ? strapMaterialInfo.strapMaterialID : '',
            StrapMaterialName: !!strapMaterialInfo ? strapMaterialInfo.strapMaterialName : '',
            Description: !!strapMaterialInfo ? strapMaterialInfo.description : '',
            CreatedBy: !!strapMaterialInfo ? strapMaterialInfo.createdBy : '',
            CreatedAt: !!strapMaterialInfo ? strapMaterialInfo.createdAt : new Date().toLocaleDateString('en-GB'),
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleCloseModal = () => {
        setShow(false);
        setShowModal(null);
        setStrapMaterialInfo(null);
    }
    return (
        <CModal
            show={show}
            onClose={() => handleCloseModal()}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} chất liệu dây</CModalHeader>
            <CModalBody className='p-4' >
                <CForm onSubmit={formik.handleSubmit} id='form'>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>ID</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={formik.values.StrapMaterialID}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên chất liệu</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='StrapMaterialName' value={formik.values.StrapMaterialName} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='Description' value={formik.values.Description} onChange={formik.handleChange}/>
                                </CCol>
                            </CRow>
                        </CCol>
 
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Ngày tạo</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <Space direction="vertical" size={17} className='w-100 '>
                                        <DatePicker size='large' className='w-100 input-readonly' value={moment(formik.values.CreatedAt, 'dd/MM/yyyy')} />
                                    </Space>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Người tạo</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className= 'input-readonly' value={formik.values.CreatedBy} />
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

export default StrapMaterialModal
