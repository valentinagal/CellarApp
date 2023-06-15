import React from "react";

function Tag({tag}) {
    return (
        <span className="tag">{tag.value}</span>
    );
}

export default Tag;