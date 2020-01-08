import React, { Component } from "react";
import Logo from "./../../../assets/images/Logo.png";

class UpperMenu extends Component {
  render() {
    return (
      <div className="upper-menu d-flex align-items-center flex-wrap">
        <div className="container">
          <div className="d-flex">
            <div className="upper-menu-item mr-auto">
              <div className="d-flex align-items-center">
                <img
                  className="img img-fluid d-inline-block ml-3"
                  src={Logo}
                  alt="Drivecool Logo"
                ></img>
                <h1 className="upper-menu-link d-inline-block ml-3">
                  Drivecool
                </h1>
              </div>
            </div>
            <div className="upper-menu-item d-flex align-items-center">
              <a
                className="text-secondary upper-menu-link"
                href="tel:+41793111886"
              >
                <i className="fas fa-phone-alt upper-menu-link-icon"></i> +41 79
                311 18 86
              </a>
            </div>
            <div className="upper-menu-item d-flex align-items-center">
              <a
                className="text-secondary upper-menu-link"
                href="mailto:rolausson@hispeed.ch"
              >
                <i className="fas fa-envelope upper-menu-link-icon"></i>{" "}
                rolausson@hispeed.ch
              </a>
            </div>
            <div className="upper-menu-item d-flex align-items-center">
              <a
                className="text-secondary upper-menu-link"
                href="https://goo.gl/maps/sRjWnzVeb2uQe7wv5"
                target="_blank"
                rel="noopener noreferrer"
              >
                <i className="fas fa-map upper-menu-link-icon"></i> Länggässli
                19, 3604 Thun
              </a>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default UpperMenu;
