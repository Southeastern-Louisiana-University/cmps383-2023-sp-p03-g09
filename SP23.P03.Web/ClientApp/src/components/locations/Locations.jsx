import React from "react";
import { Outlet } from "react-router-dom";

function Locations() {
  return (
    <div className="home">
      <div class="container">
        <h1 className="text-center mt-5">Plan your next trip here!</h1>
        <Outlet />
      </div>
    </div>
  );
}

export default Locations;