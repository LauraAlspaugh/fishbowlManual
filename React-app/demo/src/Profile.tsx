import React from "react"

export default function Profile() {
    const message = 'hello World! Welcome to React Learning.'
    return (
        <div
        style={{
            columnCount: '12',
            justifyContent: 'center',
           display: 'flex'
        }}
        >
      <p style={{
       color: 'pink',
       fontFamily: 'fantasy',
       fontSize: '30px',
       padding: '5px'
      }}>
        {message}
      </p>
      <img 
      className='martini'
      src='https://images.unsplash.com/photo-1711861413115-797ee0655214?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8'></img>
      </div>
    )
  }