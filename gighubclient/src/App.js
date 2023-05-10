import logo from './components/images/GigHub_logo.jpg';
import './App.css';
import { ServiceProvider } from './providers/ServiceProvider';
import ServiceList from './components/service/ServiceList';
import { Route, Routes } from 'react-router-dom';
import { NavBar } from './components/nav/NavBar';
import { ApplicationViews } from './components/views/ApplicationViews';
import { MainContext } from './providers/MainContext';

function App() {
  return (
    <Routes>
      <Route 
        path="*"
        element={
          <>
            <MainContext>
              <NavBar />
              <ApplicationViews />
            </MainContext>
          </>
        }
      />
    </Routes>
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <h1 className="App-title">GigHub</h1>
    //   </header>
    //   <div>
    //     <ServiceProvider>
    //       <ServiceList />
    //     </ServiceProvider>
    //   </div>
    // </div>
  );
}

export default App;