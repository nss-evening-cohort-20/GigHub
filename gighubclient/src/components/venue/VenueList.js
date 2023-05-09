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
    <h1 className="page-title">Participating Venues</h1>
        <div className="venue-container">
          {venues.map((venue) => (
            <div key={venue.id}>
              <p className="venue-card">
                <h3>{venue.venueName}</h3>
                <div>{venue.venueDescription}</div>
                    <ul>
                        <li className="venue-details">Zip Code: {venue.venueZipcode}</li>
                        <li className="venue-details">Capacity: {venue.capacity}</li>
                        <li className="venue-details">Venue Rate: ${venue.venueRate} per event</li>
                    </ul>
                    {venue.users.map((user) => {
                        return (
                            <div>For More Info Contact: 
                                <ul className="venue-user-details">
                                    <li>Name: {user.userName}</li>
                                    <li>Email: {user.email}</li>
                                    <li>Phone: {user.phone}</li>
                                    <li>Social Media: {user.socialMedia}</li>
                                </ul>
                            </div> 
                        )
                    })}
                </p>
            </div>
          ))}
        </div>
    </div>
)};

export default VenueList;