import React from "react";
import Oidc from "oidc-client";
export default function LoginCallBack() {
  var userManager = new Oidc.UserManager({
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
  });
  return (
    <div>
      {userManager.signinCallback().then((res) => {
        userManager
          .getUser()
          .then(console.log(Oidc.UserManager))
          .then((user) =>
            user.profile.role === "admin"
              ? (window.location.href = process.env.REACT_APP_ADMIN)
              : (window.location.href = process.env.REACT_APP_ADMIN)
          );
      })}
    </div>
  );
}