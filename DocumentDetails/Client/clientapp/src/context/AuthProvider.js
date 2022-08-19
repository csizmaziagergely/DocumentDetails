import { createContext } from "react";
import { useState } from "react";
import axios from "../fetch/axiosInstance";
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";

export const AuthContext = createContext({});

function AuthProvider({ children }) {
    const AUTH_ENDPOINT = "/api/auth"
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));
    const [errorMessage, setErrorMessage] = useState(null);
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
            setErrorMessage(error.response.data);
            /* if (typeof error.response.data == 'string') {
                alert(error.response.data);
            } else {
                for (const [field, errorMessages] of Object.entries(error.response.data.errors)) {
                    let errorString = `Error occured while validating input for: ${field}`;
                    for (const message of errorMessages) {
                        errorString += ` Error message: ${message}`;
                    }
                    alert(errorString);
                }
            } */
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


    return (
        <AuthContext.Provider value={{ auth, login, logout, isTokenExpired, errorMessage }}>
            {children}
        </AuthContext.Provider>
    );
}

export default AuthProvider;