import React, { useEffect, useRef, useState } from 'react'; import "../styles/ForgotPW.scss";
import { requesrForgetPassword, senderOtp, verifyOtp } from '@/services/api/loginApi';
import { useNavigate, useSearchParams } from 'react-router-dom';

const VerifyForgotPWForm = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const email: string = searchParams.get('email') as string;

  const inputRefs = useRef<(HTMLInputElement | null)[]>([]);
  const [countdown, setCountdown] = useState(() => {
    const savedTime = localStorage.getItem('countdown');
    return savedTime ? parseInt(savedTime, 10) : 180; // Nếu có thời gian đã lưu, sử dụng nó; nếu không, mặc định là 180 giây
  });
  useEffect(() => {
    const timer = setInterval(() => {
      setCountdown(prev => {
        if (prev <= 0) {
          clearInterval(timer);
          localStorage.removeItem('countdown'); // Xóa thời gian khi đếm xong
          return 0; // Ngăn không cho giá trị âm
        }
        const newTime = prev - 1;
        localStorage.setItem('countdown', newTime.toString()); // Lưu thời gian còn lại vào localStorage
        return newTime;
      });
    }, 1000);

    return () => {
      clearInterval(timer); // Dọn dẹp timer
      localStorage.setItem('countdown', countdown.toString()); // Lưu thời gian khi component bị hủy
    };
  }, [countdown]);
  const minutes = String(Math.floor(countdown / 60)).padStart(2, '0');
  const seconds = String(countdown % 60).padStart(2, '0');

  const handleInputChange = (index: number, e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.value.length === 1 && index < 3) {
      inputRefs.current[index + 1]?.focus();
    }
    if (e.target.value.length === 0 && index > 0) {
      inputRefs.current[index - 1]?.focus();
    }
  };

  const sumbitOtp = () => {
    const otpInput: string[] = inputRefs.current.map(ref => ref?.value) as string[];
    const otp = otpInput.join('');
    verifyOtp(otp).then((res) => {
      if (res.data) {
        navigate(`/NewPW?otp=${otp}`);
        return;
      }
      alert('otp hết hạn')
    })
  }

  const resetOtp = () => {
    const request: requesrForgetPassword = {
      email: email
    }
    senderOtp(request).then((res) => {
      if (res.status === 200) {
        alert("Gửi mã otp thành công");
        return;
      }
      alert('Gửi mã otp thất bại')
    });
  }

  return (
    <div className="mt-5">
      <div className="row align-items-center">
        <div className="col-lg-6 col-12 d-flex flex-column align-items-center">
          <div className='w-75 d-flex flex-column align-items-center'>
            <h2 className='h2-QMK'>Xác minh</h2>
            <p className='color-xam'>Vui lòng nhập mã được gửi đến 0123456789</p>

            <div className="d-flex justify-content-between mb-3 mt-4">
              {[0, 1, 2, 3].map((index) => (
                <input
                  key={index}
                  type="text"
                  maxLength={1}
                  className="form-control text-center mx-1 rounded-circle input-xacminh"
                  ref={(el) => (inputRefs.current[index] = el)}
                  onChange={(e) => handleInputChange(index, e)}
                  onKeyDown={(e) => {
                    if (e.key === 'Backspace' && index > 0 && e.currentTarget.value === '') {
                      inputRefs.current[index - 1]?.focus();
                    }
                  }}
                />
              ))}
            </div>

            <div className="mb-3">
              <p className="time-text">{minutes}:{seconds}</p>
            </div>

            <p className='color-xam'>Bạn chưa nhận được mã? <a onClick={resetOtp} className='dangky-color cursor-pointer'>Gửi lại</a></p>

            <button type="submit" className="btn btn-color w-100 rounded-pill text-white heightinput-60 mt-4" onClick={sumbitOtp}>Tiếp tục</button>
          </div>
        </div>

        <div className="col-lg-6 col-12 d-flex justify-content-center align-items-center">
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

export default VerifyForgotPWForm;