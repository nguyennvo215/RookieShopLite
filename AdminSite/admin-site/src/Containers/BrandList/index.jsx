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

const BrandList = (props) => {
  const Delete=(id)=> {
     Axios.delete(`${process.env.REACT_APP_BACK_HOST}api/brands/` + id).then(
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
      setSelectedItem( (await Axios.get(`${process.env.REACT_APP_BACK_HOST}api/brands/` + i)).data);
      toggle()
  }

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      brandName: selectedItem==null?"":selectedItem.brandName,
      brandDescription : selectedItem==null?"":selectedItem.brandDescription
    },
    onSubmit : async (values) => {
      if (selectedItem == null) {
        await Axios.post(`${process.env.REACT_APP_BACK_HOST}api/brands`, values);
      } else {
        var newData = {
          ...props.item.find(d => d.id == selectedItem.id),
          ...values
        };
        var oldData = [...props.item.filter(d => d.id != selectedItem.id)]
        var newArray = [...oldData, newData].sort((a,b) => {return a.id - b.id});
        props.handler(newArray);
        await Axios.put(`${process.env.REACT_APP_BACK_HOST}api/brands/` + selectedItem.id, values);
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
            <ModalHeader toggle={toggle}>Modal title </ModalHeader>
            <ModalBody>
              <Form onSubmit={formik.handleSubmit}>
                <FormGroup>
                  
                  <Label for="exampleEmail">Name</Label>
                  <Input
                    type="text"
                    name="brandName"
                    id="brandName"
                    placeholder="Name of Brand"
                    onChange={formik.handleChange}
                    value={formik.values.brandName}                   
                  />
                  <Label for="exampleEmail">Description</Label>
                  <Input
                    type="text"
                    name="brandDescription"
                    id="brandDescription"
                    placeholder="Description"
                    onChange={formik.handleChange}
                    value={formik.values.brandDescription}                   
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
              <td>{e.brandName}</td>
              <td>{e.brandDescription}</td>
              <td>
                <Button color="info"  onClick={()=>selectItem1(e.id)}>Update</Button>{" "}
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

export default BrandList;