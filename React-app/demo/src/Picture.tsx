import React from "react";
import Modal from "./Modal";

export default function Picture() {
    const message = 'Add your picture.'
    return (
      <div>  
      <p className="profile">
      <button className="btn btn-outline-dark d-flex justify-content-center" data-bs-toggle="modal" data-bs-target="#exampleModal">{message}</button>
      </p>
            
      
      </div>
    )
  }