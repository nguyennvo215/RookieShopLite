import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import {
  BrowserRouter as Router,
  Route,
  Switch
} from "react-router-dom";
import './App.css';
import Category from './Containers/Category';
import Home from './Containers/Home';
import Brand from './Containers/Brand';
import User from './Containers/User'
import NavBar from './Components/NavBar';
require("dotenv").config();

function App() {
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
        <Route exact path="/user">
          <User />
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
