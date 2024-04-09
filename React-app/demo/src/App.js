import React from 'react';
import './App.css';
import Profile from './Profile.tsx';
import { Col} from "react-bootstrap/Col";

function App() {

  return (
    <div>
      <Col  sm={6} md={12}>
      <Profile/>

      </Col>
    </div>
  );
}

export default App;
