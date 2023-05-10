import React, { useState } from "react";

export const EventContext = React.createContext();

export const EventProvider = (props) => {
  const [events, setEvents] = useState([]);

  const getAllEvents = () => {
    return fetch("/event")
      .then((res) => res.json())
      .then(setEvents);
  };

  const addEvent = (event) => {
    return fetch("/event", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(event),
    });
  };

  const editEvent = (event) => {
    return fetch("/event/{id}", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(event),
    });
  };

  // const getEventById = (event) => {
  //   return fetch("/api/event/{id}", {
  //     method: "GET",
  //     headers: {
  //       "Content-Type": "application/json",
  //     },
  //     body: JSON.stringify(event),
  //   });
  // };

  const deleteEvent = (event) => {
    return fetch("/event/{id}", {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(event),
    });
  };





  return (
    <EventContext.Provider value={{ events, getAllEvents, addEvent, editEvent, deleteEvent }}>
      {props.children}
    </EventContext.Provider>
  );
};