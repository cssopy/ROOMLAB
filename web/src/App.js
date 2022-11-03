import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import Test from "./test/Test";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/web" element={<Test />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
