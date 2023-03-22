import React from "react";
import { Outlet } from "react-router-dom";

export function Locations() : React.ReactElement {
  return (
    <div className="home">
      <div className="container">
        <h1 className="text-center mt-5">Plan your next trip here!</h1>
        <Outlet />
      </div>
    </div>
  );
}

