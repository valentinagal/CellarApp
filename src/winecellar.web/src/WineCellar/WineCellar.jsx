import { Link } from "react-router-dom";
import React from "react";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

function WineCellar({ wines }) {
  return (
    <div>
      <h1>Wine Cellar</h1>
      <div className="wine-list">
        <Row xs={1} md={4} className="g-4">
          {wines.map((wine) => (
            <Col key={wine.id}>
              <Card>
                <Card key={wine.id} style={{ width: "10rem" }} />
                <Card.Img
                  className="imgWineCard"
                  variant="top"
                  src={wine.imageURL}
                />
                <Card.Body>
                  <Card.Title>
                    {wine.name} {wine.wineMaker}
                  </Card.Title>
                  <Card.Text>{wine.year}</Card.Text>
                  <Link to={`/wine/${wine.id}`}>
                    <Button variant="primary">Details</Button>
                  </Link>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </Row>
      </div>
    </div>
  );
}

export default WineCellar;
