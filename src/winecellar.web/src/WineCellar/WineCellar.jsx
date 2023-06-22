import { Link } from "react-router-dom";
import React, { useEffect, useState } from "react";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import axios from "axios";


function WineCellar() {
  const [currentWines, setCurrentWines] = useState([]);
  useEffect(() => {
    axios.get("https://localhost:7293/wine").then((response) => {
      setCurrentWines(response.data);
    });
  }, []);

  const handleDelete = (wine) => {
    const confirm = window.confirm(
      `You are going to delete ${wine.name}. Are you sure? `
    );
    if (confirm) {
      axios.delete(`https://localhost:7293/wine/${wine.id}`).then(() => {
        setCurrentWines((prev) => [...prev.filter((w) => w.id !== wine.id)]);
      });
    }
  };

  return (
    <div>
      <div className="wine-list">
        <Row xs={1} md={4} className="g-4">
          {currentWines.map((wine) => (
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
                    <Button variant="outline-secondary" className="me-4">
                      Details
                    </Button>
                  </Link>
                  <Button
                    variant="outline-secondary"
                    className="me-4"
                    onClick={() => handleDelete(wine)}
                  >
                    Delete
                  </Button>
                  <Link to={`/edit/wine/${wine.id}`}>
                    <Button variant="outline-secondary" className="me-4">
                      Edit
                    </Button>
                  </Link>
                </Card.Body>
              </Card>
            </Col>
          ))}
          <Card>
            <Link to={`/create`}>
              <Card.Img
                className="imgWineCard"
                variant="top"
                src="https://st2.depositphotos.com/38069286/44086/v/600/depositphotos_440862214-stock-illustration-add-icon-symbol-modern-simple.jpg"
              />
            </Link>
            <Card.Body>
              <Card.Title>Add wine</Card.Title>
              <br />
              <Link to={`/create`}>
                <Button variant="outline-secondary" className="me-4">
                  Add wine
                </Button>
              </Link>
            </Card.Body>
          </Card>
        </Row>
      </div>
      {/* <Link to={`/create`}>
        <Button variant="outline-secondary" className="me-4">
          Add wine
        </Button>
      </Link> */}
      {/* <Card style={{ width: '10rem' }}>
      <Card.Img variant="top" src="https://st2.depositphotos.com/38069286/44086/v/600/depositphotos_440862214-stock-illustration-add-icon-symbol-modern-simple.jpg" />
      <Card.Body>
        <Card.Title>Add wine</Card.Title>
        <Link to={`/create`}>
        <Button variant="outline-secondary" className="me-4">
          Add wine
        </Button>
      </Link>
      </Card.Body>
    </Card> */}
    </div>
  );
}

export default WineCellar;
