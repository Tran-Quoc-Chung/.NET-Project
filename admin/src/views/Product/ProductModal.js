import { CButton, CCol, CForm, CFormInput, CFormLabel, CFormSelect, CModal, CModalBody, CModalFooter, CModalHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { DatePicker, Radio, Space } from 'antd';
import { useDropzone } from 'react-dropzone';

function ProductModal(props) {
    let { type, setShowModal, data } = props;
    const [show, setShow] = useState(false);
    let value = data?.selectedRows?.[0] || null;
    const {
        acceptedFiles,
        fileRejections,
        getRootProps,
        getInputProps
    } = useDropzone({
        accept: {
            'image/jpeg': [],
            'image/png': []
        }
    });
    const acceptedFileItems = acceptedFiles.map(file => (
        <li key={file.path}>
            {file.path} - {file.size} bytes
        </li>
    ));

    const fileRejectionItems = fileRejections.map(({ file, errors }) => (
        <li key={file.path}>
            {file.path} - {file.size} bytes
            <ul>
                {errors.map(e => (
                    <li key={e.code}>{e.message}</li>
                ))}
            </ul>
        </li>
    ));
    const imgsource = [
        "https://store.storeimages.cdn-apple.com/8756/as-images.apple.com/is/ML773_VW_34FR+watch-case-45-stainless-graphite-s9_VW_34FR+watch-face-45-stainless-graphite-s9_VW_34FR?wid=2000&hei=2000&fmt=png-alpha&.v=1694507905569",
        "https://store.storeimages.cdn-apple.com/8756/as-images.apple.com/is/ML733_VW_34FR+watch-case-41-stainless-gold-s9_VW_34FR+watch-face-41-stainless-gold-s9_VW_34FR?wid=2000&hei=2000&fmt=png-alpha&.v=1694507905569",
        "https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png",
        "https://cdn.tgdd.vn/Products/Images/7077/289798/s16/apple-watch-se-2022-44mm-vien-nhom-trang-thumbtz-1-650x650.png",
    ]

    useEffect(() => {
        type !== null ? setShow(true) : setShow(false);
    }, [type]);
    console.log(acceptedFileItems)
    const getUploadParams = ({ meta }) => { return { url: 'https://httpbin.org/post' } }

    // called every time a file's `status` changes
    const handleChangeStatus = ({ meta, file }, status) => { console.log(status, meta, file) }

    // receives array of files that are done uploading when submit button is clicked
    const handleSubmit = (files) => { console.log(files.map(f => f.meta)) }

    return (
        <CModal
            show={show}
            onClose={() => { setShow(false); setShowModal(null) }}
            visible={show}
            className='modal-xl overflow-scroll max-vh-100'
            scrollable
        >
            <CModalHeader closeButton>{type} người dùng</CModalHeader>
            <CModalBody className='p-4 ' >
                <CForm >
                    <CRow>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>ID</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className='input-readonly' value={data ? value?.roleId : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tên sản phẩm</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleName : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Giá gốc</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Giá bán</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Tag</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Giới tính</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Hãng</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Xuất xứ</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Màu sắc</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Chất liệu dây</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Kích cỡ mặt kính</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mức chống nước</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Trạng thái</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormSelect name='createBy' onChange={(e) => handleFilter(e)} className={type === 'Xem' ? 'input-readonly' : ''}>
                                        <option value=""></option>
                                        <option value="Hoạt động">Mark</option>
                                        <option value="Ngưng hoạt động">Alen</option>
                                    </CFormSelect>
                                </CCol>
                            </CRow>
                        </CCol>
                        <CCol md="6" className='mb-3'>
                            <CRow>
                                <CCol md="4" >
                                    <CFormLabel className='mt-1'>Mô tả</CFormLabel>
                                </CCol>
                                <CCol md="7" >
                                    <CFormInput className={type === 'Xem' ? 'input-readonly' : ''} defaultValue={!!data ? value?.roleDesc : ''} />
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
                                        <DatePicker size='large' className='w-100 input-readonly' />
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
                                    <CFormInput className='input-readonly' defaultValue={!!data ? value?.roleDesc : ''} />
                                </CCol>
                            </CRow>
                        </CCol>

                    </CRow>
                </CForm>
                <CForm className='mt-3 border border-secondary p-3 '>
                    <CRow className=''>Hình ảnh sản phẩm</CRow>
                    <CRow>
                        <CCol md="12" className='mb-3 '>
                            <CRow>
                                <CCol md="2" >
                                    <CFormLabel className='mt-1 fw-semibold'>Thêm hình ảnh</CFormLabel>
                                </CCol>
                                <CCol md="10" >
                                    <CCol {...getRootProps({ className: 'dropzone border border-dashed border-light rounded p-2' })}>
                                        <CFormInput {...getInputProps()} />
                                        <p>Kéo thả ảnh tại đây, hoặc click để chọn ảnh (*.jpeg, .png)</p>

                                    </CCol>
                                    {acceptedFileItems && acceptedFileItems.map((file) => (
                                        <CRow>
                                            <CFormLabel className='mx-3 mt-2'>{ file.key}</CFormLabel>
                                        </CRow>
                                    ))}

                                </CCol>
                            </CRow>
                            <CRow md="12" className='mt-3'>
                                {imgsource.map((file) => (
                                    <CCol md="4" className='mt-2'>
                                        <img src={file} class="img-thumbnail" alt="Not found" />
                                    </CCol>
                                ))}
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

export default ProductModal
