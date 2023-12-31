import React, { useEffect, useState } from 'react';
import { fetchSingleOrder } from '../../managers/OrderManager.js';
import { useParams } from 'react-router-dom';
import { Button, Table } from 'reactstrap';
import { PizzaUpdate } from '../pizza/PizzaUpdate.js';
import { PizzaAdd } from '../pizza/PizzaAdd.js';
import { fetchRemovePizza } from '../../managers/PizzaManager.js';
import { OrderAssignDriver } from './OrderAssignDriver.js';

export const OrderDetails = () => {
  const [order, setOrder] = useState();
  const { id } = useParams();

  const getSingleOrder = () => {
    fetchSingleOrder(id).then(setOrder);
  };

  useEffect(() => {
    getSingleOrder();
  }, []);

  const dateFormatter = () => {
    const parsedDate = new Date(order.date);

    const day = parsedDate.getDate();
    const month = parsedDate.getMonth() + 1;
    const year = parsedDate.getFullYear();

    const formattedDate = `${month.toString().padStart(2, '0')}/${day
      .toString()
      .padStart(2, '0')}/${year}`;

    return formattedDate;
  };

  const handleCancel = (e) => {
    fetchRemovePizza(id, parseInt(e.target.value)).then(() => getSingleOrder());
  };

  if (!order) {
    return null;
  }

  return (
    <>
      <div className="container">
        <br />
        <div className="row">
          <h3>{`Order ${id} Details:`}</h3>
          <h6>{`Date: ${dateFormatter()}`}</h6>
          <br />
          <br />
          <div className="container col-6">
            <h5>Customer:</h5>
            <Table>
              <thead>
                <tr>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>Address</th>
                  <th>Phone</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{order.customer.firstName}</td>
                  <td>{order.customer.lastName}</td>
                  <td>{order.customer.address}</td>
                  <td>{order.customer.phone}</td>
                </tr>
              </tbody>
            </Table>
            <br />
            <h5>Employee:</h5>
            <Table>
              <thead>
                <tr>
                  <th>Id</th>
                  <th>First Name</th>
                  <th>Last Name</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{order.employee.id}</td>
                  <td>{order.employee.firstName}</td>
                  <td>{order.employee.lastName}</td>
                </tr>
              </tbody>
            </Table>
            <br />
            {order.driver ? (
              <>
                <h5>Driver:</h5>
                <Table>
                  <thead>
                    <tr>
                      <th>Id</th>
                      <th>First Name</th>
                      <th>Last Name</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>{order.driver.id}</td>
                      <td>{order.driver.firstName}</td>
                      <td>{order.driver.lastName}</td>
                    </tr>
                  </tbody>
                </Table>
                <br />
              </>
            ) : (
              ''
            )}
            <h5>Pizza List:</h5>
            <div className="container pizza-container">
              <Table>
                <thead>
                  <tr>
                    <th>Size</th>
                    <th>Topping #</th>
                    <th>Price</th>
                    <th></th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  {order.pizzas.map((p, index) => {
                    return (
                      <React.Fragment key={index}>
                        <tr>
                          <td>{p.size.name}</td>
                          <td>{p.pizzaToppings.length}</td>
                          <td>{`$${p.totalCost}`}</td>
                          <td>
                            <PizzaUpdate
                              id={p.id}
                              getSingleOrder={getSingleOrder}
                            />
                          </td>
                          <td>
                            <Button
                              color="danger"
                              value={p.id}
                              onClick={handleCancel}
                            >
                              Remove
                            </Button>
                          </td>
                        </tr>
                      </React.Fragment>
                    );
                  })}
                </tbody>
              </Table>
              <PizzaAdd
                getSingleOrder={getSingleOrder}
                orderId={id}
              />
              <br />
              <br />
            </div>
          </div>
          <div className="container flex-col-spaced col-2">
            <div className="container order-delivery-container">
              <h5>Delivery:</h5>
              {order.delivery ? <p>Yes</p> : <p>No</p>}
              {order.delivery && !order.driver ? (
                <OrderAssignDriver orderId={id} getSingleOrder={getSingleOrder}/>
              ) : (
                ''
              )}
            </div>
            <div className="container price-container">
              <h6>Tip:</h6>
              {order.tip ? <p>{`$${order.tip}`}</p> : <p>$0</p>}
              {order.delivery ? (
                <>
                  <h6>Delivery Fee</h6>
                  <p>$5</p>
                </>
              ) : (
                ''
              )}
              <h4>Total:</h4>
              <p>{`$${order.totalCost}`}</p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
