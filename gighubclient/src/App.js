import logo from "./components/images/GigHub_logo.jpg";
import "./App.css";
import React from "react";
import { EventProvider } from "./providers/EventProvider";
import EventList from "./components/event/EventList";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1 className="App-title">GigHub</h1>
      </header>
      <div>
        <EventProvider>
          <EventList />
        </EventProvider>
        </div>
    </div>
  );
}

export default App;
