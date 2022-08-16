import { useState } from "react";
import axios from "../fetch/axiosInstance";
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";

const AUTH_ENDPOINT = "/api/auth"

function useAuth() {
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));
    const navigate = useNavigate();

    const login = async(username, password) => {
        try {
            const response = await axios.post(AUTH_ENDPOINT + "/login", {username, password});
            if (response.data && response.status === 200) {
                setAuth(response.data);
                localStorage.setItem("auth", JSON.stringify(response.data));
                navigate("/");
            }
        } catch (error) {
            if (error.response) {
                alert(error.response.data);
            } else {
                throw new Error(error.toJSON())
            }
        }
    }

    const logout = () => {
        setAuth(null);
        localStorage.removeItem("auth");
        navigate("/");
    }

    const isTokenExpired = () => {
        if (!auth) {
            return true
        }
        const { exp } = jwtDecode(auth?.accessToken)

        return (Date.now() < exp * 1000)
    }

    return { auth, login, logout, isTokenExpired };
}

export default useAuth;