import { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { fetchEmployees } from '../../managers/EmployeeManager.js';
import { fetchCustomers } from '../../managers/CustomerManager.js';
import { Link } from 'react-router-dom';

export const OrderCreate = () => {
  const [employees, setEmployees] = useState();
  const [customers, setCustomers] = useState();
  const [newOrder, setNewOrder] = useState({
    employeeId: null,
    customerId: null,
    delivery: false,
    tip: 0,
    //add totalCost = cost in submitHandler
  });
  const [pizzas, setPizzas] = useState([
    {
        orderId: null,
        sizeId: null,

    }
  ]);
  const [cost, setCost] = useState(0)

  useEffect(() => {
    let price = newOrder.tip
    if(newOrder.delivery){
        price += 5
    }
    setCost(price)
  }, [newOrder])

  const getAllEmployees = () => {
    fetchEmployees().then(setEmployees);
  };
  const getAllCustomers = () => {
    fetchCustomers().then(setCustomers);
  };

  useEffect(() => {
    getAllEmployees();
    getAllCustomers();
  }, []);

  const handleChange = (e) => {
    setNewOrder({
      ...newOrder,
      [e.target.name]: parseInt(e.target.value),
    });
  };

  const handleCheck = (e) => {
    e.target.checked
      ? setNewOrder({...newOrder, delivery: true })
      : setNewOrder({...newOrder, delivery: false });
  };

  if (!employees || !customers) {
    return null;
  }

  return (
    <>
      <div className="container">
        <br />
        <h3>Create New Order</h3>
        <div className="row">
          <div className="container col-4">
            <Form>
              <br />
              <FormGroup>
                <Label htmlFor="employeeId">Employee</Label>
                <Input
                  name="employeeId"
                  type="select"
                  onChange={handleChange}
                >
                  <option value={null}>Select an employee</option>
                  {employees.map((e, index) => {
                    return (
                      <option
                        key={index}
                        value={e.id}
                      >{`${e.firstName} ${e.lastName}`}</option>
                    );
                  })}
                </Input>
              </FormGroup>
              <br />
              <FormGroup>
                <Label htmlFor="customerId">Customer</Label>
                <Input
                  name="customerId"
                  type="select"
                  onChange={handleChange}
                >
                  <option value={null}>Select an customer</option>
                  {customers.map((c, index) => {
                    return (
                      <option
                        key={index}
                        value={c.id}
                      >{`${c.firstName} ${c.lastName}`}</option>
                    );
                  })}
                </Input>
                <Link>Add new customer</Link>
              </FormGroup>
              <br />
              <FormGroup>
                <Input
                  name="delivery"
                  type="checkbox"
                  onChange={handleCheck}
                />
                <Label htmlFor="tip">Delivery?</Label>
              </FormGroup>
              <br />
              <FormGroup>
                <Label htmlFor="delivery">Tip</Label>
                <Input
                  name="tip"
                  type="number"
                  onChange={handleChange}
                />
              </FormGroup>
              <h4>Total: ${cost}</h4>
            </Form>
          </div>
          <div className="container col-4 flex-col-spaced">
            <div className="container">
              <div className="container flex-row-spaced">
                <h4>Pizzas:</h4>
                <Button color="primary">Add</Button>
              </div>
              <div className="container pizza-container">
                <ol>
                  <li>Pizza 1</li>
                  <li>Pizza 2</li>
                </ol>
              </div>
            </div>
            <Button color="primary">Submit</Button>
          </div>
        </div>
      </div>
    </>
  );
};
