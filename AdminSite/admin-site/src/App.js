import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import './index.css';
import './sb-admin.css';
import NavBar from './Components/SideBar'

function App() {
  function getCatygory(){
    axios.get('https://localhost:44305/api/Categories').then(res=>console.log(res))
  }
  return (

    <NavBar />

    // <div className="App">
    //  <a onClick={getCatygory}>Get Category</a>
    // </div>

  );
}

export default App;
