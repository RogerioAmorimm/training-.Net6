import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';
import { useNavigate } from 'react-router-dom';
import { tokenStorageKey } from '../../contexts/AuthContext';
import IDefaultServiceResponse from './interfaces/IDefaultServiceResponse';

const onRequest = (config: AxiosRequestConfig): AxiosRequestConfig => {
    const authToken = localStorage.getItem(tokenStorageKey)
    return {
        ...config,
        headers: {
            "Content-type": "Application/json",
            Authorization: authToken ? `Bearer ${authToken}` : "",
        }
    };
}
const onRequestError = (error: AxiosError): Promise<IDefaultServiceResponse<any>> => {
    console.log(error);
    return Promise.reject("Serviço indisponível no momento, tente novamente mais tarde");
}
const onResponse = (response: AxiosResponse): AxiosResponse => response;

const onResponseError = (error: AxiosError<string>): Promise<IDefaultServiceResponse<any>> => {

    const navigate = useNavigate();
    if (error?.response?.status === 401) {
        navigate("/");
    }
    return Promise.reject(error.response?.data);
}

export function getAxiosInstance(baseUrl: string): AxiosInstance {
    debugger;
    
    const axiosInstance = axios.create({ baseURL: baseUrl});
    axiosInstance.interceptors.request.use(onRequest, onRequestError);
    axiosInstance.interceptors.response.use(onResponse, onResponseError);

    return axiosInstance
}


