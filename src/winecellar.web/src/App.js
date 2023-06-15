import React, {useState, useEffect} from 'react';
import axios from 'axios';
import WineCellar from './WineCellar/WineCellar';
import TagList from './TagList/TagList';
import './App.css';

function App() {
  const [wines, setWines] = useState([]);
  const [tags, setTags] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7293/wine')
    .then(response => {
      setWines(response.data);
    });

    axios.get('https://localhost:7293/tag')
    .then(response => {
      setTags(response.data);
    });
  }, []);

  return (
    <div className="App">
      <WineCellar wines={wines}/>
      <TagList tags={tags}/>
      </div>
  );
}

export default App;
