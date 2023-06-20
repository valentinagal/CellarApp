import React, { useEffect, useState } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';

function Login() {
  const [user, setUser] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    axios.get(`https://localhost:7293/user`).then((response) => {
setUser(response.data);
    });
  }, []);

  return(
<div>
<InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Your Name: </InputGroup.Text>
        <Form.Control
          placeholder="Name"
          aria-label="Username"
          aria-describedby="basic-addon1"
        />
      </InputGroup>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Your Email: </InputGroup.Text>
        <Form.Control
          placeholder="Email"
          aria-label="Email"
          aria-describedby="basic-addon1"
        />
      </InputGroup>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Your Password: </InputGroup.Text>
        <Form.Control
          placeholder="Password"
          aria-label="Password"
          aria-describedby="basic-addon1"
        />
      </InputGroup>
</div>
  );
}

export default Login;