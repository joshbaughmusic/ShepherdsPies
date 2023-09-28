import { useEffect, useState } from 'react';
import { fetchEmployees } from '../../managers/EmployeeManager.js';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { fetchAssignDriverToOrder } from '../../managers/OrderManager.js';

export const OrderAssignDriver = ({ orderId, getSingleOrder }) => {
  const [toggleAssignSelect, setToggleAssignSelect] = useState(false);
  const [employees, setEmployees] = useState();

  const getAllEmployees = () => {
    fetchEmployees().then(setEmployees);
  };

  useEffect(() => {
    getAllEmployees();
  }, []);

  const handleAssign = (e) => {
    fetchAssignDriverToOrder(orderId, parseInt(e.target.value)).then(() => getSingleOrder())
  };

  if (!toggleAssignSelect) {
    return (
      <>
        <Button
          color="primary"
          onClick={() => setToggleAssignSelect(!toggleAssignSelect)}
        >
          Assign Driver
        </Button>
      </>
    );
  } else {
    return (
      <>
        <Form>
          <FormGroup>
            <Label>Select Employee to Assign</Label>
            <Input type="select" onChange={handleAssign}>
              <option value={null}>--</option>
              {employees.map((e, index) => {
                return (
                  <>
                    <option value={e.id}>
                      {e.firstName} {e.lastName}
                    </option>
                  </>
                );
              })}
            </Input>
          </FormGroup>
        </Form>
      </>
    );
  }
};
