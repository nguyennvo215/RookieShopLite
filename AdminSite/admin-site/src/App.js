import logo from './logo.svg';
import './App.css';
import axios from 'axios';

function App() {
  function getCatygory(){
    axios.get('https://localhost:44305/api/Categories').then(res=>console.log(res))
  }
  return (
    <div className="App">
     <a onClick={getCatygory}>Get Category</a>
    </div>
  );
}

export default App;
