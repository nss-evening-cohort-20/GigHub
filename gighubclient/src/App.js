import React from "react";
import "./App.css";
import { EventProvider } from "./providers/EventProvider";
import EventList from "./components/EventList";

function App() {
  return (
    <div className="App">
      <EventProvider>
        <EventList />
      </EventProvider>
    </div>
  );
}

export default App;