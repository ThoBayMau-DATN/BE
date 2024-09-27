// import React from 'react';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import "../styles/ForgotPW.scss";
import { requesrForgetPassword, senderOtp } from '@/services/api/loginApi';
import { useNavigate } from 'react-router-dom';
const schema = yup.object().shape({
  email: yup
    .string()
    .matches(/^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/, 'Email không hợp lệ')
    .required('Email là bắt buộc'),
});

const ForgotPWForm = () => {
  const navigate = useNavigate();
  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data: any) => {
    const request: requesrForgetPassword = {
      email: data.email
    }
    senderOtp(request).then((res) => {
      if (res.status === 200) {
        alert("Gửi mã otp thành công");
        navigate(`/VerifyForgotPWForm?email=${data.email}`);
        return;
      }
      alert('Gửi mã otp thất bại')
    });
  };

  return (
    <div className="mt-5">
      <div className="row align-items-center">
        <div className="col-lg-6 col-12 ">
          <div className='w-100  d-flex flex-column align-items-center'>
            <h2 className='h2-QMK'>Quên mật khẩu</h2>
            <form className="w-75 mt-4" onSubmit={handleSubmit(onSubmit)}>
              <div className="mb-4">
                <label htmlFor="email" className="form-label color-sdt">Email: </label>
                <input
                  type="text"
                  id="email"
                  autoComplete="off"
                  inputMode="numeric"
                  // pattern="[0-9]*"
                  placeholder='Vui lòng nhập emai của bạn'
                  className={`form-control ${errors.email ? 'is-invalid' : ''} rounded-pill heightinput-60 boder-color color-pla`}
                  {...register('email')}
                  onInput={(e) => {
                    const target = e.target as HTMLInputElement; // Ép kiểu e.target thành HTMLInputElement
                    target.value = target.value; // Loại bỏ tất cả ký tự không phải số
                  }}
                />
                {errors.email && (
                  <div className="invalid-feedback">{errors.email.message}</div>
                )}
              </div>

              <button type="submit" className="btn heightinput-60 btn-color w-100 mb-3 rounded-pill text-white mt-4 ">Tiếp tục</button>

              <div className="d-flex align-items-center w-100 mb-3">
                <hr className="flex-grow-1" />
                <span className="px-2 color-xam">Đăng nhập bằng</span>
                <hr className="flex-grow-1" />
              </div>

              <div className="text-center">
                {/* Hình QR code thay bằng hình mẫu bạn có */}
                <img
                  src="src/assets/images/imgforgotPW/Group1000002783.png"
                  alt="QR code"
                  className="img-fluid mb-2"
                  style={{ maxWidth: '150px' }}
                />
                <p className="mb-0 color-xam">Bạn chưa có tài khoản? <a href="#" className="dangky-color">Đăng ký</a></p>
              </div>
            </form>
          </div>

        </div>

        <div className="col-lg-6 col-12 d-flex justify-content-center align-items-center">
          {/* Thay thế src bằng link hình ảnh của bạn */}
          <img
            src="src/assets/images/imgforgotPW/Forgotpassword-rafiki.png"
            alt="Responsive"
            className="img-fluid"
          />
        </div>
      </div>
    </div>
  );
};

export default ForgotPWForm;