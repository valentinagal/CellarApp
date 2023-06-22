import React, { useEffect, useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import { useNavigate, useParams } from "react-router-dom";


function EditWine() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [name, setName] = useState("");
  const [wineMaker, setWineMaker] = useState("");
  const [year, setYear] = useState("");
  const [score, setScore] = useState("");
  const [description, setDescription] = useState("");
  const [imageURL, setImageURL] = useState("");
  const [tags, setTags] = useState([]);
  const [selectedTags, setSelectedTags] = useState([]);

  useEffect(() => {
    if (!id) {
      return;
    }
    axios
      .get(`https://localhost:7293/tag`)
      .then((response) => {
        setTags(response.data);
      })
      .catch((error) => {
        console.log(error);
        alert("Something went wrong");
      });
    axios
      .get(`https://localhost:7293/wine/${id}`)
      .then((response) => {
        const wine = response.data;
        setName(wine.name);
        setWineMaker(wine.wineMaker);
        setYear(wine.year);
        setScore(wine.score);
        setDescription(wine.description);
        setImageURL(wine.imageURL);
        setSelectedTags(wine.tags.map((tag) => tag.tagId));
      })
      .catch((error) => {
        console.log(error);
        alert("Something went wrong");
      });
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();

    const updatedWine = {
      name,
      wineMaker,
      year,
      score,
      description,
      imageURL,
      tags: selectedTags,
    };

    axios
      .put(`https://localhost:7293/wine/${id}`, updatedWine)
      .then((response) => {
        alert("Wine updated");
        navigate(`/wine/${id}`);
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
      setSelectedTags((prev) => [...prev.folter((t) => t !== id)]);
    }
  };

  return (
    <div>
      <h2> Edit Your Wine</h2>
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
            checked={selectedTags.some((x) => x === t.id)}
          />
        ))}
        <br />
        <br />
        <br />
        <Button variant="outline-secondary" type="submit">
          Save Changes
        </Button>
      </form>
    </div>
  );
}

export default EditWine;
