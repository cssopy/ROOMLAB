import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Form, Button } from "react-bootstrap";
import { useState } from "react";
import axios from "axios";

function App() {
  const [access, setAccess] = useState(localStorage.getItem(""));
  const [refresh, setRefresh] = useState(localStorage.getItem(""));
  const [userId, setUserId] = useState("");
  const [userPwd, setUserPwd] = useState("");

  axios.defaults.baseURL = "/back";
  axios.defaults.headers.common["Authorization"] = `Bearer ${access}`;

  const tokenCheck = async () => {
    axios
      .post("/api/user/check", {
        userId,
        refresh,
      })
      .then((res) => {
        setAccess(res.data.access);
      })
      .catch((err) => console.error(err));
  };

  const idChange = (event) => {
    setUserId(event.target.value);
  };

  const pwdChange = (event) => {
    setUserPwd(event.target.value);
  };

  const logIn = (event) => {
    if (!!event) {
      event.preventDefault();
    }
    console.log(userId, userPwd);
    axios
      .post("/api/user/login", {
        userId,
        userPwd,
      })
      .then((res) => {
        setAccess(res.data.access);
        setRefresh(res.data.refresh);
      })
      .catch((err) => console.error(err));
  };

  const signUp = (event) => {
    event.preventDefault();
    console.log(userId, userPwd);
    axios
      .post("/api/user/signup", {
        userId,
        userPwd,
      })
      .then(() => {
        logIn();
      })
      .catch((err) => console.error(err));
  };

  const logOut = (event) => {
    tokenCheck();
    event.preventDefault();
    axios
      .post("/api/user/logout", {
        userId,
        userPwd,
      })
      .then(() => {
        setAccess("");
        setRefresh("");
      })
      .catch((err) => console.error(err));
  };

  const signOut = (event) => {
    event.preventDefault();
    tokenCheck();
    axios
      .delete("/api/user/withdrawal", {
        data: {
          userId,
          userPwd,
        },
      })
      .then(() => {
        setAccess("");
        setRefresh("");
      })
      .catch((err) => console.error(err));
  };

  return (
    <div className="App">
      {!access && !refresh && (
        <Form className="Form">
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Control
              type="email"
              placeholder="Enter email"
              onChange={idChange}
              value={userId}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={pwdChange}
              value={userPwd}
            />
          </Form.Group>
          <Button
            variant="primary"
            type="submit"
            className="mx-2"
            onClick={logIn}
          >
            로그인
          </Button>
          <Button
            variant="primary"
            type="submit"
            className="mx-3"
            onClick={signUp}
          >
            회원가입
          </Button>
        </Form>
      )}
      {access && refresh && (
        <div className="Form">
          <div>access : {access}</div>
          <div>refresh : {refresh}</div>
          <br />
          <Button
            variant="primary"
            type="submit"
            className="mx-3"
            onClick={logOut}
          >
            로그아웃
          </Button>
          <Button
            variant="primary"
            type="submit"
            className="mx-3"
            onClick={signOut}
          >
            회원탈퇴
          </Button>
        </div>
      )}
    </div>
  );
}

export default App;
