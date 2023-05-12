import React from "react";
import { Route, Routes } from "react-router-dom";
import './App.css';
import { NavBarHeader } from "./nav/NavBarHeader";
import { ApplicationViews } from "./components/views/ApplicationViews";

function App() {
  return <Routes>
    <Route 
      path="*"
      element={
        <>
          <NavBarHeader />
          <ApplicationViews />
        </>
      }
      />
  </Routes>
}

export default App;