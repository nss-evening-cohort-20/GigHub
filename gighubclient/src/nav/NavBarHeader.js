import { Nav, Navbar, NavDropdown, Container } from "react-bootstrap";
import logo from "../components/images/GigHub_logo.jpg";

export const NavBarHeader = () => {
   return (
      <Navbar className="color-nav" variant="light" expand="lg">
        <Container>
        <img src={logo} className="App-logo" alt="logo" />
          <Navbar.Brand className="App-title" href="#home">GigHub</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="/">Home</Nav.Link>
              <Nav.Link href="venue">Venues</Nav.Link>
              <Nav.Link href="event">Events</Nav.Link>
              <Nav.Link href="user">Users</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    );
};