import React, { useEffect, useState } from 'react';
import axios from 'axios';

function Wine({ match }) {
  const [wine, setWine] = useState(null);

  useEffect(() => {
    const id = match.params.id; 
    axios.get(`https://localhost:7293/wine/${id}`)
      .then(response => {
        setWine(response.data);
      });
  }, [match.params.id]);

  if (!wine) return 'Loading...'; 

  return (
    <div>
      <h1>{wine.name}</h1>
      {/* Display other information about the wine here */}
    </div>
  );
}

export default Wine;