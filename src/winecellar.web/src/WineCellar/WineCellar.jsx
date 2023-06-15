import React from "react";
import Wine from "../Wine/Wine";

function WineCellar({wines}) {
return (
    <div className="wine-cellar">
        {wines.map(wine => <Wine key ={wine.id} wine={wine}/>)}
    </div>
)
}
export default WineCellar;