import React, { useEffect, useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import { useNavigate } from "react-router-dom";

function CreateWine() {
  const navigate = useNavigate();
  const [name, setName] = useState("");
  const [wineMaker, setWineMaker] = useState("");
  const [year, setYear] = useState("");
  const [score, setScore] = useState("");
  const [description, setDescription] = useState("");
  const [imageURL, setImageURL] = useState("");
  const [tags, setTags] = useState([]);
  const [selectedTags, setSelectedTags] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7293/tag")
      .then((response) => {
        console.log(response);
        setTags(response.data);
      })
      .catch((error) => {
        console.log(error);
        alert("Something went wrong");
      });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const newWine = {
      name,
      wineMaker,
      year,
      score,
      description,
      imageURL,
      tags: selectedTags,
    };

    axios
      .post("https://localhost:7293/wine", newWine)
      .then((response) => {
        console.log(response);
        alert("Wine added");
        navigate(`/wine/${response.data.id}`);
      })
      .catch((error) => {
        console.log(error);
        alert("Something went wrong");
      });
  };

  const handleTagOnChange = (event, id) => {
    if (event.target.checked) {
      setSelectedTags((prev) => [...prev, id]);
    } else {
      setSelectedTags((prev) => [...prev.filter((t) => t !== id)]);
    }
  };

  return (
    <div>
      <h2> New Wine</h2>
      <form onSubmit={handleSubmit}>
        <InputGroup size="lg">
          <InputGroup.Text id="inputGroup-sizing-lg">Name:</InputGroup.Text>
          <Form.Control
            aria-label="Large"
            aria-describedby="inputGroup-sizing-sm"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </InputGroup>
        <br />
        <InputGroup size="lg">
          <InputGroup.Text id="inputGroup-sizing-lg">
            Wine Maker:
          </InputGroup.Text>
          <Form.Control
            aria-label="Large"
            aria-describedby="inputGroup-sizing-sm"
            value={wineMaker}
            onChange={(e) => setWineMaker(e.target.value)}
          />
        </InputGroup>
        <br />
        <InputGroup size="lg">
          <InputGroup.Text id="inputGroup-sizing-lg">Year:</InputGroup.Text>
          <Form.Control
            aria-label="Large"
            aria-describedby="inputGroup-sizing-sm"
            value={year}
            onChange={(e) => setYear(e.target.value)}
          />
        </InputGroup>
        <br />
        <InputGroup size="lg">
          <InputGroup.Text id="inputGroup-sizing-lg">Score:</InputGroup.Text>
          <Form.Control
            aria-label="Large"
            aria-describedby="inputGroup-sizing-sm"
            value={score}
            onChange={(e) => setScore(e.target.value)}
          />
        </InputGroup>
        <br />

        <InputGroup size="lg">
          <InputGroup.Text id="inputGroup-sizing-lg">
            Upload image:
          </InputGroup.Text>
          <Form.Control
            aria-label="Large"
            aria-describedby="inputGroup-sizing-sm"
            value={imageURL}
            onChange={(e) => setImageURL(e.target.value)}
          />
        </InputGroup>
        <br />
        <Form.Label htmlFor="basic-url">Add description</Form.Label>
        <FloatingLabel controlId="floatingTextarea2" label="Decription">
          <Form.Control
            as="textarea"
            placeholder="Description: "
            style={{ height: "100px" }}
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </FloatingLabel>
        <br />
        <Form.Label htmlFor="basic-url">Add some tags:</Form.Label>
        <br />
        {tags.map((t) => (
          <Form.Check
            key={t.id}
            inline
            type="checkbox"
            id={`tag-${t.id}`}
            label={t.value}
            onChange={(event) => handleTagOnChange(event, t.id)}
          />
        ))}
        <br />
        <br />
        <br />
        <button type="submit">Add Wine</button>
      </form>
    </div>
  );
}

export default CreateWine;
