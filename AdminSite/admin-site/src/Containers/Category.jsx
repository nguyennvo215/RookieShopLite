import React, { useState, useEffect } from "react";
import Axios from "axios";
import CategoryList from "./CategoryList";

export default function Home() {

    const [res1, setRes] = useState([]);
    useEffect(() => {
        async function fetchData() {
            await Axios.get(`${process.env.REACT_APP_BACK_HOST}api/categories`)
                .then((res) => res.data)
                .then((res) => setRes(res));
        }
        fetchData();
    }, []);

    const HandleBrandData = (newData) => {
        setRes(newData);
    }

    return (
        <div>
            <CategoryList item={res1} handler={HandleBrandData} />
        </div>
    );
}