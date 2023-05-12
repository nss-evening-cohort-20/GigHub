import { Route, Routes } from "react-router-dom";
import { EventProvider } from "../../providers/EventProvider";
import EventList from "../event/EventList";
import { VenueProvider } from "../../providers/VenueProvider";
import VenueList from "../venue/VenueList";
import Venue from "../venue/Venue";
import AddVenue from "../venue/AddVenue";

export const ApplicationViews = () => {
    return (
        <Routes>
            <Route
                path="/"
                element={
                    <>
                    <EventProvider>
                        <EventList />
                    </EventProvider>
                    </>
                }
            ></Route>
            <Route path="venue" element={<VenueProvider><VenueList /></VenueProvider>} />
            <Route path="venue/${id}" element={<VenueProvider><Venue /></VenueProvider>} />
            <Route path="addVenue" element={<VenueProvider><AddVenue /></VenueProvider>} />
            <Route path="event" element={<EventProvider><EventList /></EventProvider>} />
        </Routes>
    );
};