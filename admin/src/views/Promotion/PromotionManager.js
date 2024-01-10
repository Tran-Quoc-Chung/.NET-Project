import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useEffect, useState } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import PromotionTableResult from './PromotionTableResult';
import PromotionModal from './PromotionModal';
import voucherApi from 'src/service/VoucherService';

function PromotionManager() {
  const [allVoucher, setAllVoucher] = useState();
  const [showModal, setShowModal] = useState(null);
  const [modalValue, setModalValue] = useState({});
  const [data, setData] = useState(null);
  const permissionValue = JSON.parse(localStorage.getItem('permission')) || [];

  useEffect(() => {
    fetchData();
  }, []);
  useEffect(() => {
    fetchData();
  },[showModal])
  const fetchData = async () => {
    await voucherApi.getAll().then(result => {
      setAllVoucher(result.data)
    });
  }
  const tableHeaderValue = [

    {
      name: 'Mã khuyến mãi',
      selector: row => row.voucherCode,
      sortable: true,
      maxWidth: "100px"
    },
    {
      name: 'Tên chương trình',
      selector: row => row.eventName,
      sortable: true
    },
    {
      name: 'Giá trị',
      selector: row => row.discount,
      sortable: true,
      cell:(row)=>(`${row.discount * 100 } %`)
    },
    {
      name: 'Mô tả',
      selector: row => row.description,
    },
    {
      name: 'Ngày bắt đầu',
      selector: row => row.startDate,
    },
    {
      name: 'Ngày kết thúc',
      selector: row => row.endDate,
    },
    {
      name: 'Số lượng',
      selector: row => row.quantity,
      sortable: true
    }
  ]

  const tableValues = {
    tableHeaderValue: tableHeaderValue,
    tableBodyValue: allVoucher,
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
  const hasPermission = (permission) => permissionValue.includes(permission);

  
  return (
    <>
      <PromotionTableResult value={tableValues} selectValue={setModalValue} />
      <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
        {hasPermission(18) && (
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem')} >Xem</CButton>
        )}
        {hasPermission(19) && (
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
        )}
        {hasPermission(20) && (
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa')}>Sửa</CButton>
        )}
        {hasPermission(21) && (
        <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }}>Xóa</CButton>
        )}
      </div>
      <PromotionModal type={showModal} setShowModal={setShowModal} data={data} />
    </>
  )
}

export default PromotionManager
