import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState,useEffect } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import WaterResistanceTableResult from './PartnerTableResult';
import WaterResistanceModal from './PartnerModal';
import ModalQuestion from '../Nofitication/ModalQuestion';
import partnerApi from 'src/service/PartnerService';
import PartnerTableResult from './PartnerTableResult';
import PartnerModal from './PartnerModal';
function PartnerManager() {
  const tableHeader = [

    {
      name: 'ID',
      selector: row => row.partnerID,
      sortable: true,
      maxWidth: "100px"
    },
    {
      name: 'Email',
      selector: row => row.email,
      sortable: true
    },
    {
      name: 'Tên đối tác',
      selector: row => row.displayName,
    },
    {
      name: 'Địa chỉ',
      selector: row => row.address,
      sortable: true,
      maxWidth: "170px"
    },
    {
      name: 'Số điện thoại',
      selector: row => row.phone,
      sortable: true,
      maxWidth: "170px"
    },
  ]

  const [partner, setPartner] = useState([]);
  const [showModal, setShowModal] = useState(null);
  const [modalValue, setModalValue] = useState({});
  const [data, setData] = useState(null);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const permissionValue = JSON.parse(localStorage.getItem('permission')) || [];

  useEffect(() => {
    fetchData()
    setModalValue({});
  }, [showModal]);

  const fetchData = async () => {
    await partnerApi.getAll().then(result => setPartner(result.data))
  }
  const tableValues = {
    tableHeader,
    tableBody: partner,
  }

  const handleShowModal = (type) => {
    if (type === 'Xem' || type === 'Xóa' || type === 'Sửa') {
      if (modalValue.selectedCount != 1) {
        return toast.info('Vui lòng chỉ chọn 1 dòng dữ liệu ')
      }
      setData(modalValue)
      setShowModal(type);
    } else if (type === 'Thêm') {
      setData(null)
      setShowModal(type)
    }
  }
  const handleDeleteClick = () => {
    if (modalValue == null || modalValue.selectedCount !== 1) {
      return toast.info('Vui lòng chọn 1 dòng dữ liệu để xóa');
    }
    setIsModalVisible(true);
  };

  const handleConfirmDelete = async () => {
    await partnerApi.delete(modalValue.selectedRows[0].partnerID);
    setModalValue(null);
    await fetchData();
    setIsModalVisible(false);
  };

  const handleCancelDelete = () => {
    setIsModalVisible(false);
  };

  const hasPermission = (permission) => permissionValue.includes(permission);

    return (
      <>
        {hasPermission(26) && (
        <PartnerTableResult value={tableValues} selectValue={setModalValue } />
        )}
        <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
        {hasPermission(26) && (
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem') } >Xem</CButton>
          )}
        {hasPermission(27) && (
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
          )}
        {hasPermission(28) && (
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa') }>Sửa</CButton>
          )}
        {hasPermission(29) && (
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={()=>handleDeleteClick()}>Xóa</CButton>
          )}
        </div>
        <PartnerModal type={showModal} setShowModal={setShowModal} data={data} />
        <ModalQuestion
        visible={isModalVisible}
        setVisible={setIsModalVisible}
        title="Xóa đối tác"
        message="Bạn có chắc chắn muốn xóa đối tác này?"
        onConfirm={handleConfirmDelete}
        onCancel={handleCancelDelete} />
      </>
    )
}

export default PartnerManager
