import React, { useState } from "react";
import Axios from "axios";
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
} from "reactstrap";
import { LOCAL_HOST } from "../../Constants/env";

const ProductList = (props) => {
    const Delete = (id) => {
        Axios.delete(LOCAL_HOST + 'api/products/' + id).then(
            (res) => {
                console.log(res);
                console.log(res.data);
            }
        );
    }
    const [modal, setModal] = useState(false);
    const [name1, setName] = useState("");
    const toggle = () => setModal(!modal);
    const Post = async () => {
        var bodyFormData = new FormData();
        bodyFormData.append('name',)
        await Axios.post(

            `https://hngtiendng.azurewebsites.net/api/Category`,
            {
                name: name1
            }
        ).then(res => {
            console.log(res);
            console.log(res.data);
        })
    }
    const setName1 = (e) => {
        setName(e.target.value)
    }

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
                            <Form>
                                <FormGroup>
                                    <Label for="exampleEmail">Name</Label>
                                    <Input
                                        type="text"
                                        name="email"
                                        id="exampleEmail"
                                        placeholder="Name of Category"
                                        onChange={setName1}
                                        value={name1}
                                    />
                                </FormGroup>

                            </Form>
                        </ModalBody>
                        <ModalFooter>
                            <Button color="primary" onClick={toggle}>
                                Submit
              </Button>{" "}
                            <Button color="secondary" onClick={toggle}>
                                Cancel
              </Button>
                        </ModalFooter>
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
                                <img className="photo" src={LOCAL_HOST + "images/" + e.images[0]} /></td>
                            <td>
                                <Button color="info">Update</Button>{" "}
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