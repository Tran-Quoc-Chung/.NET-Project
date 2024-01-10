import { Routes, BrowserRouter, Route } from 'react-router-dom'
import Layout from './component/Layout';
import Home from './pages/Home';
import './App.scss';
import MenWatch from './pages/MenWatch';
import WomanWatch from './pages/WomanWatch';
import CoupleWatch from './pages/CoupleWatch';
import PopularWatch from './pages/PopularWatch'
import AccessoryWatch from './pages/AccessoryWatch';
import SingleProduct from './pages/SingleProduct';
import Cart from './pages/Cart';
import Payment from './pages/Payment';
import { ToastContainer } from 'react-toastify';
function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="product/woman-watch" element={<WomanWatch />} />
            <Route path="product/men-watch" element={<MenWatch />} />
            <Route path="product/couple-watch" element={<CoupleWatch />} />
            <Route path="product/popular-watch" element={<PopularWatch />} />
            <Route path="product/accessory-watch" element={<AccessoryWatch />} />
            <Route path='product/product-detail/:id' element={<SingleProduct />} />
            <Route path='user/cart' element={<Cart />} />
            <Route path='user/payment' element={<Payment />} />
          </Route>
        </Routes>
      </BrowserRouter>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
      />
    </>
  );
}

export default App;
