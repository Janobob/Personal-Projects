import React, { Component } from "react";

import Location from "./../assets/images/Location.jpg";
import Vehicle from "./../assets/images/Vehicle.jpg";

class AboutMe extends Component {
  render() {
    return (
      <div className="container">
        <h2>
          <b>Fahrlehrer:</b> Roland Briggen
        </h2>
        <ul className="timeline">
          <li>
            <div className="d-flex">
              <p className="text-secondary">
                <u>03.07.2013</u>
              </p>
            </div>
            <p>eidg. Fachausweis Ausbildner, Modul 1</p>
          </li>
          <li>
            <div className="d-flex">
              <p className="text-secondary">
                <u>01.01.2011</u>
              </p>
            </div>
            <p>
              Diplom vom schweizerischen Verkehrssicherheitsrat als anerkannter
              Instruktor bei der Durchführung von Kursen auf öffentlichen
              Strassen
            </p>
          </li>
          <li>
            <div className="d-flex">
              <p className="text-secondary">
                <u>01.01.2007</u>
              </p>
            </div>
            <p>
              Diplom vom schweizerischen Verkehrssicherheitsrat als anerkannter
              Instruktor von Fortbildungskursen (leichte Motorwagen)
            </p>
          </li>
          <li>
            <div className="d-flex">
              <p className="text-secondary">
                <u>14.07.2005</u>
              </p>
            </div>
            <p>Zertifikat eco-drive quality alliance als eco-drive Trainer</p>
          </li>
          <li>
            <div className="d-flex">
              <p className="text-secondary">
                <u>15.11.1994</u>
              </p>
            </div>
            <p>
              Urkunde staatlich geprüfter Fahrlehrer, Fahrlehrer-Berufsschule
              Luzern
            </p>
          </li>
        </ul>
        <hr className="my-5" />
        <h2>
          <b>Standort:</b> Selecta Automat, hinter dem Thuner Bahnhof
        </h2>
        <img className="img-fluid mt-3" alt="Standort" src={Location} />
        <hr className="my-5" />
        <h2>
          <b>Auto:</b> VW Tiguan 2.0
        </h2>
        <div className="row mt-3">
          <div className="col-md-6">
            <img className="img-fluid" src={Vehicle} alt="Auto" />
          </div>
          <div className="col-md-6">
            <h4 className="text-secondary">
              <u>Daten:</u>
            </h4>
            <p>
              <b>PS:</b> 140PS
            </p>
            <p>
              <b>Getriebe:</b> Schaltgetriebe
            </p>
            <p>
              <b>Antrieb:</b> Allrad
            </p>
            <p>
              <b>Treibstoff:</b> Diesel
            </p>
          </div>
        </div>
      </div>
    );
  }
}

export default AboutMe;
