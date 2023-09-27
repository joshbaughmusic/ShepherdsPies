import { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { fetchEmployees } from '../../managers/EmployeeManager.js';
import { fetchCustomers } from '../../managers/CustomerManager.js';
import { Link } from 'react-router-dom';
import { PizzaCreate } from '../pizza/PizzaCreate.js';
import { fetchNewOrder } from '../../managers/OrderManager.js';

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
  const [orderPizzas, setOrderPizzas] = useState([]);
  const [cost, setCost] = useState(0);

  useEffect(() => {
    let price = newOrder.tip;
    if (newOrder.delivery) {
      price += 5;
    }
    if (orderPizzas.length > 0) {
      for (const op of orderPizzas) {
        price += op.price;
      }
    }
    setCost(price);
  }, [newOrder, orderPizzas]);

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
      ? setNewOrder({ ...newOrder, delivery: true })
      : setNewOrder({ ...newOrder, delivery: false });
  };

  const handleSubmit = (e) => {
    const copy = { ...newOrder };
    copy.Pizzas = orderPizzas;
    console.log(copy)
    fetchNewOrder(copy)
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
                <PizzaCreate
                  setOrderPizzas={setOrderPizzas}
                  orderPizzas={orderPizzas}
                />
              </div>
              <div className="container pizza-container">
                <ol>
                  {orderPizzas.map((op, index) => {
                    return (
                      <div className="container newPizza-container">
                        <li key={index}>
                          <h5>
                            <strong>Pizza:</strong>
                          </h5>
                          <p>
                            <strong>Size:</strong> {op.size.name}
                          </p>
                          <p>
                            <strong>Cheese:</strong> {op.cheese.name}
                          </p>
                          <p>
                            <strong>Sauce:</strong> {op.sauce.name}
                          </p>
                          {op.toppings.length > 0 ? (
                            <>
                              <p>
                                <strong>Toppings:</strong>
                              </p>
                              {op.toppings.map((t, index) => {
                                return (
                                  <ul>
                                    <li>{t.name}</li>
                                  </ul>
                                );
                              })}
                            </>
                          ) : (
                            ''
                          )}
                          <p>
                            <strong>Price: ${op.price}</strong>
                          </p>
                        </li>
                      </div>
                    );
                  })}
                </ol>
              </div>
            </div>
            <Button color="primary" onClick={handleSubmit}>Submit</Button>
          </div>
        </div>
      </div>
    </>
  );
};
