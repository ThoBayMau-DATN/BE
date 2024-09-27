import axios from "axios"
import { API } from '../apiConfig'

export interface Account {
    phone: string,
    password: string
}
export interface requesrForgetPassword {
    email: string;
}
export interface ChangePassword {
    password: string;
    confimPassWord: string;
}

// export const postLoginApi = (account: Account) => {
//     // return axios.post(API.LOGIN, account);
// }

export const senderOtp = (modal: any) => {
    return axios.post(`${API.url}/senderOtpToEmail`, modal);
}
export const verifyOtp = (otp: string) => {
    return axios.post(`${API.url}/checkOtp?otp=${otp}`, {});
}
export const changePassword = (data: ChangePassword) => {
    return axios.post(`${API.url}/changePassword`, data);
}