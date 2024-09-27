import React, { useState } from 'react';
import "../styles/ForgotPW.scss";
import { changePassword, ChangePassword } from '@/services/api/loginApi';

const NewPW = () => {
  const [showPasswordCf, setShowPasswordCf] = useState(false);
  const [password, setPassword] = useState('');
  const [passwordCf, setPasswordCf] = useState('');
  const [error, setError] = useState({
    password: '',
    passwordCf: '',
    submitError: ''
  });

  // Hàm kiểm tra mật khẩu mới
  const validatePassword = (value: string): string => {
    if (value.length < 8) {
      return 'Mật khẩu phải có ít nhất 8 ký tự.';
    }
    if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
      return 'Mật khẩu phải chứa ít nhất một ký tự đặc biệt.';
    }
    if (!/\d/.test(value)) {
      return 'Mật khẩu phải chứa ít nhất một chữ số.';
    }
    return '';
  };

  // Hàm xử lý khi submit
  const onSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const passwordError = validatePassword(password);
    const passwordCfError = password !== passwordCf ? 'Mật khẩu xác nhận không khớp.' : '';

    if (passwordError || passwordCfError) {
      setError({
        password: passwordError,
        passwordCf: passwordCfError,
        submitError: ''
      });
      return;
    }

    const request: ChangePassword = {
      password: password,
      confimPassWord: passwordCf,
    };

    changePassword(request).then((res) => {
      if (res.data) {
        alert('Thay đổi mật khẩu thành công');
      } else {
        setError({ ...error, submitError: 'Thay đổi mật khẩu thất bại' });
      }
    }).catch(() => {
      setError({ ...error, submitError: 'Có lỗi xảy ra khi thay đổi mật khẩu' });
    });
  };

  return (
    <div className="mt-5">
      <div className="row align-items-center">
        <div className="col-lg-6 col-12 ">
          <div className='w-100  d-flex flex-column align-items-center'>
            <h2 className='h2-QMK'>Mật khẩu mới</h2>
            <form className="w-75 mt-4" onSubmit={onSubmit}>
              <div className="mb-2">
                <label htmlFor="password" className="form-label color-sdt">Mật khẩu mới: </label>
                <input
                  type="password"
                  id="password"
                  autoComplete="off"
                  inputMode="text"
                  placeholder='Gồm 8 ký tự, có chứa ký tự đặc biệt và ký tự số'
                  className={`form-control rounded-pill heightinput-60 boder-color color-pla ${error.password ? 'is-invalid' : ''}`}
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
                {error.password && <div className="invalid-feedback">{error.password}</div>}
              </div>
              <div className="mb-4">
                <label htmlFor="passwordcf" className="form-label color-sdt">Xác nhận mật khẩu: </label>
                <div className='d-flex align-items-center justify-content-end'>
                  <input
                    type={showPasswordCf ? "text" : "password"}
                    id="passwordcf"
                    autoComplete="off"
                    placeholder='Vui lòng nhập lại mật khẩu'
                    className={`form-control rounded-pill heightinput-60 boder-color color-pla ${error.passwordCf ? 'is-invalid' : ''}`}
                    value={passwordCf}
                    onChange={(e) => setPasswordCf(e.target.value)}
                  />
                  <i
                    className={`fa-solid ${showPasswordCf ? 'fa-eye-slash' : 'fa-eye'} icon-password`}
                    onClick={() => setShowPasswordCf(!showPasswordCf)}
                  ></i>
                </div>
                {error.passwordCf && <div className="invalid-feedback">{error.passwordCf}</div>}
              </div>

              <button type="submit" className="btn heightinput-60 btn-color w-100 mb-3 rounded-pill text-white mt-4 ">Xác nhận</button>
              {error.submitError && <div className="text-danger mt-3">{error.submitError}</div>}
            </form>
          </div>
        </div>
        <div className="col-lg-6 col-12 d-flex justify-content-center align-items-center">
          <img
            src="src/assets/images/imgforgotPW/Forgotpw_3_1.png"
            alt="Responsive"
            className="img-fluid"
          />
        </div>
      </div>
    </div>
  );
};

export default NewPW;
