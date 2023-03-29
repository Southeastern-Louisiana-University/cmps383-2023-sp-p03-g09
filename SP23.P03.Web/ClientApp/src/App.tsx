import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { HomePage } from './pages/Home/HomePage';
import { NotFoundPage } from './pages/NotFoundPage'
import { About } from './pages/About'
import { Contact } from './pages/Contact'
import { Locations } from './pages/Locations/Locations'
import { Post } from './pages/Locations/Post'
import { Posts } from './pages/Locations/Posts'
import { Footer } from './components/Footer'
import { Navbar } from './components/NavigationBar/Navigation';
import Login from './components/Login';
import Signup from './components/Signup';




export function App() : React.ReactElement {
  return (
    <div className="page-container">
        <Login />
        <Signup />
        <Navbar />
        <Routes>
          <Route path="/homepage" element={<HomePage />} />
          <Route path="/about" element={<About />} />
          <Route path="/contact" element={<Contact />} />
          <Route path="/locations" element={<Locations />}>
            <Route path="" element={<Posts />} />
            <Route path=":postSlug" element={<Post />} />
          </Route>

          
          <Route path="#" element={<NotFoundPage />} />
        </Routes>
        <Footer />
    </div>
  );
}

export default App;