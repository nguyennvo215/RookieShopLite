import React, { useState, useEffect } from "react";
import Axios from "axios";
import UserList from "./UserList";
import { LOCAL_HOST } from "../Constants/env";

export default function Home() {

    const [res1, setRes] = useState([]);
    useEffect(() => {
        async function fetchData() {
            await Axios.get(LOCAL_HOST + 'api/users')
                .then((res) => res.data)
                .then((res) => setRes(res));
        }
        fetchData();
    }, []);
    console.log(res1);
    return (
        <div>
            <UserList item={res1} />
        </div>
    );
}