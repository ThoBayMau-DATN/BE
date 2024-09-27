import "@fortawesome/fontawesome-free/css/all.min.css"
import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import Admin from './pages/admin/index'
import User from './pages/user/index'
import Err from './pages/err/index'
import Login from './pages/login/index'
import Register from './pages/register/index';
import Header from './components/header/index'
import Footer from './components/footer';
import ForgotPWForm from "./pages/ForgotPW/components/ForgotPassword"

import './App.scss'
import VerifyForgotPWForm from "./pages/ForgotPW/components/VerifyForgotPW"
import NewPW from "./pages/ForgotPW/components/newPW"

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <User />,
      errorElement: <Err />
    },
    {
      path: "admin",
      element: <Admin />,
    },
    {
      path: "login",
      element: <Login />,
    },
    {
      path: "register",
      element: <Register />,
    },
    {
      path: "header",
      element: <Header />,
    },
    {
      path: "footer",
      element: <Footer />,
    },
    {
      path: "ForgotPWForm",
      element: <ForgotPWForm />,
    },
    {
      path: "VerifyForgotPWForm",
      element: <VerifyForgotPWForm />,
    },
    {
      path: "NewPW",
      element: <NewPW />,
    }
  ])

  return (
    <RouterProvider router={router} />
  )
}

export default App
