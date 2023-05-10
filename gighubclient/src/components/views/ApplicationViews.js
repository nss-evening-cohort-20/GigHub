import { Outlet, Route, Routes } from "react-router-dom"
import VenueList from "../venue/VenueList"
import { VenueProvider } from "../../providers/VenueProvider"

export const ApplicationViews = () => {
   
   return (
      <Routes>
         <Route path="/" element={
            <>
               <h1>Gig Hub</h1>

               <Outlet />
            </>
         }>

         </Route>
            <Route path="/venues" element={<VenueProvider><VenueList /></VenueProvider>} />
      </Routes>
   )
}