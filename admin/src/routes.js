import React from 'react'

const Dashboard = React.lazy(() => import('./views/dashboard/Dashboard'))
// manager
const user = React.lazy(() => import('./views/HumanResouce/UserManager'))
const role = React.lazy(() => import('./views/HumanResouce/RoleManager'))
const sales= React.lazy(()=>import('./views/Minimart/Sale/SalesManager'))
const sales_return = React.lazy(() => import('./views/Minimart/SalesReturn'))
const water_resistance = React.lazy(() => import('./views/WaterResistance/WaterResistanceManager'));
const dialsize = React.lazy(() => import('./views/DialSize/DialSizeManager'));
const dialshape = React.lazy(() => import('./views/DialShape/DialShapeManager'));
const strap_material = React.lazy(() => import('./views/StrapMaterial/StrapMaterialManager'));
const promotion = React.lazy(() => import('./views/Promotion/PromotionManager'));
const branch = React.lazy(() => import('./views/Branch/BranchManager'));
const product = React.lazy(() => import('./views/Product/ProductManager'));
const inventory_import=React.lazy(() => import('./views/Inventory Import/ImportManager'));
const inventory_check=React.lazy(() => import('./views/Inventory Check/CheckManager'));

const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', element: Dashboard },
  { path: '/user/manager', name: 'Nhân sự', element: user },
  { path: '/user/role', name: 'Phân quyền', element: role },
  { path: '/minimart/sales', name: 'Bán hàng', element: sales },
  { path: '/minimart/sale_return', name: 'Trả hàng', element: sales_return },
  { path: '/strap_material', name: 'Thông số sản phẩm / Chất liệu dây', element: strap_material },
  { path: '/dialsize', name: 'Thông số sản phẩm / Kích cỡ mặt kính', element: dialsize },
  { path: '/water_resistance', name: 'Thông số sản phẩm / Mức chống nước', element: water_resistance },
  { path: '/dialshape', name: 'Thông số sản phẩm / Dạng mặt đồng hồ', element: dialshape },
  { path: '/promotion', name: 'Khuyến mãi / Voucher', element: promotion },
  { path: '/branch', name: 'Thông số sản phẩm/ Hãng', element: branch },
  {path:'/product',name:'Sản phẩm',element:product},
  {path:'/inventory_import',name:'Sản phẩm',element:inventory_import},
  {path:'/inventory_check',name:'Sản phẩm',element:inventory_check},
]

export default routes
