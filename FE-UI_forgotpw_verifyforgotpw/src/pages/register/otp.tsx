import { useState } from "react"
import {
    MDBBtn
} from 'mdb-react-ui-kit'
import clsx from "clsx"

import Poster from '@/assets/images/poster_1.png'
import Logo from '@/assets/images/logo.png'
import style from './styles/register.module.scss'

import OtpInput from './components/OtpInput'

const RegisterOTP = () => {

    const [otp, setOtp] = useState('');

    const handleOtpChange = (newOtp: string) => {
        setOtp(newOtp);
    }

    const handleSubmit = (e: any) => {
        e.preventDefault();
        console.log(otp);
    }

    return (
        <>
            <div className='container-fluid d-flex justify-content-center align-items-center login-register'>
                <div className='row body-login-register shadow-3'>
                    <div className='col-md-6 left-block d-none d-md-block p-0'>
                        <img src={Poster} className='img-fluid poster' alt='poster' />
                    </div>
                    <div className='col-md-6 right-block d-flex justify-content-center'>
                        <div className='right-main d-flex flex-column my-4'>
                            <div className='logo mb-4'>
                                <img src={Logo} className='img-fluid' alt='logo' />
                            </div>
                            <div className="right-content d-flex flex-column justify-content-center">
                                <div className='title title-color mb-5'>
                                    <h3 className='mb-2'>Xác thực OTP</h3>
                                    <span>Vui lòng điền mã OTP được gửi về số điện thoại</span>
                                </div>
                                <form className={clsx('mb-4 row justify-content-center', style.frmOtp)} onSubmit={(e) => handleSubmit(e)}>
                                    <OtpInput quantity={5} onComplete={handleOtpChange} />
                                    <MDBBtn type='submit' block>
                                        Giửi OTP
                                    </MDBBtn>
                                </form>
                                <div className='forgot-pass text-center'>
                                    <span>Bạn đã có tài khoản? <a href='#'>Đăng nhập</a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default RegisterOTP