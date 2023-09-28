import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  Form,
  FormGroup,
  Label,
  Input,
} from 'reactstrap';
import { fetchCreateCustomer } from '../../managers/CustomerManager.js';

export const CustomerCreate = ({ newOrder, setNewOrder, getAllCustomers }) => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [newCustomer, setNewCustomer] = useState({
    firstName: '',
    lastName: '',
    address: '',
    phone: '',
  });

  const handleChange = (e) => {
    setNewCustomer({
      ...newCustomer,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async () => {
    try {
      const returnedCustomer = await fetchCreateCustomer(newCustomer);

      await getAllCustomers();

      setNewOrder({
        ...newOrder,
        customerId: returnedCustomer.id,
      });

      toggle();
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <>
      <Link onClick={toggle}>Add new customer</Link>

      <Modal
        isOpen={modal}
        toggle={toggle}
      >
        <ModalHeader toggle={toggle}>Add New Pizza</ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label htmlFor="firstName">First Name</Label>
              <Input
                name="firstName"
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label htmlFor="lastName">Last Name</Label>
              <Input
                name="lastName"
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label htmlFor="address">Address</Label>
              <Input
                name="address"
                onChange={handleChange}
              />
            </FormGroup>
            <FormGroup>
              <Label htmlFor="phone">Phone</Label>
              <Input
                name="phone"
                onChange={handleChange}
              />
            </FormGroup>
          </Form>
          <Button
            color="primary"
            onClick={handleSubmit}
          >
            Create Customer
          </Button>
        </ModalBody>
      </Modal>
    </>
  );
};
