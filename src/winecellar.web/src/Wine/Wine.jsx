import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

function Wine({ match }) {
  const [wine, setWine] = useState(null);
  const {id} = useParams();

  useEffect(() => {
    axios.get(`https://localhost:7293/wine/${id}`)
      .then(response => {
        setWine(response.data);
      });
  }, [id]);

  if (!wine) return 'Loading...'; 

  return (
    <div>
      <h2>{wine.name} by {wine.wineMaker}</h2>
      <h4>{wine.year} {}</h4>
  

    </div>
  );
}

export default Wine;