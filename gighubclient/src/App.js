import React from "react";
import "./App.css";
import { EventProvider } from "./providers/EventProvider";
import EventList from "./components/EventList";
import { EventForm } from "./components/events/EventForm";
import logo from "./components/images/GigHub_logo.jpg";
import { VenueProvider } from "./providers/VenueProvider";
import VenueList from "./components/VenueList";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <div>
        <EventProvider>
          <EventForm />
          <EventList />
        </EventProvider>
      </div>
    </div>
  );
}

export default App;