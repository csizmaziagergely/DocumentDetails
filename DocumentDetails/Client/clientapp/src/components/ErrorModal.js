import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import 'bootstrap/dist/css/bootstrap.min.css';


function ErrorModal({ errorMessage, show, setShow }) {

    const handleClose = () => setShow(false);
    let errorIsString = typeof errorMessage =='string';
    const renderError = (field) => {
        return (
            <>
            <div>Error(s) while validating input for: {field[0]}</div>
            <ul>{field[1].map((message) => <li>{message}</li>)}</ul>
            </>
        )
    }

    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Error</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {errorMessage ? (errorIsString ? (<>{errorMessage}</>) : (Object.entries(errorMessage.errors).map(renderError))) : ("")}
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="primary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default ErrorModal;