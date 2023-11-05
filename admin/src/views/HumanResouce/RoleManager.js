
import { CButton, CCardBody, CCardHeader, CRow } from '@coreui/react';
import React, { useState } from 'react'
import RoleManagerModal from './RoleManagerModal.js';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import RoleTableResult from './RoleTableResult.js';
import PermissionModal from './PermissionModal.js';

function RoleManager() {
    const tableHeaderValue = [

        {
            name: 'Mã vai trò',
            selector: row => row.roleId,
            sortable: true,
            maxWidth: "150px"
        },
        {
            name: 'Tên vai trò',
            selector: row => row.roleName,
            sortable: true
        },
        {
            name: 'Mô tả',
            selector: row => row.roleDesc,
            sortable: true
        },
        {
            name: 'Trạng thái',
            selector: row => row.roleStatus,
        },
        {
            name: 'Người tạo',
            selector: row => row.createBy,
            sortable: true,
            maxWidth: "170px"
        },
    ]
    const tableBodyValue = [
        {
            roleId: 1,
            roleName: 'Administrator',
            roleDesc: 'Quản trị hệ thống',
            roleStatus: 'Kích hoạt',
            createBy: 'Chung'
        },
        {
            roleId: 2,
            roleName: 'Sale Staff',
            roleDesc: 'Nhân viên bán hàng',
            roleStatus: 'Kích hoạt',
        },
        {
            roleId: 3,
            roleName: 'Stock Staff',
            roleDesc: 'Nhân viên kho',
            roleStatus: 'Ngừng kích hoạt',
            createBy: 'Chung'
        },
        {
            roleId: 4,
            roleName: 'IT Staff',
            roleDesc: 'Nhân viên bảo trì',
            roleStatus: 'Ngừng kích hoạt',
        },

    ];
    const tableValues = {
        tableHeaderValue,
        tableBodyValue,
    }

    const [showModal, setShowModal] = useState(null);
    const [showPerrmissionModal, setShowPermissionModal] = useState(null);
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
        } else if(type==='Phân quyền') {
            if (modalValue.selectedCount != 1) {
                return toast.info('Vui lòng chỉ chọn 1 dòng dữ liệu ')
            }
            console.log('parent',showPerrmissionModal)
            setShowPermissionModal(type)
        }
    }
    return (
        <>
            <RoleTableResult value={tableValues} selectValue={setModalValue} />
            <div className="d-flex flex-row docs-highlight mb-3 mt-3"  >
                <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Xem')} >Xem</CButton>
                <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Thêm')}>Thêm</CButton>
                <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={() => handleShowModal('Sửa')}>Sửa</CButton>
                <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }}>Xóa</CButton>
                <CButton className='mx-2 btn btn-warning' style={{ minWidth: 70 }} onClick={()=>handleShowModal('Phân quyền')}>Phân quyền</CButton>
            </div>
            <RoleManagerModal type={showModal} setShowModal={setShowModal} data={data} />
            <PermissionModal setShowModal={ setShowPermissionModal} type={showPerrmissionModal} data={data} />
        </>
    )
}

export default RoleManager
