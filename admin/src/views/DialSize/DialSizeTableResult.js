import React, { useState } from 'react'
import { CForm, CRow, CCol, CFormLabel, CFormInput, CFormSelect } from '@coreui/react'
import DataTable from 'react-data-table-component';
function DialSizeTableResult(props) {
    const { tableHeader, tableBody } = props.value;
    const { selectValue } = props;
    const [dataTable, setDataTable] = useState(tableBody);
    const handleFilter = (e) => {
        const { name, value } = e.target;
        const newData = tableBody.filter(row => {
            const cellValue = String(row[name]);
            return cellValue.toLowerCase().includes(value.toLowerCase());
        });
        setDataTable(newData);
        
    };
    const handleChange = (state) => {
        selectValue(state);
    };
    const tableCustomStyles = {
        headCells: {
            style: {
                fontSize: '15px',
                fontWeight: 'bold',
                //  paddingLeft: '0 8px',
                justifyContent: 'center',
                backgroundColor: '#f0f0f0',
                border: '1px solid #fafafa',
                height: "45px"
            },

        },
        rows: {
            style: {
                fontSize: '15px',
                fontWeight: 500,
                // color: theme.text.primary,
                minHeight: '48px',
                '&:not(:last-of-type)': {
                    borderBottomStyle: 'solid',
                    borderBottomWidth: '1px',
                    // borderBottomColor: theme.divider.default,
                },
            },
        },
        cells: {
            style: {
                border: '1px solid #fafafa'
            }
        },
        pagination: {
            style: {
                fontSize: '14px',
                minHeight: '47px',
                borderTopStyle: 'solid',
                borderTopWidth: '1px',
            },
            pageButtonsStyle: {
                borderRadius: '50%',
                height: '40px',
                width: '40px',
                padding: '8px',
                margin: 'px',
                cursor: 'pointer',
                transition: '0.4s',

            },
        }

    }
    return (
        <div className='container mt-5 bg-container'>
            <CForm className='mb-4 '> 
                <CRow md="8" className='mb-4 fw-bolder fs-6 ms-2'>Thông tin tìm kiếm</CRow>
                <CRow md="12">
                    <CRow className='col-md-6 mb-2'>
                        <CCol md="3" className='d-flex align-items-center'>
                            <CFormLabel className="mt-2">ID</CFormLabel>
                        </CCol>
                        <CCol md="7">
                            <CFormInput name='roleId' onChange={(e)=>handleFilter(e)}/>
                        </CCol>
                    </CRow>
                    <CRow className='col-md-6 mb-2'>
                        <CCol md="3" className='d-flex align-items-center'>
                            <CFormLabel className="mt-2">Kích thước</CFormLabel>
                        </CCol>
                        <CCol md="7">
                            <CFormInput name='roleName' onChange={(e)=>handleFilter(e)}/>
                        </CCol>
                    </CRow>
                    <CRow className='col-md-6 mb-2'>
                        <CCol md="3" className='d-flex align-items-center'>
                            <CFormLabel className="mt-2">Mô tả</CFormLabel>
                        </CCol>
                        <CCol md="7">
                        <CFormInput name='roleName' onChange={(e)=>handleFilter(e)}/>
                        </CCol>
                    </CRow>
                    <CRow className='col-md-6 mb-2'>
                        <CCol md="3" className='d-flex align-items-center'>
                            <CFormLabel className="mt-2">Người tạo</CFormLabel>
                        </CCol>
                        <CCol md="7">
                            <CFormSelect name='createBy' onChange={(e)=>handleFilter(e)}>
                                <option value=""></option>
                                <option value="Hoạt động">Mark</option>
                                <option value="Ngưng hoạt động">Alen</option>
                            </CFormSelect>
                        </CCol>
                    </CRow>
                </CRow>
            </CForm>
            <DataTable
                columns={tableHeader}
                data={dataTable}
                pagination
                fixedHeader
                selectableRows
                customStyles={tableCustomStyles}
                onSelectedRowsChange={(e)=>handleChange(e)}
            >
            </DataTable>
        </div>
    )
}

export default DialSizeTableResult
