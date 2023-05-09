import React from "react";
import "./App.css";
import { ServiceProvider } from "./providers/ServiceProvider";
import ServiceList from "./components/ServiceList";

function App() {
  return (
    <div className="App">
      <ServiceProvider>
        <ServiceList />
      </ServiceProvider>
    </div>
  );
}

export default App;