import React, { useContext, useEffect } from "react";
import { VenueContext } from "../providers/VenueProvider";

const VenueList = () => {
  const { venues, getAllVenues } = useContext(VenueContext);

  useEffect(() => {
    getAllVenues();
  }, []);

  return (
    <div>
      {venues.map((venue) => (
        <div key={venue.id}>
          <p>
            <strong>{venue.venueName}</strong>
            <div>{venue.venueDescription}</div>
                <ul>
                    <li>Zip Code: {venue.venueZipcode}</li>
                    <li>Capacity: {venue.capacity}</li>
                    <li>Venue Rate: ${venue.venueRate} per event</li>
                </ul>
                {/* <div>For More Info Contact: 
                    <ul>
                        <li>Name: {venue.user.userName}
                            Email: {venue.user.email}
                            Phone: {venue.user.phone}
                            Social Media: {venue.user.socialMedia}
                        </li>
                    </ul>
                </div> */}
            </p>
        </div>
      ))}
    </div>
  );
};

export default VenueList;