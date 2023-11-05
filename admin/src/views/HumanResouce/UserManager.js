
import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState } from 'react'
import UserManagerModal from './UserManagerModal.js';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import UserTableResult from 'src/views/HumanResouce/UserTableResult.js';

function UserManager() {
  const tableHeaderValue = [

    {
      name: 'ID',
      selector: row => row.id,
      sortable: true,
      maxWidth: "100px"
    },
    {
      name: 'Tên nhân viên',
      selector: row => row.name,
      sortable: true
    },
    {
      name: 'Chức vụ',
      selector: row => row.role,
      sortable: true
    },
    {
      name: 'Số điện thoại',
      selector: row => row.phoneNumber,
    },
    {
      name: 'Trạng thái',
      selector: row => row.status,
      sortable: true,
      maxWidth: "170px"
    },
]
const tableBodyValue = [
  {
    id: 1,
    name: 'Mark',
    role: 'Manager',
    phoneNumber: '0123456',
    status: 'Hoạt động'
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
  },
  {
    "id": 20,
    "name": "Eva",
    "role": "Manager",
    "phoneNumber": "2012345",
    "status": "Hoạt động"
  },
  {
      "id": 21,
      "name": "Sophia",
      "role": "Sale staff",
      "phoneNumber": "1012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 22,
      "name": "Michael",
      "role": "Stock staff",
      "phoneNumber": "9012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 23,
      "name": "John",
      "role": "Manager",
      "phoneNumber": "4012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 24,
      "name": "William",
      "role": "Stock staff",
      "phoneNumber": "1012345",
      "status": "Hoạt động"
    },
  {
      "id": 25,
      "name": "William",
      "role": "HR Specialist",
      "phoneNumber": "3012345",
      "status": "Hoạt động"
    },
  {
      "id": 26,
      "name": "Michael",
      "role": "HR Specialist",
      "phoneNumber": "6012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 27,
      "name": "Olivia",
      "role": "IT Support",
      "phoneNumber": "5012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 28,
      "name": "John",
      "role": "Sale staff",
      "phoneNumber": "5012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 29,
      "name": "Michael",
      "role": "HR Specialist",
      "phoneNumber": "2012345",
      "status": "Hoạt động"
    },
  {
      "id": 30,
      "name": "Sophia",
      "role": "Stock staff",
      "phoneNumber": "6012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 31,
      "name": "Eva",
      "role": "IT Support",
      "phoneNumber": "3012345",
      "status": "Hoạt động"
    },
  {
      "id": 32,
      "name": "Olivia",
      "role": "Manager",
      "phoneNumber": "9012345",
      "status": "Hoạt động"
    },
  {
      "id": 33,
      "name": "John",
      "role": "Sale staff",
      "phoneNumber": "7012345",
      "status": "Hoạt động"
    },
  {
      "id": 34,
      "name": "Alice",
      "role": "Manager",
      "phoneNumber": "1012345",
      "status": "Hoạt động"
    },
  {
      "id": 35,
      "name": "Sophia",
      "role": "HR Specialist",
      "phoneNumber": "7012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 36,
      "name": "Michael",
      "role": "IT Support",
      "phoneNumber": "6012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 37,
      "name": "Eva",
      "role": "Sale staff",
      "phoneNumber": "6012345",
      "status": "Hoạt động"
    },
  {
      "id": 38,
      "name": "John",
      "role": "Manager",
      "phoneNumber": "8012345",
      "status": "Hoạt động"
    },
  {
      "id": 39,
      "name": "William",
      "role": "Manager",
      "phoneNumber": "7012345",
      "status": "Ngưng hoạt động"
    },
  {
      "id": 40,
      "name": "Sophia",
      "role": "IT Support",
      "phoneNumber": "2012345",
      "status": "Ngưng hoạt động"
    }
];
const tableValues = {
  tableHeaderValue,
  tableBodyValue,
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
    } else if (type === 'Thêm') {
      setData(null)
      setShowModal(type)
    } else {
      
    }
  }
return (
  <>
    <UserTableResult value={tableValues} selectValue={setModalValue } />
    <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem') } >Xem</CButton>
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa') }>Sửa</CButton>
      <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }}>Xóa</CButton>
    </div>
    <UserManagerModal type={showModal} setShowModal={setShowModal} data={data} />
  </>
)
}

export default UserManager
