import React from 'react';
import './App.css';
import Profile from './Profile.tsx';




function App() {

  return (
    <div className='page'>
      <nav className='navbar'>
        <img className='image' alt='react' src="../logo192.png"></img>
        <h1 className='react-facts'>ReactFacts</h1>
        <h2 className='project'>React Course - Project 1</h2>
      </nav>
     
      <Profile/>

     
    </div>
  );
}

export default App;
