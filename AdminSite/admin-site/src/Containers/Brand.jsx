import React, { useState, useEffect } from "react";
import Axios from "axios";
import BrandList from "./BrandList";
import { LOCAL_HOST } from "../Constants/env";

export default function Home() {

    const [res1, setRes] = useState([]);
    useEffect(() => {
        async function fetchData() {
            await Axios.get(LOCAL_HOST + 'api/brands')
                .then((res) => res.data)
                .then((res) => setRes(res));
        }
        fetchData();
    }, []);
    console.log(res1);
    return (
        <div>
            <BrandList item={res1} />
        </div>
    );
}