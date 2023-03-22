import React from "react";

export function About() : React.ReactElement {
  return (
    <div className="about">
      <div className="container">
        <div className="row align-items-center my-5">
          <div className="col-lg-7">
            <img
              className="img-fluid rounded mb-4 mb-lg-0"
              src="http://placehold.it/900x400"
              alt=""
            />
          </div>
          <div className="col-lg-5">
            <h1 className="font-weight-light">About</h1>
            <p>
              Made up misson statement, could probaly move this to the footer to clean up header.
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

