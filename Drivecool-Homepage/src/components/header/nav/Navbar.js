import React, { Component } from "react";
import { NavLink } from "react-router-dom";

class Navbar extends Component {
  state = { collapsed: true, collapsing: false };

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container">
          <button
            className={
              this.state.collapsed
                ? "navbar-toggler navbar-toggler-right collapsed"
                : "navbar-toggler navbar-toggler-right"
            }
            type="button"
            onClick={() => this.toggleNavbar()}
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div
            className={
              this.state.collapsed
                ? "collapse navbar-collapse"
                : "collapse navbar-collapse show"
            }
            ref={hiddenNavbar => (this.hiddenNavbar = hiddenNavbar)}
          >
            <ul className="navbar-nav">
              <li className="nav-item">
                <NavLink exact to="/" className="nav-link">
                  Home
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/practice" className="nav-link">
                  Praxis
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/vku" className="nav-link">
                  VKU
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/theory" className="nav-link">
                  Theory
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/Aboutme" className="nav-link">
                  Über mich
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/contact" className="nav-link">
                  Kontakt
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/links" className="nav-link">
                  Links
                </NavLink>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    );
  }
}

export default Navbar;
