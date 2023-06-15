import React from "react"; 

function User({user}) {
    return (
        <div className="user">
            <h2>{user.name}</h2>
        </div>
    );
}

export default User;