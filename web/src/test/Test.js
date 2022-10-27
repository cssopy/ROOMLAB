import "./Test.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Form, Button } from "react-bootstrap";
import { useState } from "react";
import axios from "axios";

const Test = () => {
  const [access, setAccess] = useState(localStorage.getItem(""));
  const [refresh, setRefresh] = useState(localStorage.getItem(""));
  const [userId, setUserId] = useState("");
  const [userPwd, setUserPwd] = useState("");
  const [userIdx, setUserIdx] = useState("");

  axios.defaults.baseURL = "/back";
  axios.defaults.headers.common["Authorization"] = `Bearer ${access}`;

  const tokenCheck = async () => {
    await axios
      .post("/api/user/check", {
        userId,
        refresh,
      })
      .then((res) => {
        setAccess(res.data.access);
      })
      .catch((err) => {
        setAccess("");
        setRefresh("");
      });
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
        setUserIdx(res.data.userIdx);
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
    if (!!event) {
      event.preventDefault();
    }
    axios
      .post("/api/user/logout", {
        userId,
        userPwd,
      })
      .then(() => {
        setAccess("");
        setRefresh("");
      })
      .catch((err) => {
        console.log(2);
        tokenCheck();
      });
  };

  const signOut = (event) => {
    if (!!event) {
      event.preventDefault();
    }
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
      .catch((err) => {
        console.error(err);
        tokenCheck();
        signOut();
      });
  };

  const [img, setImg] = useState("");
  const [imgUrl, setImgUrl] = useState("");

  const printFile = (e) => {
    setImg(e.target.files[0]);
    const reader = new FileReader();
    reader.onload = () => {
      setImgUrl(reader.result);
    };
    reader.readAsDataURL(e.target.files[0]);
  };

  const saveImg = (event) => {
    event.preventDefault();
    const formData = new FormData();
    formData.append("file", img);

    axios
      .post("/api/report/save", {
        userIdx,
        expIdx: 1,
        repContent: "test",
        repPicture: img,
      })
      .then(() => {
        axios.get(`/api/report/${userIdx}`).then((res) => console.log(res));
      })
      .catch((err) => console.error(err));
  };

  return (
    <div className="App">
      {!access && !refresh && (
        <>
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
        </>
      )}
      {access && refresh && (
        <div style={{}}>
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
          <img src={imgUrl} style={{ width: "300px" }} alt="img" />
          <input type="file" accept="image/*" onChange={printFile}></input>
          <button onClick={saveImg}>송신</button>
        </div>
      )}
    </div>
  );
};

export default Test;
