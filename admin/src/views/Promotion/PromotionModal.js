import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Space } from 'antd';
import voucherApi from 'src/service/VoucherService';
import { useFormik } from 'formik';
import moment from 'moment';
import dayjs from 'dayjs';
import { toast } from 'react-toastify';


function PromotionModal(props) {
    const { RangePicker } = DatePicker;
    let { type, setShowModal,data } = props;
    const [show, setShow] = useState(false);
    const [voucherInfo, setVoucherInfo] = useState();
    let value = data?.selectedRows?.[0] || null;
    const [startDate, setStartDate] = useState();
    const [endDate, setEndDate] = useState();
    const dateFormat = 'YYYY-MM-DD'; 

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);

    useEffect(() => {
        fetchData();
        console.log('sta',startDate,endDate)
    }, [data]);

    const fetchData = async () => {
        data && await voucherApi.getByID(data.selectedRows[0].voucherCode).then(result => {
            setVoucherInfo(result.data);
            setStartDate(result.data.startDate)
            setEndDate(result.data.endDate)
        });
    }
    

    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            VoucherCode: !!voucherInfo ? voucherInfo?.voucherCode : '',
            EventName: !!voucherInfo ? voucherInfo?.eventName : '',
            Description: !!voucherInfo ? voucherInfo?.description : '',
            Quantity: !!voucherInfo ? voucherInfo?.quantity : 0,
            QuantityRemain: !!voucherInfo ? voucherInfo?.quantityRemain : 0,
            Status: !!voucherInfo ? voucherInfo?.voucherStatusName : 1,
            Discount: !!voucherInfo ? voucherInfo?.discount : 10,
            StartDate: !!voucherInfo ? startDate : new Date().toLocaleDateString(),
            EndDate: !!voucherInfo ? endDate : new Date().toLocaleDateString() ,
            CreatedAt: !!voucherInfo ? voucherInfo?.createdAt : new Date().toLocaleDateString(),
            CreatedBy: !!voucherInfo ? voucherInfo?.createdBy : JSON.parse(localStorage.getItem("userinfo")).displayname || '',

        },
        onSubmit: values => {
            handleSubmit(values)
        },
    });

    const handleQuantityChange = (event) => {
        const inputValue = event.target.value;
        if (/^[0-9]*$/.test(inputValue) || inputValue === '') {
          formik.handleChange(event);
        }
      };

    const handleSubmit = async (values) => {
        if (!startDate || !endDate) {
            return toast.error("Bắt buộc nhập ngày bắt đầu và ngày kết thúc");
        }
        if (values.Quantity <= 0) return toast.error("Số lượng voucher không hợp lệ");

        const Model = {
            ...values,
            Discount:parseFloat(values.Discount/100).toFixed(1),
            StartDate: startDate,
            EndDate:endDate
        }
        
        await voucherApi.create(Model).then(result => {
            if (result.success) {
                toast.success("Tạo voucher thành công");
                setShow(false);
                setShowModal(null);
            }
        });
    }
    const handleDateChange = (dates,dateStrings) => {
        console.log('Formatted date strings:', dateStrings);
        setStartDate(dateStrings[0]);
        setEndDate(dateStrings[1]);
    }
    const disabledStartDate = (current) => {
        // Vô hiệu hóa ngày trước ngày hiện tại
        return current && current < moment().startOf('day');
      };
    return (
        <CModal
            show={show}
            onClose={() => { setShow(false); setShowModal(null); setVoucherInfo({}) }}
            visible={show}
            className='modal-xl'
        >
            <CModalHeader closeButton>{type} người dùng</CModalHeader>
            <CModalBody className='p-4' >
                <CForm id='voucherForm' onSubmit={formik.handleSubmit}>
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mã khuyến mãi</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='VoucherCode' value={formik.values.VoucherCode} onChange={formik.handleChange}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên chương trình</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='EventName' value={formik.values.EventName} onChange={formik.handleChange} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Giá trị</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} type='number' max="100" min="10" name='Discount' value={formik.values.Discount} onChange={formik.handleChange}  />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Số lượng</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} name='Quantity' value={formik.values.Quantity}  onChange={handleQuantityChange}/>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Số lượng còn lại</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={'input-readonly' } name='QuantityRemain'  value={formik.values.QuantityRemain} onChange={formik.handleChange}/>
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
                                    <CFormLabel className='mt-1'>Ngày hiệu lực</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <Space direction="vertical" size={14} className={type === 'Xem' ? 'input-readonly mt-1 w-100 ' : 'mt-1 w-100 ' } >
                                        {/* <RangePicker
                                            size='large'
                                            className='z-3'
                                            value={[moment(formik.values.StartDate, 'DD/MM/YYYY'), moment(formik.values.EndDate, 'DD/MM/YYYY')]}
                                            format={dateFormat}
                                        /> */}
                                        <RangePicker
                                                size='large'
                                                defaultValue={[dayjs(formik.values.StartDate),
                                                dayjs(formik.values.EndDate)]}
                                                format={dateFormat}
                                                getPopupContainer={(triggerNode) => {
                                                return triggerNode.parentNode;
                                            }}
                                            onChange={handleDateChange}
                                            disabledDate={disabledStartDate}
                                        />

                                    </Space>
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
                                        <DatePicker size='large' className='w-100 input-readonly' name='CreatedAt' value={moment(formik.values.CreatedAt)} />
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
                                    <CFormInput className= 'input-readonly' name='CreatedBy' value={formik.values.CreatedBy}  />
                                </CCol>
                            </CRow>
                        </CCol>


                    </CRow>
                </CForm>

            </CModalBody>
            <CModalFooter>
                <CButton color="primary" type='submit' form='voucherForm'>Lưu</CButton>{' '}
                <CButton
                    color="secondary"
                    onClick={() => { setShow(false); setShowModal(null) }}
                >Đóng</CButton>
            </CModalFooter>
        </CModal>

    )
}

export default PromotionModal
