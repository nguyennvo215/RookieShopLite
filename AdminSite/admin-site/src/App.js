import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.css";
import {
  BrowserRouter as Router,
  Route,
  Switch,

} from "react-router-dom";
import './App.css';
import axios from 'axios';
import Category from './Containers/Category';
import Home from './Containers/Home';
import Brand from './Containers/Brand';
import NavBar from './Components/NavBar';
import { LOCAL_HOST } from "./Constants/env";

function App() {

  const [res1, setRes] = useState([]);
  useEffect(() => {
    async function fetchData() {
      await axios.get(LOCAL_HOST + 'api/categories')
        .then((res) => res.data)
        // .then((res) => setRes(res));
        .then(res=>console.log(res))
    }
    fetchData();
  }, []);
  console.log(res1);
return (
  <Router>
    <NavBar />
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/category">
        <Category />
      </Route>
      <Route exact path="/brand">
        <Brand />
      </Route>
    </Switch>
  </Router>
);
}

export default App;
