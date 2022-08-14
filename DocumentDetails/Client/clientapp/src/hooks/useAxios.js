import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "../fetch/axiosInstance";

function useAxios() {
    const navigate = useNavigate();

    useEffect(() => {
        const requestIntercept = axios.interceptors.request.use(
            config => {
                return config;
            }, error => Promise.reject(error)
        );
        const responseIntercept = axios.interceptors.response.use(
            response => {
                return response;
            }, error => {
                navigate("/");
                return Promise.reject(error);
            }
        )

        return () => {
            axios.interceptors.request.eject(requestIntercept);
            axios.interceptors.response.eject(responseIntercept);
        }
    })
    return axios;
}

export default useAxios;