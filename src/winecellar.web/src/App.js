import React, { useState, useEffect } from "react";
import axios from "axios";
import WineCellar from "./WineCellar/WineCellar";
import Wine from "./Wine/Wine";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import CreateWine from "./Wine/CreateWine";
import EditWine from "./Wine/EditWine";
import Login from "./User/LogInUser";
import { googleLogout } from "@react-oauth/google";
import { Container, Navbar } from "react-bootstrap";

function App() {
  const [user, setUser] = useState(null);
  const [profile, setProfile] = useState(null);

  useEffect(() => {
    const userJSON = localStorage.getItem("googleUser");
    if (userJSON) {
      const googleUser = JSON.parse(userJSON);
      setUser(googleUser);
    }
  }, []);

  useEffect(() => {
    if (user) {
      axios
        .get(
          `https://www.googleapis.com/oauth2/v1/userinfo?access_token=${user.access_token}`,
          {
            headers: {
              Authorization: `Bearer ${user.access_token}`,
              Accept: "application/json",
            },
          }
        )
        .then((res) => {
          setProfile(res.data);
        })
        .catch((err) => logout());
    }
  }, [user]);

  const logout = () => {
    localStorage.removeItem("googleUser");
    setUser(null);
    setProfile(null);

    googleLogout();
  };

  if (!user) {
    return <Login loginChanged={(u) => setUser(u)} />;
  }
  if (!profile) {
    return <span>Loading...</span>;
  }
  return (
    <div>
      <Navbar>
        <Container>
          <Navbar.Brand href="#home">Wine Cellar</Navbar.Brand>
          <Navbar.Toggle />
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>Signed in as: {profile.name}</Navbar.Text>
            <Navbar.Text>
              &nbsp;|&nbsp;
              <a href="#" onClick={logout}>
                Logout
              </a>
            </Navbar.Text>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <Router>
        <Routes>
          <Route path="/" element={<WineCellar />} />
          <Route path="/wine/:id" element={<Wine />} />
          <Route path="/create" element={<CreateWine />} />
          <Route path="/edit/wine/:id" element={<EditWine />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
