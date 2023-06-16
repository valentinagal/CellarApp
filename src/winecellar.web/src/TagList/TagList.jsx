import React from 'react';
import Tag from "../Tag/Tag";

function TagList({tags}) {
    return (
        <div className="tag-list">
            {tags.map(tag => <Tag key={tag.id} tag={tag}/>)}
        </div>
    );
}
export default TagList;