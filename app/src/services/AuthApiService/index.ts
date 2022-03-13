import { getAxiosInstance } from "../BaseApiService/baseApi";
import ISignInParameter from "./intefaces/ISignInParameter";
import ISignInResult from "./intefaces/ISignInReturn";

const baseUrl = "https://localhost:44333/"

const axiosInstance = getAxiosInstance(baseUrl);

export const singIn = async (param: ISignInParameter): Promise<ISignInResult> => {
    const reponse = await axiosInstance.post<ISignInResult>("Login", param);
    return reponse.data;
}