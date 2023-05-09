import React, { useContext, useEffect } from "react";
import { EventContext } from "../../providers/EventProvider";
import "./EventList.css";

const EventList = () => {
  const { events, getAllEvents } = useContext(EventContext);


  useEffect(() => {
    getAllEvents();
  }, []);

  return (
    <div className="event-list">
    <div className="page-title">Upcoming Gigs</div>
        <div className="event-container">
          {events.map((event) => (
            <div key={event.id}>
              <div className="event-card">
                <div className="event-detail-item">{event.eventDate}</div>
                <div className="event-detail-item">{event.eventName}</div>
                <div className="event-detail-item">{event.venue.venueName}</div>
            </div>
            </div>
          ))}
        </div>
    </div>
)};

export default EventList;