import React from "react";

export function Footer(): React.ReactElement {
  return (
    <div className="footer">
      <footer className="py-5 bg-dark fixed-bottom">
        <div className="container">
          <p className="m-0 text-center text-white">
            Copyright &copy; EnTrack 2023
          </p>
        </div>
      </footer>
    </div>
  );
}

