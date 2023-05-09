import logo from './components/images/GigHub_logo.jpg';
import './App.css';
import { ServiceProvider } from './providers/ServiceProvider';
import ServiceList from './components/service/ServiceList';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1 className="App-title">GigHub</h1>
      </header>
      <div>
        <ServiceProvider>
          <ServiceList />
        </ServiceProvider>
      </div>
    </div>
  );
}

export default App;