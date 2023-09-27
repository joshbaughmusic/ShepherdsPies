import { useEffect, useState } from 'react';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Form,
  FormGroup,
  Label,
  Input,
} from 'reactstrap';
import {
  fetchCheeses,
  fetchSauces,
  fetchSizes,
  fetchToppings,
} from '../../managers/PizzaManager.js';

export const PizzaCreate = ({ orderPizzas, setOrderPizzas }) => {
  const [newPizza, setNewPizza] = useState({
    size: null,
    cheese: null,
    sauce: null,
    toppings: []
    // set price = totalPizzaPrice on create
  });
  const [totalPizzaPrice, setTotalPizzaPrice] = useState(0);
  const [sizes, setSizes] = useState();
  const [cheeses, setCheeses] = useState();
  const [sauces, setSauces] = useState();
  const [toppings, setToppings] = useState();
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const getAllPizzaOptions = () => {
    fetchSizes().then(setSizes);
    fetchCheeses().then(setCheeses);
    fetchSauces().then(setSauces);
    fetchToppings().then(setToppings);
  };

  useEffect(() => {
    getAllPizzaOptions();
  }, []);

  useEffect(() => {
    let price = 0;
    if (newPizza.size) {
      price += parseInt(newPizza.size.price);
    }
    price += newPizza.toppings.length * 0.5;
    setTotalPizzaPrice(price);
  }, [newPizza]);

  const handleChange = (e) => {
    console.log(e.target.value);
    setNewPizza({
      ...newPizza,
      [e.target.name]: JSON.parse(e.target.value),
    });
  };

  const handleCheck = (e) => {
    const isChecked = e.target.checked;
    const parsedObj = JSON.parse(e.target.value);

    if (isChecked) {
      let newArr = [...newPizza.toppings, parsedObj];
      setNewPizza({
        ...newPizza,
        toppings: newArr,
      });
    } else {
      setNewPizza({
        ...newPizza,
        toppings: newPizza.toppings.filter((t) => t.id !== parsedObj.id),
      });
    }
  };

  const handleSubmit = () => {
    let newPizzaWithPrice = {
        ...newPizza,
        price: totalPizzaPrice
    }
    setOrderPizzas([...orderPizzas, newPizzaWithPrice]);
    setNewPizza({
      size: null,
      cheese: null,
      sauce: null,
      toppings: []
    });
    toggle();
  };

  if (!sizes || !cheeses || !sauces || !toppings) {
    return null;
  }
  return (
    <>
      <Button
        color="primary"
        onClick={toggle}
      >
        Add Pizza
      </Button>
      <Modal
        isOpen={modal}
        toggle={toggle}
      >
        <ModalHeader toggle={toggle}>Create a pizza</ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label htmlFor="size">Size</Label>
              <Input
                name="size"
                type="select"
                onChange={handleChange}
              >
                <option value={null}>Select a size</option>
                {sizes.map((s, index) => {
                  return (
                    <option
                      key={index}
                      value={JSON.stringify(s)}
                    >
                      {s.name} -- ${s.price}
                    </option>
                  );
                })}
              </Input>
            </FormGroup>
          </Form>
          <Form>
            <FormGroup>
              <Label htmlFor="cheese">Cheese</Label>
              <Input
                name="cheese"
                type="select"
                onChange={handleChange}
              >
                <option value={null}>Select a cheese</option>
                {cheeses.map((c, index) => {
                  return (
                    <option
                      key={index}
                      value={JSON.stringify(c)}
                    >
                      {c.name}
                    </option>
                  );
                })}
              </Input>
            </FormGroup>
          </Form>
          <Form>
            <FormGroup>
              <Label htmlFor="sauce">Sauce</Label>
              <Input
                name="sauce"
                type="select"
                onChange={handleChange}
              >
                <option value={null}>Select a sauce</option>
                {sauces.map((s, index) => {
                  return (
                    <option
                      key={index}
                      value={JSON.stringify(s)}
                    >
                      {s.name}
                    </option>
                  );
                })}
              </Input>
            </FormGroup>
            <h6>Toppings:</h6>
            {toppings.map((t, index) => {
              return (
                <FormGroup
                  check
                  key={index}
                >
                  <Input
                    name={t.name}
                    type="checkbox"
                    value={JSON.stringify(t)}
                    onChange={handleCheck}
                    checked={!!newPizza.toppings.find((top) => top.id == t.id)}
                  />
                  <Label
                    check
                    htmlFor={t.name}
                  >
                    {t.name}
                  </Label>
                </FormGroup>
              );
            })}
          </Form>
          <h5>Total:</h5>
          <p>{`$${totalPizzaPrice}`}</p>
          <Button
            color="primary"
            onClick={handleSubmit}
          >
            Confirm Pizza
          </Button>
        </ModalBody>
      </Modal>
    </>
  );
};
