import { useEffect } from "react";
import useAuth from "../hooks/useAuth";

function Home() {
    const { auth, logout, isTokenExpired } = useAuth();

    useEffect(() => {
        if (!isTokenExpired()) {
            logout();
        }
    })

    return (
        <div>You are {!auth && "not "}logged in</div>
    )
}

export default Home;