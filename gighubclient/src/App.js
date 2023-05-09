import logo from "./components/images/GigHub_logo.jpg";
import "./App.css";
import React from "react";
import { VenueProvider } from "./providers/VenueProvider";
import VenueList from "./components/venue/VenueList";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1 className="App-title">GigHub</h1>
      </header>
      <div>
        <VenueProvider>
          <VenueList />
        </VenueProvider>
        </div>
    </div>
  );
}

export default App;
