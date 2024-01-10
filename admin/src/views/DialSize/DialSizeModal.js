import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';
import { useFormik } from 'formik';
import dialSizeApi from 'src/service/DialSizeService';
import moment from 'moment';

function DialSizeModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    const [dialSizeInfo, setDialSizeInfo] = useState();

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData()
    }, [data]);

    const fetchData = async () => {
        if (data !== null) {
            await dialSizeApi.getByID(data.selectedRows[0].dialSizeID).then(result => setDialSizeInfo(result.data))
        }
    }
    const handleSubmit = async (values) => {
        if (data !== null) {
            const update = await dialSizeApi.update(values);
            if (update.success == true) {
                handleCloseModal();
            }

        } else {
            const create = await dialSizeApi.create(values);
            if (create.success == true) {
                handleCloseModal();
            }
        }
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            DialSizeID: !!dialSizeInfo ? dialSizeInfo.dialSizeID : '',
            DialSizeName: !!dialSizeInfo ? dialSizeInfo.dialSizeName : '',
            Description: !!dialSizeInfo ? dialSizeInfo.description : '',
            CreatedBy: !!dialSizeInfo ? dialSizeInfo.createdBy : JSON.parse(localStorage.getItem("userinfo")).displayname || '',
            CreatedAt: !!dialSizeInfo ? dialSizeInfo.createdAt : new Date().toLocaleDateString('en-GB'),
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleCloseModal = () => {
        setShow(false); setShowModal(null); setDialSizeInfo(null);
    }
    return (
        <CModal
            show={show}
            onClose={() => { handleCloseModal() }}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} thông số</CModalHeader>
            <CModalBody className='p-4' >
                <CForm onSubmit={formik.handleSubmit} id='form'>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>ID</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={formik.values.DialSizeID} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Kích thước</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='DialSizeName' value={formik.values.DialSizeName} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='Description' value={formik.values.Description} onChange={formik.handleChange} />
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
                                    <CFormInput className='input-readonly' value={formik.values.CreatedBy} />
                                </CCol>
                            </CRow>
                        </CCol>

                    </CRow>
                </CForm>

            </CModalBody>
            <CModalFooter>
                <CButton color="primary" type='submit' form='form' >Lưu</CButton>{' '}
                <CButton
                    color="secondary"
                    onClick={() => { setShow(false); setShowModal(null); setDialSizeInfo(null) }}
                >Đóng</CButton>
            </CModalFooter>
        </CModal>

    )
}

export default DialSizeModal
