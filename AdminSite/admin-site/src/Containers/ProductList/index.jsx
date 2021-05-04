import React, { useState } from "react";
import Axios from "axios";
import { useFormik } from 'formik';
import {
    Table,
    Button,
    Form,
    FormGroup,
    Label,
    Input,
    FormText,
    Modal,
    ModalHeader,
    ModalBody,
    ModalFooter,
    Col,
    Row
} from "reactstrap";
import { LOCAL_HOST } from "../../Constants/env";

const ProductList = (props) => {
    const Delete = (id) => {
        Axios.delete(`${process.env.REACT_APP_BACK_HOST}api/products/` + id).then(
            (res) => {
                console.log(res);
                console.log(res.data);
            }
        );
    }
    const [modal, setModal] = useState(false);
    const toggle = () => setModal(!modal);
    const [selectedItem, setSelectedItem] = useState();
    const [image, setImage] = useState("");
    const [loading, setLoading] = useState(false);

    async function selectItem1(i) {
        setSelectedItem((await Axios.get(`${process.env.REACT_APP_BACK_HOST}api/products/` + i)).data[0]);
        console.log("select", selectedItem);
        toggle()
    }

    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            productName: selectedItem == null ? "" : selectedItem.productName,
            brandId: selectedItem == null ? 0 : selectedItem.brandId,
            categoryId: selectedItem == null ? 0 : selectedItem.categoryId,
            productShortDescription: selectedItem == null ? "" : selectedItem.productShortDescription,
            productFullDescription: selectedItem == null ? "" : selectedItem.productFullDescription,
            productPriceNow: selectedItem == null ? 0 : selectedItem.productPriceNow,
            productPriceBefore: selectedItem == null ? 0 : selectedItem.productPriceBefore,
            imgPath: ""
        },
        onSubmit: async (values) => {
            console.log(values);
            if (selectedItem == null) {
                console.log(values);
                await Axios.post(`${process.env.REACT_APP_BACK_HOST}api/products`, values);
            } else {
                await Axios.put(`${process.env.REACT_APP_BACK_HOST}api/products/` + selectedItem.id, values);
            }
        }
    });

    const uploadImage = async (e) => {
        const files = e.target.files;
        const data = new FormData();
        data.append("file", files[0]);
        data.append("upload_preset", "presetname");
        setLoading(true);
        const res = await fetch(
            "https://api.cloudinary.com/v1_1/dfzg0xvjj/image/upload",
            {
                method: "POST",
                body: data,
            }
        );
        const file = await res.json();
        console.log(file);
        setImage(file.secure_url);
        setLoading(false);
        formik.values.imgPath = file.secure_url;
    };

    return (
        <Table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Short Description</th>
                    <th>Price Now</th>
                    <th>Price Before</th>
                    <th>Image</th>
                    <th>Option</th>
                    <th>
                        <Button color="success" onClick={toggle}>Create</Button>
                    </th>
                    <Modal isOpen={modal} toggle={toggle} >
                        <ModalHeader toggle={toggle}>Modal title</ModalHeader>
                        <ModalBody>
                            <Form onSubmit={formik.handleSubmit}>
                                <FormGroup>
                                    <Label for="exampleEmail">Name</Label>
                                    <Input
                                        type="text"
                                        name="productName"
                                        id="productName"
                                        placeholder="Name of Product"
                                        onChange={formik.handleChange}
                                        value={formik.values.productName}
                                    />
                                    <Row>
                                        <Col md={6}>
                                            <Label for="exampleEmail">Brand Id</Label>
                                            <Input
                                                type="number"
                                                name="brandId"
                                                id="brandId"
                                                placeholder="Id of brand"
                                                onChange={formik.handleChange}
                                                value={formik.values.brandId}
                                            />
                                        </Col>
                                        <Col md={6}>
                                            <Label for="exampleEmail">Category Id</Label>
                                            <Input
                                                type="number"
                                                name="categoryId"
                                                id="categoryId"
                                                placeholder="Id of category"
                                                onChange={formik.handleChange}
                                                value={formik.values.categoryId}
                                            />
                                        </Col>
                                    </Row>
                                    <Label for="exampleEmail">Short Description</Label>
                                    <Input
                                        type="text"
                                        name="productShortDescription"
                                        id="productShortDescription"
                                        placeholder="Short Description for thumpnail"
                                        onChange={formik.handleChange}
                                        value={formik.values.productShortDescription}
                                    />
                                    <Label for="exampleEmail">Full Description</Label>
                                    <Input
                                        type="textarea"
                                        name="productFullDescription"
                                        id="productFullDescription"
                                        placeholder="Description"
                                        onChange={formik.handleChange}
                                        value={formik.values.productFullDescription}
                                    />
                                    <Row>
                                        <Col md={6}>
                                            <Label for="exampleEmail">Price</Label>
                                            <Input
                                                type="number"
                                                name="productPriceNow"
                                                id="productPriceNow"
                                                placeholder="Price for sale"
                                                onChange={formik.handleChange}
                                                value={formik.values.productPriceNow}
                                            />
                                        </Col>
                                        <Col md={6}>
                                            <Label for="exampleEmail">Price Before (if discounted)</Label>
                                            <Input
                                                type="number"
                                                name="productPriceBefore"
                                                id="productPriceBefore"
                                                placeholder="Undiscounted price"
                                                onChange={formik.handleChange}
                                                value={formik.values.productPriceBefore}
                                            />
                                        </Col>
                                    </Row>
                                    <Label htmlFor="images">Upload Image</Label>
                                    <Input
                                        type="file"
                                        id="file"
                                        name="file"
                                        placeholder="Upload an image"
                                        onChange={uploadImage}
                                        style={{ display: "block" }}
                                    />
                                    <Input 
                                        type="hidden"
                                        id="imgPath"
                                        name="imgPath"
                                        onChange={formik.handleChange}
                                        value={formik.values.imgPath}
                                    />
                                </FormGroup>
                                <Button color="primary" type="submit" onClick={toggle}>
                                    Submit
                                </Button>{" "}
                                <Button color="secondary" onClick={toggle}>
                                    Cancel
                                </Button>
                            </Form>

                        </ModalBody>
                    </Modal>
                </tr>
            </thead>
            {props.item.map(function (e, i) {
                return (
                    <tbody>
                        <tr key={i}>
                            <th scope="row">{e.id}</th>
                            <td>{e.productName}</td>
                            <td>{e.productShortDescription}</td>
                            <td>{e.productPriceNow}</td>
                            <td>{e.productPriceBefore}</td>
                            <td>
                                <img className="photo" src={e.images[0]} /></td>
                            <td>
                                <Button color="info" onClick={() => selectItem1(e.id)}>Update</Button>{" "}
                                <Button color="danger" onClick={() => Delete(e.id)}>
                                    Delete
                                </Button>
                            </td>
                        </tr>
                    </tbody>
                );
            })}
        </Table>
    );
};

export default ProductList;