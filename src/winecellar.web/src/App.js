import React, { useState, useEffect } from "react";
import axios from "axios";
import WineCellar from "./WineCellar/WineCellar";
import Wine from "./Wine/Wine";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import CreateWine from "./Wine/CreateWine";
import EditWine from "./Wine/EditWine";

function App() {
  return (
    <Router>
      <Routes>
      <Route path="/" element={<WineCellar />} />
        <Route path="/" element={<WineCellar />} />
        <Route path="/wine/:id" element={<Wine />} />
        <Route path="/create" element={<CreateWine />} />
        <Route path="/edit/wine/:id" element={<EditWine />} />
      </Routes>
    </Router>
  );
}

export default App;
