import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';
import { useFormik } from 'formik';
import dialShapeApi from 'src/service/DialShapeService';
import moment from 'moment';

function DialShapeModal(props) {
    let { type, setShowModal, data } = props;
    console.log(data);
    const [show, setShow] = useState(false);
    const [dialShapeInfo, setDialShapeInfo] = useState();

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData()
    }, [data]);

    const fetchData = async () => {
        if (data !== null) {
            await dialShapeApi.getByID(data.selectedRows[0].dialShapeID).then(result => setDialShapeInfo(result.data))
        }
    }
    const handleSubmit = async (values) => {
        if (data !== null) {
            const update = await dialShapeApi.update(values);
            if (update.success == true) {
                handleCloseModal();
            }

        } else {
            const create = await dialShapeApi.create(values);
            if (create.success == true) {
                handleCloseModal();
            }
        }
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            DialShapeID: !!dialShapeInfo ? dialShapeInfo.dialShapeID : '',
            DialShapeName: !!dialShapeInfo ? dialShapeInfo.dialShapeName : '',
            Description: !!dialShapeInfo ? dialShapeInfo.description : '',
            CreatedBy: !!dialShapeInfo ? dialShapeInfo.createdBy : JSON.parse(localStorage.getItem("userinfo")).displayname || '',
            CreatedAt: !!dialShapeInfo ? dialShapeInfo.createdAt : new Date().toLocaleDateString('en-GB'),
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleCloseModal = () => {
        setShow(false);
        setShowModal(null);
        setDialShapeInfo(null);
    }
    return (
        <CModal
            show={show}
            onClose={() => handleCloseModal()}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} hình dạng mặt số</CModalHeader>
            <CModalBody className='p-4' >
                <CForm id='form' onSubmit={formik.handleSubmit}>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>ID</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={formik.values.DialShapeID}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Hình dạng</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''}name='DialShapeName' value={formik.values.DialShapeName} onChange={formik.handleChange} />
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
                                        <DatePicker size='large' className='w-100 input-readonly' value={moment(formik.values.CreatedAt, 'dd/MM/yyyy')}/>
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
            <CModalFooter >
                <CButton color="primary" type='submit' form='form'>Lưu</CButton>
                <CButton
                    color="secondary"
                    onClick={() => { setShow(false); setShowModal(null) }}
                >Đóng</CButton>
            </CModalFooter>
        </CModal>

    )
}

export default DialShapeModal
