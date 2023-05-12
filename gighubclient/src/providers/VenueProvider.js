import React, { useState } from "react";

export const VenueContext = React.createContext();

export const VenueProvider = (props) => {
  const [venues, setVenues] = useState([]);
  const [venue, setVenue] = useState([]);

  const getAllVenues = () => {
    return fetch("/venue")
      .then((res) => res.json())
      .then(setVenues);
  };

  const getVenueById = (id) => {
    return fetch("/venue/${id}")
      .then((res) => res.json())
      .then(setVenue);
  }

  const addVenue = (venue) => {
    return fetch("/venue", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(venue),
    });
  };

  return (
    <VenueContext.Provider value={{ venue, venues, getAllVenues, getVenueById, addVenue }}>
      {props.children}
    </VenueContext.Provider>
  );
};