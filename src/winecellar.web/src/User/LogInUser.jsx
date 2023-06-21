import Button from "react-bootstrap/Button";
import { useGoogleLogin } from "@react-oauth/google";

function Login({ loginChanged }) {
  const login = useGoogleLogin({
    onSuccess: (codeResponse) => {
      localStorage.setItem("googleUser", JSON.stringify(codeResponse));
      loginChanged(codeResponse);
    },
    onError: (error) => {
      localStorage.removeItem("googleUser");
      loginChanged(null);
      console.log("Login Failed:", error);
    },
  });

  return (
    <Button variant="outline-secondary" onClick={() => login()}>
      Sign in with Google 🚀{" "}
    </Button>
  );
}

export default Login;
