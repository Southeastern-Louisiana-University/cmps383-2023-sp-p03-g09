import React from "react";
import { Link } from "react-router-dom";

export function Posts() : React.ReactElement {
  return (
    <div className="home">
      <div className="container">
        <Link to="/locations/this-is-a-post-title">
          <div className="row align-items-center my-5">
            <div className="col-lg-7">
              <img
                className="img-fluid rounded mb-4 mb-lg-0"
                src="http://placehold.it/900x400"
                alt=""
              />
            </div>
            <div className="col-lg-5">
              <h1 className="font-weight-light">EnTrac is now serving X locations nationwide!</h1>
              <p>
                Click here for more information
              </p>
            </div>
          </div>
        </Link>
      </div>
    </div>
  );
}

