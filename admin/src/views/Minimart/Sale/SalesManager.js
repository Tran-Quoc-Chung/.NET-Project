
import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState } from 'react'
import SalesManagerModal from './SalesManagerModal';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import UserTableResult from 'src/views/HumanResouce/UserTableResult.js';
import SaleTable from './SalesTable';

function SalesManager() {
  const listOrderHeader = [
    {
      name: 'Số HĐ',
      selector: row => row.id,
      sortable: true,
      maxWidth: "70px"
    },
    {
      name: 'Khách hàng',
      selector: row => row.name,
      sortable: true,
      minWidth: "140px"
    },  
    {
      name: 'Ngày đặt hàng',
      selector: row => row.phoneNumber,
      minWidth: "160px",
      sortable:true
    },
    {
      name: 'Số lượng',
      selector: row => row.status,
      sortable: true,
      maxWidth: "115px",
    },
    {
      name: 'Tổng tiền',
      selector: row => row.status,
      sortable: true,
      minWidth: "150px",
    },
    {
      name: 'Ghi chú',
      selector: row => row.status,
      sortable: true,
      maxWidth: "210px",
    },
    {
      cell: (row) => (
        <>
        <button id={row.ID} className='button-table btn btn-warning'>Xem</button>
        <button className='button-table btn btn-success'>Duyệt</button>
        <button className='button-table btn btn-danger'>Từ chối</button>
        </>
      ),
      minWidth:"220px",
      ignoreRowClick: true,
      allowOverflow: true,
      button: true,
      
    },
]
const listOrderBody = [
  {
    id: 1,
    name: 'Mark',
    role: 'Manager',
    phoneNumber: '0123456',
    status: 'Hoạt động',
  },
  {
    id: 2,
    name: 'Bob',
    role: 'Stock staff',
    phoneNumber: '0123456',
    status: 'Hoạt động'
  },
  {
    id: 3,
    name: 'Alen',
    role: 'Sale staff',
    phoneNumber: '009876',
    status: 'Hoạt động'
  },
  {
    "id": 4,
    "name": "Michael",
    "role": "Stock staff",
    "phoneNumber": "5012345",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 5,
    "name": "William",
    "role": "HR Specialist",
    "phoneNumber": "8123456",
    "status": "Hoạt động"
  },
  {
    "id": 6,
    "name": "Alice",
    "role": "Manager",
    "phoneNumber": "9012345",
    "status": "Hoạt động"
  },
  {
    "id": 7,
    "name": "Eva",
    "role": "IT Support",
    "phoneNumber": "7123456",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 8,
    "name": "Sophia",
    "role": "IT Support",
    "phoneNumber": "9012345",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 9,
    "name": "William",
    "role": "Stock staff",
    "phoneNumber": "6012345",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 10,
    "name": "Daniel",
    "role": "Stock staff",
    "phoneNumber": "4012345",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 11,
    "name": "Michael",
    "role": "Manager",
    "phoneNumber": "4012345",
    "status": "Hoạt động"
  },
  {
    "id": 12,
    "name": "Olivia",
    "role": "Manager",
    "phoneNumber": "3123456",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 13,
    "name": "Sophia",
    "role": "Stock staff",
    "phoneNumber": "7012345",
    "status": "Hoạt động"
  },
  {
    "id": 14,
    "name": "John",
    "role": "Manager",
    "phoneNumber": "5012345",
    "status": "Hoạt động"
  },
  {
    "id": 15,
    "name": "Sophia",
    "role": "IT Support",
    "phoneNumber": "1012345",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 16,
    "name": "Daniel",
    "role": "Stock staff",
    "phoneNumber": "7012345",
    "status": "Hoạt động"
  },
  {
    "id": 17,
    "name": "Sophia",
    "role": "Sale staff",
    "phoneNumber": "8123456",
    "status": "Hoạt động"
  },
  {
    "id": 18,
    "name": "Michael",
    "role": "IT Support",
    "phoneNumber": "8123456",
    "status": "Ngưng hoạt động"
  },
  {
    "id": 19,
    "name": "Eva",
    "role": "HR Specialist",
    "phoneNumber": "3012345",
    "status": "Hoạt động"
  }
  
  ];
  const listInvoiceHeader = [
    {
      name: 'Số HĐ',
      selector: row => row.id,
      sortable: true,
      maxWidth: "70px"
    },
    {
      name: 'Khách hàng',
      selector: row => row.name,
      sortable: true,
      minWidth: "140px"
    },  
    {
      name: 'Ngày đặt hàng',
      selector: row => row.phoneNumber,
      minWidth: "160px",
      sortable:true
    },
    {
      name: 'Số lượng',
      selector: row => row.status,
      sortable: true,
      maxWidth: "115px",
    },
    {
      name: 'Tổng tiền',
      selector: row => row.status,
      sortable: true,
      minWidth: "150px",
    },
    {
      name: 'Ghi chú',
      selector: row => row.status,
      sortable: true,
      maxWidth: "210px",
    },
    {
      name: 'Trạng thái',
      selector: row => row.status,
      sortable: true,
      maxWidth: "210px",
    },
    {
      name: 'Nhân viên',
      selector: row => row.status,
      sortable: true,
      maxWidth: "210px",
    },
  ]
  const listInvoiceBody = [
    {
      id: 1,
      name: 'Mark',
      role: 'Manager',
      phoneNumber: '0123456',
      status: 'Hoạt động',
    },
    {
      id: 2,
      name: 'Bob',
      role: 'Stock staff',
      phoneNumber: '0123456',
      status: 'Hoạt động'
    },
    {
      id: 3,
      name: 'Alen',
      role: 'Sale staff',
      phoneNumber: '009876',
      status: 'Hoạt động'
    },
    {
      "id": 4,
      "name": "Michael",
      "role": "Stock staff",
      "phoneNumber": "5012345",
      "status": "Ngưng hoạt động"
    },
    {
      "id": 5,
      "name": "William",
      "role": "HR Specialist",
      "phoneNumber": "8123456",
      "status": "Hoạt động"
    },
  ]
const tableValues = {
  listOrderHeader,
  listOrderBody,
  }
  const tableValue2 = {
    listInvoiceHeader,
    listInvoiceBody
}
  
  const [showModal, setShowModal] = useState(null);
  const [modalValue, setModalValue] = useState({});
  const [data, setData] = useState(null);

  const handleShowModal = (type) => {
    if (type === 'Xem' || type === 'Xóa' || type === 'Sửa') {
      if (modalValue.selectedCount != 1) {
        return toast.info('Vui lòng chỉ chọn 1 dòng dữ liệu ')
      }
      setData(modalValue)
      setShowModal(type);
    }else {
      
    }
  }
return (
  <>
    <SaleTable value1={tableValues} value2={tableValue2} selectValue={setModalValue } />
    <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem') } >Xem</CButton>
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa') }>Sửa</CButton>
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }}>Xóa</CButton>
    </div>
    <SalesManagerModal type={showModal} setShowModal={setShowModal} data={data} />
  </>
)
}

export default SalesManager
