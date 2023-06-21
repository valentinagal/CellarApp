import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import Button from "react-bootstrap/Button";

import { googleLogout, useGoogleLogin } from "@react-oauth/google";

function Login() {
  const [user, setUser] = useState([]);
  const [profile, setProfile] = useState([]);

  const login = useGoogleLogin({
    onSuccess: (codeResponse) => setUser(codeResponse),
    onError: (error) => console.log("Login Failed:", error),
  });

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
        .catch((err) => console.log(err));
    }
  }, [user]);

  const logOut = () => {
    googleLogout();
    setProfile(null);
  };

  return (
    <div>
      <h2>Welcome in Wine Cellar</h2>
      <br />
      <br />
      {profile ? (
        <div>
          <img src={profile.picture} alt="user image" />
          <h5>Account Details: </h5>
          <p>Name: {profile.name}</p>
          <p>Email: {profile.email}</p>
          <br />
          <br />
          <Link to={`../wineCellar`}>
            <Button variant="outline-secondary">View Cellar</Button>
          </Link>
          <br />
          <br />
          <Button variant="outline-secondary" onClick={logOut}>
            Log out
          </Button>
        </div>
      ) : (
        <Button variant="outline-secondary" onClick={() => login()}>
          Sign in with Google 🚀{" "}
        </Button>
      )}
    </div>
  );
}

export default Login;
