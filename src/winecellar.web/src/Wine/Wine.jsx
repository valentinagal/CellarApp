import React from "react";

function Wine({wine}) {
    return (
        <div className="wine">
            <h2>{wine.name}</h2>
            <h2>{wine.wineMaker}</h2>
            <h2>{wine.year}</h2>
            <p>{wine.score}</p>
            <p>{wine.description}</p>
            {wine.tags.map(tag => <tag key={tag.id} tag={tag}/>)}
        </div>
    );
}

export default Wine;