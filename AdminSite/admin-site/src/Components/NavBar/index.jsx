import React, { useState } from "react";
import {
    Collapse,
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem,
    NavbarText,
} from "reactstrap";
import {
    Link
} from "react-router-dom";
export default function TopMenu() {
    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
        <Navbar color="light" light expand="md">
            <NavbarBrand><Link to='/'>Home</Link></NavbarBrand>
            <NavbarToggler onClick={toggle} />
            <Collapse isOpen={isOpen} navbar>
                <Nav className="mr-auto" navbar>
                    <NavItem>
                        <NavLink ><Link to='/brand'>Brand</Link></NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink ><Link to='/cart'>Cart</Link></NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink ><Link to='/category'>Category</Link></NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink ><Link to='/order'>Order</Link></NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink ><Link to='/product'>Product</Link></NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink ><Link to='/rate'>Rate</Link></NavLink>
                    </NavItem>
                </Nav>
                <NavbarText>Simple Text</NavbarText>
            </Collapse>
        </Navbar>
    );
}