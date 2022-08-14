import logo from './logo.svg';
import './App.css';
import { Outlet } from 'react-router-dom';
import { Nav, Navbar, Container } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Container>
        <Navbar collapseOnSelect expand="lg" bg="light" variant="light">
          <Container>
            <LinkContainer to="/">
              <Navbar.Brand>DocumentDetails</Navbar.Brand>
            </LinkContainer>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <LinkContainer to="/documents">
              <Nav.Link>Documents</Nav.Link>
            </LinkContainer>
          </Nav>
          </Navbar.Collapse>
          </Container>
        </Navbar>
        </Container>
      </header>
      <Outlet />
    </div>
  );
}

export default App;
