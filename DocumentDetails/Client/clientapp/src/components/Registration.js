import React from 'react';
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import { Button, Card } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import useAxios from '../hooks/useAxios';


function Registration() {
    const axiosInstance = useAxios();
    const url = `${process.env.REACT_APP_HOST_URL}/api/users`;

    const [isPendingAdd, setIsPendingAdd] = useState(false);

    const [postUserName, setPostUserName] = useState('');
    const [postPassword, setPostPassword] = useState('');
    let navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newUser = { "userName": postUserName, "password": postPassword };
        setIsPendingAdd(true);
        try {
            const response = await axiosInstance.post(url, newUser)
            //response should send back the created object
            setPostUserName('');
            setPostPassword('');
        } catch (err) {
            console.log(`Error: ${err.message}`);
        }
        navigate("../login")
    }


    return (
        <>
        <Form onSubmit={(e)=>{handleSubmit(e)}} className="form">
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Username:</Form.Label>
                <Form.Control 
                    type="text" 
                    placeholder="Enter username" 
                    required 
                    value={postUserName} 
                    onChange={(e) => setPostUserName(e.target.value)} 
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Password:</Form.Label>
                <Form.Control 
                    type="text" 
                    placeholder="Enter phone number" 
                    required 
                    value={postPassword} 
                    onChange={(e) => setPostPassword(e.target.value)} 
                />
            </Form.Group>
            {!isPendingAdd && <Button variant="primary" type="submit">Registration</Button>}
            {isPendingAdd && <button><LoadingSpin /></button>}
        </Form>
        </>
    )
}

export default Registration

