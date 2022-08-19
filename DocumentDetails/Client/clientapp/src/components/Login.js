import { useState } from "react";
import { Button, Form, Card } from "react-bootstrap";
import useAuth from "../hooks/useAuth";
import ErrorModal from './ErrorModal';

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { login, errorMessage } = useAuth();
    const [show, setShow] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        await login(username, password);
        await setShow(true);

    }

    return (
        <>
            <ErrorModal show={show} setShow={setShow} errorMessage={errorMessage}></ErrorModal>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3">
                    <Form.Label>Username</Form.Label>
                    <Form.Control type="text" placeholder="Enter username" onInput={e => setUsername(e.target.value)} />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Enter password" onInput={e => setPassword(e.target.value)} />
                </Form.Group>
                <Button variant="primary" type="submit">Login</Button>
            </Form>
        </>
    );
}

export default Login;