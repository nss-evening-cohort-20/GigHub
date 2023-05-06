import React, { useContext, useEffect } from "react";
import { EventContext } from "../providers/EventProvider";

//shows a list of all events
const EventList = () => {
  const { events, getAllEvents } = useContext(EventContext);

  useEffect(() => {
    getAllEvents();
  }, []);

  return (
    <div>
      {events.map((event) => (
        <div key={event.id}>
          {/* <img src={post.imageUrl} alt={post.title} /> */}
          <p>
            <strong>{event.eventName}</strong>
          </p>
          <p>{event.eventDate}</p>
        </div>
      ))}
    </div>
  );
};

export default EventList;