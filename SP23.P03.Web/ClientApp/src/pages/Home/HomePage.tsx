import React, { useState } from 'react';
import './HomePage.css';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";




const HomePage: React.FC = () => {
  const [departureLocation, setDepartureLocation] = useState<string>("");
  const [arrivalLocation, setArrivalLocation] = useState<string>("");
  const [departureDate, setDepartureDate] = useState<Date | null>(null);
  const [arrivalDate, setArrivalDate] = useState<Date | null>(null);

  const handleDepartureLocationChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setDepartureLocation(event.target.value);
  };

  const handleArrivalLocationChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setArrivalLocation(event.target.value);
  };

  const handleDepartureDateChange = (date: Date | null) => {
    setDepartureDate(date);
  };

  const handleArrivalDateChange = (date: Date | null) => {
    setArrivalDate(date);
  };

  const handleSelectDate = () => {
    console.log(`Departure location: ${departureLocation}`);
    console.log(`Arrival location: ${arrivalLocation}`);
    console.log(`Departure date: ${departureDate}`);
    console.log(`Arrival date: ${arrivalDate}`);
  };

  return (
    
      <><div className="header">
      <div className="row align-items-center my-5">

      </div>
      <div className="col-lg-5">
        <h1 className="font-weight-light">Welcome to EnTrack!</h1>
      </div>
    </div>
    
    <div className="calendar-dropdown">
        <div className="location-dropdown">
          <label htmlFor="departure-location">Departure:</label>
          <select id="departure-location" value={departureLocation} onChange={handleDepartureLocationChange}>
            <option value="">-- Select location --</option>
            <option value="New Orleans">New Orleans</option>
            <option value="Houston">Houston</option>
            <option value="San Antonio">San Antonio</option>
            <option value="Austin">Austin</option>
            <option value="Forth Worth">Forth Worth</option>
            <option value="Dallas">Dallas</option>
            <option value="Jackson">Jackson</option>
            <option value="Baton Rouge">Baton Rouge</option>
            <option value="Hammond">Hammond</option>
          </select>
        </div>
        <div className="date-picker">
          <label htmlFor="departure-date">Departure Date:</label>
          <DatePicker id="departure-date" selected={departureDate} onChange={handleDepartureDateChange} />
        </div>
        <div className="location-dropdown">
          <label htmlFor="arrival-location">Arrival:</label>
          <select id="arrival-location" value={arrivalLocation} onChange={handleArrivalLocationChange}>
            <option value="">-- Select location --</option>
            <option value="New Orleans">New Orleans</option>
            <option value="Houston">Houston</option>
            <option value="San Antonio">San Antonio</option>
            <option value="Austin">Austin</option>
            <option value="Forth Worth">Forth Worth</option>
            <option value="Dallas">Dallas</option>
            <option value="Jackson">Jackson</option>
            <option value="Baton Rouge">Baton Rouge</option>
            <option value="Hammond">Hammond</option>
          </select>
        </div>
        <div className="date-picker">
          <label htmlFor="arrival-date">Arrival Date:</label>
          <DatePicker id="arrival-date" selected={arrivalDate} onChange={handleArrivalDateChange} />
        </div>
        <div className="submit-button">
          <button onClick={handleSelectDate}>Select Dates</button>
        </div>
      </div></>
  );
};

export default HomePage;