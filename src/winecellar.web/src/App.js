import React, { useState, useEffect } from "react";
import axios from "axios";
import WineCellar from "./WineCellar/WineCellar";
import Wine from "./Wine/Wine";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";

function App() {
  const [wines, setWines] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:7293/wine").then((response) => {
      setWines(response.data);
    });
  }, []);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<WineCellar wines={wines} />} />
        <Route path="/wine/:id" element={<Wine />} />
      </Routes>
    </Router>
  );
}

export default App;
