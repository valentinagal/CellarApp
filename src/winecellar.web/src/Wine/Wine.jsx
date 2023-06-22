import React, { useEffect, useState } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import Button from "react-bootstrap/Button";
import { Link } from "react-router-dom";


function Wine({ match }) {
  const [wine, setWine] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    axios.get(`https://localhost:7293/wine/${id}`).then((wineResponse) => {
      axios.get("https://localhost:7293/tag").then((tagResponse) => {
        setWine({
          ...wineResponse.data,
          tags: tagResponse.data.filter((t) =>
            wineResponse.data.tags.some((x) => x.tagId === t.id)
          ),
        });
      });
    });
  }, [id]);

  if (!wine) return "Loading...";

  return (
    <div>
      <Card style={{ width: "25rem", textAlign: "center" }}>
        <Card.Img variant="top" src={wine.imageURL} />
        <Card.Body>
          <Card.Title>
            {wine.name} {wine.wineMaker}
          </Card.Title>
          <Card.Text>{wine.year}</Card.Text>
        </Card.Body>
        <ListGroup className="list-group-flush">
          <ListGroup.Item>Rating is {wine.score}</ListGroup.Item>
          <ListGroup.Item>{wine.description}</ListGroup.Item>
          <ListGroup.Item>
            {wine.tags.map((x) => (
              <span key={x.id}>
                {x.value}
                <br />
              </span>
            ))}
          </ListGroup.Item>
        </ListGroup>
      </Card>
      <br />
      <br />
      <Link to={`/`}>
        <Button variant="outline-secondary">Go back to Cellar</Button>
      </Link>
    </div>
  );
}

export default Wine;
