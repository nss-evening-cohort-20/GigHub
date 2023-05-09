import React, { useContext, useEffect } from "react";
import { ServiceContext } from "../providers/ServiceProvider";

const ServiceList = () => {
  const { service, getAllServices } = useContext(ServiceContext);

  useEffect(() => {
    getAllServices();
  }, []);

  return (
    <div>
      {service.map((service) => (
        <div key={service.id}>
          
          <p>
            <strong>{service.serviceDescription}</strong>
          </p>
          <p>{service.serviceRate}</p>
        </div>
      ))}
    </div>
  );
};

export default ServiceList;