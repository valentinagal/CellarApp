import React from "react";
import { Link } from 'react-router-dom';

function WineCellar({ wines }) {
  return (
    <div>
      <h1>Wine Cellar</h1>
      <div className="wine-list">
        {wines.map(wine => (
          <div key={wine.id}>
            <Link to={`/wine/${wine.id}`}>
              <h2>{wine.name}</h2>
              {/* Display other information about the wine here */}
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}

export default WineCellar;
