import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react';
import { DatePicker, Radio, Space } from 'antd';
import { SizeType } from 'antd/es/config-provider/SizeContext';
import { useFormik } from 'formik';
import brandApi from 'src/service/BrandService';
import moment from 'moment';
function BranchModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    const [brandInfo, setBrandInfo] = useState();

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData()
    }, [data]);

    const fetchData = async () => {
        if (data !== null) {
            await brandApi.getByID(data.selectedRows[0].brandID).then(result => setBrandInfo(result.data))
        }
    }
    const handleSubmit = async (values) => {
        if (data !== null) {
            const update = await brandApi.update(values);
            if (update.success == true) {
                handleCloseModal();
            }

        } else {
            const create = await brandApi.create(values);
            if (create.success == true) {
                handleCloseModal();
            }
        }
    }
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            BrandID: !!brandInfo ? brandInfo.brandID : '',
            BrandName: !!brandInfo ? brandInfo.brandName : '',
            Origin: !!brandInfo ? brandInfo.origin : '',
            Description: !!brandInfo ? brandInfo.description : '',
            CreatedBy: !!brandInfo ? brandInfo.createdBy : JSON.parse(localStorage.getItem("userinfo")).displayname || '',
            CreatedAt: !!brandInfo ? brandInfo.createdAt : new Date().toLocaleDateString('en-GB'),
        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });
    const handleCloseModal = () => {
        setShow(false); setShowModal(null); setBrandInfo(null);
    }
    return (
        <CModal
            show={show}
            onClose={() => {handleCloseModal()}}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} hãng</CModalHeader>
            <CModalBody className='p-4' >
                <CForm onSubmit={formik.handleSubmit} id='form'>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mã hãng</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={formik.values.BrandID}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên hãng</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='BrandName' value={formik.values.BrandName} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Xuất xứ</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''}  name='Origin' value={formik.values.Origin} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''}  name='Description' value={formik.values.Description} onChange={formik.handleChange} />
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
                                        <DatePicker size='large' className='w-100 input-readonly' value={moment(formik.values.CreatedAt,'dd/MM/yyyy')} />
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
                                    <CFormInput className= 'input-readonly' value={formik.values.CreatedBy}/>
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

export default BranchModal
