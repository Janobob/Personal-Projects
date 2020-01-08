import React, { Component } from "react";
import UpperMenu from "./menu/UpperMenu";
import Navbar from "./nav/Navbar";
import Banner from "./banner/Banner";

class Header extends Component {
  render() {
    return (
      <header>
        <UpperMenu />
        <Navbar />
        {this.props.showbanner && <Banner />}
      </header>
    );
  }
}

export default Header;
