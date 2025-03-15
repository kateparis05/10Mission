import React from 'react';
import Header from './components/Header';
import BowlerTable from './components/BowlerTable';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

function App() {
  return (
      <div className="container">
        <Header />
        <BowlerTable />
      </div>
  );
}

export default App;