import { useState } from "react"
import {
    MDBBtn
} from 'mdb-react-ui-kit'
import clsx from "clsx"


import Poster from '@/assets/images/poster_1.png'
import Logo from '@/assets/images/logo.png'
import style from './styles/register.module.scss'

interface User {
    password: string,
    rePassword: string
}

const SetPassword = () => {
    const [account, setAccount] = useState<User>({
        password: '',
        rePassword: ''
    });

    const [errs, setErrs] = useState<User>({
        password: '',
        rePassword: ''
    });

    const handleChange = (e: any) => {
        const { name, value } = e.target;
        setAccount((pre) => ({
            ...pre,
            [name]: value
        }));
    }

    const spErr = (name: string, mess: string) => {
        setErrs((pre) => ({
            ...pre,
            [name]: mess
        }));
    }

    const handleCheck = (e: any) => {
        const { name, value } = e.target;
        if (name === 'password') {
            if (value === '') {
                spErr(name, `Mật khẩu không được để trống`);
            }
            else {
                spErr(name, '');
            }
        } else if (name === 'rePassword') {
            if (value === '') {
                spErr(name, `Mật khẩu không được để trống`);
            }
            else if (account.password !== account.rePassword) {
                spErr(name, `Mật khẩu không khớp`);
            } else {
                spErr(name, '');
            }
        }
    }

    return (
        <>
            <div className='container-fluid d-flex justify-content-center align-items-center login-register'>
                <div className='row body-login-register shadow-3'>
                    <div className='col-xl-6 left-block d-none d-xl-block p-0'>
                        <img src={Poster} className='img-fluid poster' alt='poster' />
                    </div>
                    <div className='col-xl-6 right-block d-flex justify-content-center'>
                        <div className='right-main d-flex flex-column my-4'>
                            <div className='logo mb-4'>
                                <img src={Logo} className='img-fluid' alt='logo' />
                            </div>
                            <div className="right-content d-flex flex-column justify-content-center">
                                <div className='title title-color mb-4'>
                                    <h3 className='m-0'>Thiết lập mật khẩu</h3>
                                </div>
                                <form className={clsx('mb-4', style.frmSetPassword)}>
                                    <div className={style.mbCInput}>
                                        <label className="form-label">Nhập mật khẩu</label>
                                        <input
                                            type="password"
                                            name="password"
                                            className={`form-control ${errs && errs.password !== '' ? 'is-invalid' : ''}`}
                                            value={account.password}
                                            onChange={(e) => handleChange(e)}
                                            onBlur={(e) => handleCheck(e)}
                                        />
                                        {errs && errs.password !== '' &&
                                            <div className={clsx('invalid-feedback', style.err)}>{errs.password}</div>
                                        }
                                    </div>
                                    <div className={style.mbCInput}>
                                        <label className="form-label">Nhập lại mật khẩu</label>
                                        <input
                                            type="password"
                                            name="rePassword"
                                            className={`form-control ${errs && errs.rePassword !== '' ? 'is-invalid' : ''}`}
                                            value={account.rePassword}
                                            onChange={(e) => handleChange(e)}
                                            onBlur={(e) => handleCheck(e)}
                                        />
                                        {errs && errs.rePassword !== '' &&
                                            <div className={clsx('invalid-feedback', style.err)}>{errs.rePassword}</div>
                                        }
                                    </div>
                                    <MDBBtn type='submit' className="mt-2" block>
                                        Xác nhận
                                    </MDBBtn>
                                </form>
                                <div className='forgot-pass text-center'>
                                    <span>Bạn đã có tài khoản? </span><a href='#'>Đăng nhập</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default SetPassword