import React, { useState } from "react";

export const EventContext = React.createContext();

export const EventProvider = (props) => {
  const [events, setEvents] = useState([]);

  const getAllEvents = () => {
    return fetch("/api/event")
      .then((res) => res.json())
      .then(setEvents);
  };

  const addEvent = (event) => {
    return fetch("/api/event", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(event),
    });
  };

  return (
    <EventContext.Provider value={{ events, getAllEvents, addEvent }}>
      {props.children}
    </EventContext.Provider>
  );
};