import { Outlet, Route, Routes } from "react-router-dom"

export const ApplicationViews = () => {
   return(
      <Routes>
         <Route path="/" element={
            <>
               <h1>
                  Gig Hub
               </h1>

               <Outlet />
            </>
         }>

         </Route>
      </Routes>
   );
};