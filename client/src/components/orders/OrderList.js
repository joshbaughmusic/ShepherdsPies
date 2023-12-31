import React from 'react';
import { useEffect, useState } from 'react';
import { fetchAllOrders, fetchCancelOrder } from '../../managers/OrderManager.js';
import { Button, ButtonGroup, Table } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

export const OrderList = () => {
  const [orders, setOrders] = useState();
  const navigate = useNavigate();

  const getAllOrders = () => {
    fetchAllOrders().then(setOrders);
  };

  useEffect(() => {
    getAllOrders();
  }, []);

  const handleCancel = (e) => {
    fetchCancelOrder(parseInt(e.target.value)).then(() => getAllOrders())
  }

  if (!orders) {
    return null;
  }

  return (
    <>
      <div className="container">
        <br />
        <h1 className="text-center">Shepherd's Pizza Order Management</h1>
        <br />
        <div className="container">
          <div className="title-button-container">
            <h3>All orders:</h3>
            <Button
              color="primary"
              onClick={() => navigate(`orders/create`)}
            >
              New Order
            </Button>
          </div>
          <Table>
            <thead>
              <tr>
                <th>Order #</th>
                <th>Customer</th>
                <th>Delivery</th>
                <th>Date</th>
                <th></th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {orders.map((o, index) => {
                const parsedDate = new Date(o.date);

                const day = parsedDate.getDate();
                const month = parsedDate.getMonth() + 1;
                const year = parsedDate.getFullYear();

                const formattedDate = `${month
                  .toString()
                  .padStart(2, '0')}/${day
                  .toString()
                  .padStart(2, '0')}/${year}`;
                return (
                  <React.Fragment key={index}>
                    <tr>
                      <td>{o.id}</td>
                      <td>{`${o.customer.firstName} ${o.customer.lastName}`}</td>
                      {o.delivery ? <td>Yes</td> : <td>No</td>}
                      <td>{formattedDate}</td>
                      <td>
                        <Button
                          color="primary"
                          onClick={() => navigate(`orders/${o.id}`)}
                        >
                          Details
                        </Button>
                      </td>
                      <td>
                        <Button
                          color="danger"
                          value={o.id}
                          onClick={handleCancel}
                        >
                          Cancel
                        </Button>
                      </td>
                    </tr>
                  </React.Fragment>
                );
              })}
            </tbody>
          </Table>
        </div>
      </div>
    </>
  );
};
