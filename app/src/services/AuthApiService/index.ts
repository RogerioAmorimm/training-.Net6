import { AxiosResponse } from "axios";
import { Role } from "../../contexts/AuthContext/types/Role";
import { getAxiosInstance } from "../BaseApiService/baseApi";
import IRegisterParameter from "./intefaces/IRegisterParameter";
import ISignInParameter from "./intefaces/ISignInParameter";
import ISignInResult from "./intefaces/ISignInReturn";

const baseUrl = "http://localhost:44333/"

const axiosInstance = getAxiosInstance(baseUrl);

export const singIn = async (param: ISignInParameter): Promise<ISignInResult> => {
    const reponse = await axiosInstance.post<ISignInResult>("Login", param);
    return reponse.data;
}
export const register = async (param: IRegisterParameter): Promise<AxiosResponse<ISignInResult | string[]>> => {
    param.role = +Role[param.role];
    const reponse = await axiosInstance.post<ISignInResult>("Register", param);
    return reponse;
}
