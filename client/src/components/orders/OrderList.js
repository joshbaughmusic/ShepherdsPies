import { useEffect, useState } from 'react';
import { fetchAllOrders } from '../../managers/OrderManager.js';
import { Table } from 'reactstrap';

export const OrderList = () => {
  const [orders, setOrders] = useState();

  const getAllOrders = () => {
    fetchAllOrders().then(setOrders);
  };

  useEffect(() => {
    getAllOrders();
  }, []);

  if (!orders) {
    return null;
  }

  return (
    <>
      <div className="container">
        <br />
        <h1 className="text-center">Shepherd's Pizza Order Management</h1>
        <div className="container">
          <h3>All orders:</h3>
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
                {
                    orders.map((o, index) => {
                        
                    })
                }
            </tbody>
          </Table>
        </div>
      </div>
    </>
  );
};
