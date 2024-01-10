import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState,useEffect } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import BranchTableResult from './BranchTableResult';
import BranchModal from './BranchModal';
import brandApi from 'src/service/BrandService';
import ModalQuestion from '../Nofitication/ModalQuestion';

function BranchManager() {
  const tableHeader = [

    {
      name: 'Mã hãng',
      selector: row => row.brandID,
      sortable: true,
      maxWidth: "130px"
    },
    {
      name: 'Tên hãng',
      selector: row => row.brandName,
      sortable: true
    },
    {
      name: 'Xuất xứ',
      selector: row => row.origin,
      sortable: true
    },
    {
      name: 'Mô tả',
      selector: row => row.description,
    },
    {
      name: 'Ngày tạo',
      selector: row => row.createdAt,
      sortable: true,
      maxWidth: "170px"
    },
    {
      name: 'Người tạo',
      selector: row => row.createdBy,
      sortable: true,
      maxWidth: "170px"
    },
  ]

  const [showModal, setShowModal] = useState(null);
  const [modalValue, setModalValue] = useState({});
  const [data, setData] = useState(null);
  const [allBrand, setAllBrand] = useState([]);
  const [isModalVisible, setIsModalVisible] = useState(false);

  useEffect(() => {
    fetchData()
    setModalValue({});

  }, [showModal]);
  const fetchData = async () => {
    await brandApi.getAll().then(result => setAllBrand(result.data))
  }
  const tableValues = {
    tableHeader,
    tableBody: allBrand,
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
    } else {

    }
  }
  const handleDeleteClick = () => {
    if (modalValue == null || modalValue.selectedCount !== 1) {
      return toast.info('Vui lòng chọn 1 dòng dữ liệu để xóa');
    }
    setIsModalVisible(true);
  };

  const handleConfirmDelete = async () => {
    await brandApi.delete(modalValue.selectedRows[0].dialSizeID);
    setModalValue(null);
    await fetchData();
    setIsModalVisible(false);
  };

  const handleCancelDelete = () => {
    setIsModalVisible(false);
  };
  return (
    <>
      <BranchTableResult value={tableValues} selectValue={setModalValue} />
      <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem')} >Xem</CButton>
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa')}>Sửa</CButton>
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleDeleteClick()}>Xóa</CButton>
      </div>
      <BranchModal type={showModal} setShowModal={setShowModal} data={data} />
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

export default BranchManager
