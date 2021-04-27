import React,{useState} from "react";
import Axios from "axios";
import { useFormik } from "formik";
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
import { LOCAL_HOST } from '../../Constants/env';

const ProductList = (props) => {
  const Delete=(id)=> {
     Axios.delete(LOCAL_HOST+'api/categories/'+id).then(
      (res) => {
        console.log(res);
        console.log(res.data);
      }
    );
  }
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      categoryName: ''
    },
    onSubmit : async (values) => {
      console.log(values);
      await Axios.post(LOCAL_HOST+'api/categories', values);
    }
  });

  return (
    <Table>
      <thead>
        <tr>
          <th>#</th>
          <th>Name</th>
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
                    name="categoryName"
                    id="categoryName"
                    placeholder="Name of Category"
                    onChange={formik.handleChange}
                    value={formik.values.categoryName}
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
              <td>{e.categoryName}</td>
              <td>
                <Button color="info" onClick={toggle}>Update</Button>{" "}
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