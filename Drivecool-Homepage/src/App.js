import React, { Component } from "react";
import { Switch, Route, matchPath, withRouter } from "react-router-dom";

import Index from "./pages/Index";
import Practice from "./pages/Practice";
import VKU from "./pages/VKU";
import Theory from "./pages/Theory";
import AboutMe from "./pages/AboutMe";
import Contact from "./pages/Contact";
import Links from "./pages/Links";
import NotFound from "./pages/NotFound";

import "./assets/scss/main.scss";
import "./assets/fonts/fontawesome/css/all.css";

import Header from "./components/header/Header";
import Footer from "./components/footer/Footer";
class App extends Component {
  render() {
    return (
      <div className="app">
        <div className="main">
          <Header
            showbanner={
              matchPath(this.props.location.pathname, {
                path: "/",
                exact: true,
                strict: false
              }) == null
                ? false
                : true
            }
          />
          <div className="py-5">
            <Switch>
              <Route path="/" exact component={Index}></Route>
              <Route path="/practice/" component={Practice}></Route>
              <Route path="/vku/" exact component={VKU}></Route>
              <Route path="/theory/" exact component={Theory}></Route>
              <Route path="/aboutme/" exact component={AboutMe}></Route>
              <Route path="/contact/" exact component={Contact}></Route>
              <Route path="/links/" exact component={Links}></Route>
              <Route component={NotFound}></Route>
            </Switch>
          </div>
        </div>
        <Footer />
      </div>
    );
  }
}

export default withRouter(App);
