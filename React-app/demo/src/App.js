import React from 'react';
import './App.css';
import Profile from './Profile.tsx';

function App() {
  return (
    <div>
      <p>
        Hello World!
      </p>
      <img 
      className='martini'
      src='https://images.unsplash.com/photo-1711861413115-797ee0655214?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8'></img>
      
      <Profile/>
    </div>
  );
}

export default App;
