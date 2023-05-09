import React, { useState } from "react";

export const ServiceContext = React.createContext();

export const ServiceProvider = (props) => {
  const [service, setService] = useState([]);

  const getAllServices = () => {
    return fetch("/services")
      .then((res) => res.json())
      .then(setService);
  };

  const addNewService = (service) => {
    return fetch("/api/services", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(service),
    });
  };

  return (
    <ServiceContext.Provider value={{ service, getAllServices, addNewService }}>
      {props.children}
    </ServiceContext.Provider>
  );
};