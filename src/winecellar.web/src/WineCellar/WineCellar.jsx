import React from "react";
import { Link } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

function WineCellar({ wines }) {
  return (
    <div>
      <h1>Wine Cellar</h1>
      <div className="wine-list">
        {wines.map((wine) => (
          <Card key={wine.id} style={{ width: "18rem" }}>
            <Card.Img
              variant="top"
              src="https://as2.ftcdn.net/v2/jpg/00/63/14/57/1000_F_63145794_cND2i7uzm0cvOixQrODxSn9YT8Fia7J3.jpg"
            />
            <Card.Body>
              <Card.Title>Card Title</Card.Title>
              <Card.Text>
                Some quick example text to build on the card title and make up
                the bulk of the card's content.
              </Card.Text>

              <Link to={`/wine/${wine.id}`}>
                <Button variant="primary">Go somewhere</Button>
              </Link>
            </Card.Body>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default WineCellar;

// <div key={wine.id}>
//             <Link to={`/wine/${wine.id}`}>
//               <h2>{wine.name}</h2>
//               <h2>{wine.winemaker}</h2>
//               <h3>{wine.year}</h3>
//               <h3>{wine.rating}</h3>
//               <p>{wine.description}</p>
//               <p>{wine.tags}</p>
//             </Link>
//           </div>
