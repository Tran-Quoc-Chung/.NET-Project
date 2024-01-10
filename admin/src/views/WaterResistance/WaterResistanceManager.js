import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState,useEffect } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import WaterResistanceTableResult from './WaterResistanceTableResult';
import WaterResistanceModal from './WaterResistanceModal';
import waterResistanceApi from 'src/service/WaterResistanceService';
import ModalQuestion from '../Nofitication/ModalQuestion';
function WaterResistanceManager() {
  const tableHeader = [

    {
      name: 'ID',
      selector: row => row.waterResistanceID,
      sortable: true,
      maxWidth: "100px"
    },
    {
      name: 'Mức chống nước',
      selector: row => row.waterResistanceName,
      sortable: true
    },
    {
      name: 'Mô tả',
      selector: row => row.description,
    },
    {
      name: 'Người tạo',
      selector: row => row.createdBy,
      sortable: true,
      maxWidth: "170px"
    },
    {
      name: 'Ngày tạo',
      selector: row => row.createdAt,
      sortable: true,
      maxWidth: "170px"
    },
  ]

  const [waterResistance, setWaterResistance] = useState([]);
  const [showModal, setShowModal] = useState(null);
  const [modalValue, setModalValue] = useState({});
  const [data, setData] = useState(null);
  const [isModalVisible, setIsModalVisible] = useState(false);

  useEffect(() => {
    fetchData()
    setModalValue({});
  }, [showModal]);

  const fetchData = async () => {
    await waterResistanceApi.getAll().then(result => setWaterResistance(result.data))
  }
  const tableValues = {
    tableHeader,
    tableBody: waterResistance,
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
    await waterResistanceApi.delete(modalValue.selectedRows[0].waterResistanceID);
    setModalValue(null);
    await fetchData();
    setIsModalVisible(false);
  };

  const handleCancelDelete = () => {
    setIsModalVisible(false);
  };
    return (
      <>
        <WaterResistanceTableResult value={tableValues} selectValue={setModalValue } />
        <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem') } >Xem</CButton>
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa') }>Sửa</CButton>
          <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={()=>handleDeleteClick()}>Xóa</CButton>
        </div>
        <WaterResistanceModal type={showModal} setShowModal={setShowModal} data={data} />
        <ModalQuestion
        visible={isModalVisible}
        setVisible={setIsModalVisible}
        title="Xóa thông số"
        message="Bạn có chắc chắn muốn xóa thông số này?"
        onConfirm={handleConfirmDelete}
        onCancel={handleCancelDelete} />
      </>
    )
}

export default WaterResistanceManager
