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

const BrandList = (props) => {
  const Delete=(id)=> {
     Axios.delete(LOCAL_HOST+'api/Brands/'+id).then(
      (res) => {
        console.log(res);
        console.log(res.data);
      }
    );
  }
  const [modal, setModal] = useState(false);
  const [name1,setName]=useState("");
  const toggle = () => setModal(!modal);
  const [selectedItem,setSelectedItem] = useState();

  async function selectItem1(i){
    //i.preventDefault();
      setSelectedItem( (await Axios.get(LOCAL_HOST+'api/brands/'+i)).data);
      console.log("select",selectedItem);
      toggle()
  }

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      brandName: selectedItem==null?"":selectedItem.brandName
    },
    onSubmit : async (values) => {
      console.log(values);
      if (selectedItem == null) {
        await Axios.post(LOCAL_HOST+'api/brands', values);
      } else {
        await Axios.put(LOCAL_HOST+'api/brands/'+selectedItem.id, values);
      }
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