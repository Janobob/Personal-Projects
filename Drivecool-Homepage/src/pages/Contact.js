import React, { Component } from "react";

class Contact extends Component {
  render() {
    return (
      <div className="container">
        <h4 className="text-secondary">Kontakt</h4>
        <p>
          Kontaktiere uns, falls du Fragen hast oder dich für Praxislektionen
          oder für den VKU anmelden möchtest.
        </p>
        <form>
          <div class="form-group">
            <label for="contactoption">Kontaktgrund *</label>
            <select class="form-control" id="contactoption" required>
              <option>Anmelden für Fahrstunden</option>
              <option>Anmelden für VKU</option>
              <option>Sonstiges</option>
            </select>
          </div>
          <div class="form-group">
            <label for="contactme">Ich wünsche eine Antwort per *</label>
            <select class="form-control" id="contactme" required>
              <option>E-Mail</option>
              <option>SMS</option>
              <option>Telefon</option>
            </select>
          </div>
          <div className="row">
            <div className="col-sm-12 col-md-6">
              <div class="form-group">
                <label for="prename">Vorname *</label>
                <input
                  class="form-control"
                  id="prename"
                  placeholder="Vorname"
                  required
                />
              </div>
            </div>
            <div className="col-sm-12 col-md-6">
              <div class="form-group">
                <label for="lastname">Nachname *</label>
                <input
                  class="form-control"
                  id="lastname"
                  placeholder="Nachname"
                  required
                />
              </div>
            </div>
          </div>
          <div class="form-group">
            <label for="email">E-Mail *</label>
            <input
              type="email"
              class="form-control"
              id="email"
              placeholder="E-Mail"
              required
            />
          </div>
          <div class="form-group">
            <label for="phone">Telefon *</label>
            <input
              type="tel"
              class="form-control"
              id="phone"
              placeholder="Telefon"
              required
            />
          </div>
          <div class="form-group">
            <label for="message">Nachricht</label>
            <textarea class="form-control" id="message" rows="3"></textarea>
          </div>
          <p className="text-muted">* Pflichtfelder</p>
          <button type="submit" class="btn btn-primary">
            Abschicken
          </button>
        </form>
      </div>
    );
  }
}

export default Contact;
