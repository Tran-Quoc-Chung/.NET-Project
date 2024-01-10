import { configureStore } from '@reduxjs/toolkit'
import CartReducer from './features/CartSlice'
export default configureStore({
    reducer: {
      cart:CartReducer,
  },
})