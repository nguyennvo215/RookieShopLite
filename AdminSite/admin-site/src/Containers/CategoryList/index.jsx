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
  Modal,
  ModalHeader,
  ModalBody
} from "reactstrap";

const CategoryList = (props) => {
  const Delete=(id)=> {
     Axios.delete(`${process.env.REACT_APP_BACK_HOST}api/categories/` + id).then(
      (res) => {
        console.log(res);
        console.log(res.data);
      }
    );
  }
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [selectedItem,setSelectedItem] = useState();

  async function selectItem1(i){
      setSelectedItem( (await Axios.get(`${process.env.REACT_APP_BACK_HOST}api/categories/` + i)).data);
      console.log("select",selectedItem);
      toggle()
  }

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      categoryName: selectedItem==null?"":selectedItem.categoryName,
      categoryDescription: selectedItem==null?"":selectedItem.categoryDescription
    },
    onSubmit : async (values) => {
      console.log(values);
      if (selectedItem == null) {
        await Axios.post(`${process.env.REACT_APP_BACK_HOST}api/categories`, values);
      } else {
        var newData = {
          ...props.item.find(d => d.id == selectedItem.id),
          ...values
        };
        var oldData = [...props.item.filter(d => d.id != selectedItem.id)]
        var newArray = [...oldData, newData].sort((a,b) => {return a.id - b.id});
        props.handler(newArray);
        await Axios.put(`${process.env.REACT_APP_BACK_HOST}api/categories/` + selectedItem.id, values);
      }
    }
  });

  return (
    <Table>
      <thead>
        <tr>
          <th>#</th>
          <th>Name</th>
          <th>Description</th>
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
                  <Label for="exampleEmail">Description</Label>
                  <Input
                    type="text"
                    name="categoryDescription"
                    id="categoryDescription"
                    placeholder="Description"
                    onChange={formik.handleChange}
                    value={formik.values.categoryDescription}
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
              <td>{e.categoryDescription}</td>
              <td>
                <Button color="info" onClick={()=>selectItem1(e.id)}>Update</Button>{" "}
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

export default CategoryList;