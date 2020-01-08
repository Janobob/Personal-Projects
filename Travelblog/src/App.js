import React from 'react';
import 'semantic-ui-css/semantic.min.css';
import "./assets/scss/main.scss";

import { Header, Container, Button, Icon } from "semantic-ui-react";

import Vietnam from "./assets/images/header/vietnam.jpg";
import Nepal from "./assets/images/header/nepal.jpg";
import Japan from "./assets/images/header/japan.jpg";
import India from "./assets/images/header/india.jpg";

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      countries: [
        { Name: "Vietnam", Image: Vietnam, Description: "Vietnam gehört zu den vielseitigsten Reisezielen Südostasiens. Ob Nationalparks, langgezogene Strände, spektakuläre Gebirge, riesige Höhlen, dichter Dschungel oder das einzigartige Mekong-Delta – die Natur präsentiert sich attraktiv und abwechslungsreich und kann zu Fuß, mit dem Fahrrad oder auf dem Wasser erkundet werden." },
        { Name: "Nepal", Image: Nepal, Description: "Die höchsten Berge der Welt werden häufig als „das Dach der Welt“ beschrieben und so fühlt man sich auch, wenn man einen der Giganten erklimmt – als wäre man an der oberen Spitze unserer Erde angekommen. Neben eindrucksvollen Landschaften bietet Ihnen Nepal auch eine bunte Mischung an Kulturen." },
        { Name: "Japan", Image: Japan, Description: "Traditionelle Ryokans in Japan treffen auf moderne Bauten mit schillernden Werbetafeln. Zwischen Fast-Food-Ketten gibt es hübsche Restaurants mit Köchen, die die japanischen Köstlichkeiten sorgfältig zubereiten und kunstvoll anrichten." },
        { Name: "Indien", Image: India, Description: "Indien gehört gar nicht zu Südostasien, steht aber ebenfalls auf der Liste vieler Südostasien-Reisender. Und wer dann endlich dort war, will entweder nie mehr hin oder wird regelrecht süchtig nach diesem bunten und lauten Hexenkessel." }
      ],
      currentIndex: 0
    };
  }

  componentDidMount() {
    this.state.countries.forEach((element) => {
      new Image().src = element.Image;
    });
  }

  handleScroll = e => {
    let current = this.state.currentIndex;
    //up
    if (e.deltaY < 0) {
      current--;
      if (current < 0) {
        current = 0;
      }
    }
    //down
    else {
      current++;
      if (current > this.state.countries.length - 1) {
        current = this.state.countries.length - 1;
      }
    }
    this.setState({
      currentIndex: current
    });
  }

  render() {
    return (<div className="presenter" style={{ backgroundImage: "url(" + this.state.countries[this.state.currentIndex].Image + ")" }} onWheel={this.handleScroll} >
      <Container className="scroll-container" style={{ marginTop: this.state.currentIndex * -42 + "vh" }}>
        {
          this.state.countries.map((country, i) => {
            return (
              <div className={"country-container" + (i === this.state.currentIndex ? " active" : "")} >
                <div className="country-spacer">
                  <Header className="country-name text-uppercase" size='huge'>{country.Name}</Header>
                  <div className="country-info-container">
                    <div className="country-relative-info">
                      <p className="country-description white text-bold">{country.Description}</p>
                      <Button animated basic color="white" className="country-button">
                        <Button.Content visible>
                          Erkunde {country.Name}
                        </Button.Content>
                        <Button.Content hidden>
                          <Icon name='arrow right' />
                        </Button.Content>
                      </Button>
                    </div>
                  </div>
                </div>
              </div>);
          })
        }
      </Container>
    </div >);
  }
}

export default App;
