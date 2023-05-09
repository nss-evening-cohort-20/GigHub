import React, { useContext, useEffect } from "react";
import { VenueContext } from "../../providers/VenueProvider";
import "./VenueList.css";

const VenueList = () => {
  const { venues, getAllVenues } = useContext(VenueContext);


  useEffect(() => {
    getAllVenues();
  }, []);

  return (
    <div className="venue-list">
    <div className="page-title">Participating Venues</div>
        <div className="venue-container">
          {venues.map((venue) => (
            <div key={venue.id}>
              <div className="venue-card">
                <h3>{venue.venueName}</h3>
                <div className="venue-description">{venue.venueDescription}</div>
                    <div className="venue-details">
                        <p className="venue-detail-item">Zip Code: {venue.venueZipcode}</p>
                        <p className="venue-detail-item">Capacity: {venue.capacity}</p>
                        <p className="venue-detail-item">Venue Rate: ${venue.venueRate} per event</p>
                    </div>
                    {venue.users.map((user) => {
                        return (
                          <div className="contact-info-container">
                            <div className="contact-info-title">For More Info Contact:</div> 
                              <div className="contact-info">
                                <p className="contact-info-item">Name: {user.userName}</p>
                                <p className="contact-info-item">Email: {user.email}</p>
                                <p className="contact-info-item">Phone: {user.phone}</p>
                                <p className="contact-info-item">Social Media: {user.socialMedia}</p>
                              </div>
                          </div>
                        )
                    })}
                </div>
            </div>
          ))}
        </div>
    </div>
)};

export default VenueList;