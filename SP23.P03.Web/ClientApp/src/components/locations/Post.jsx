import React, { useEffect } from "react";
import { useParams } from "react-router";

function Post() {
  let { postSlug } = useParams();

  useEffect(() => {
    // Fetch post using the postSlug
  }, [postSlug]);

  return (
    <div className="home">
      <div class="container">
        <h1 className="mt-5">EnTrac is now serving X locations nationwide!</h1>
        <h6 className="mb-5">The post slug is, {postSlug}</h6>
        <p>
          Location 1: Address x
        </p>
        <p>
          Location 2: Address y
        </p>
        <p>
          Location 3: Address z
        </p>
      </div>
    </div>
  );
}

export default Post;