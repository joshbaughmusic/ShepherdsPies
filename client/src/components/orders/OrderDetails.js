import React, { useEffect, useState } from 'react';
import { fetchSingleOrder } from '../../managers/OrderManager.js';
import { useParams } from 'react-router-dom';
import { Button, Table } from 'reactstrap';

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
                            <Button
                              color="primary"
                              onClick={() => {}}
                            >
                              Update
                            </Button>
                          </td>
                          <td>
                            <Button color="danger">Remove</Button>
                          </td>
                        </tr>
                      </React.Fragment>
                    );
                  })}
                </tbody>
              </Table>
              <Button color="primary">Add Pizza</Button>
              <br />
              <br />
            </div>
          </div>
          <div className="container container-right col-2">
            <div className="container order-delivery-container">
              <h5>Delivery:</h5>
              {order.delivery ? <p>Yes</p> : <p>No</p>}
              {order.delivery && !order.driver ? (
                <Button color="primary">Assign Driver</Button>
              ) : (
                ''
              )}
            </div>
            <div className="container price-container">
              <h6>Tip:</h6>
              {order.tip ? <p>{`$${order.tip}`}</p> : <p>$0</p>}
              {
                order.delivery ? 
                <>
                <h6>Delivery Fee</h6>
                <p>$5</p>
                </>
                :
                ''
              }
              <h4>Total:</h4>
              <p>{`$${order.totalCost}`}</p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
