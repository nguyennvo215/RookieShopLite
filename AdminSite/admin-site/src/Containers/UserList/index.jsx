import React from "react";
import { Table } from "reactstrap";

const UserList = (props) => {
  return (
    <Table>
      <thead>
        <tr>
          <th>#</th>
          <th>Name</th>
          <th>Email</th>
        </tr>
      </thead>
      {props.item.map(function (e, i) {
        return (
          <tbody>
            <tr key={i}>
              <th scope="row">{e.id}</th>
              <td>{e.userName}</td>
              <td>{e.email}</td>
            </tr>
          </tbody>
        );
      })}
    </Table>
  );
};

export default UserList;