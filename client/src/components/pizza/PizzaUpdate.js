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
  Spinner,
} from 'reactstrap';
import {
  fetchCheeses,
  fetchSauces,
  fetchSinglePizza,
  fetchSizes,
  fetchToppings,
  fetchUpdatePizza,
} from '../../managers/PizzaManager.js';

export const PizzaUpdate = ({ id, getSingleOrder }) => {
  const [pizzaToUpdate, setPizzaToUpdate] = useState({
    orderId: null,
    sizeId: null,
    size: null,
    cheeseId: null,
    cheese: null,
    sauceId: null,
    sauce: null,
    pizzaToppings: [],
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

  const getSinglePizza = () => {
    fetchSinglePizza(id).then(setPizzaToUpdate);
  };

  useEffect(() => {
    getSinglePizza();
    getAllPizzaOptions();
  }, []);

  useEffect(() => {
    let price = 0;
    if (pizzaToUpdate.sizeId) {
      if (pizzaToUpdate.sizeId == 1) {
        price += 10;
      } else if (pizzaToUpdate.sizeId == 2) {
        price += 12;
      } else {
        price += 15;
      }
    }
    price += pizzaToUpdate.pizzaToppings.length * 0.5;
    setTotalPizzaPrice(price);
  }, [pizzaToUpdate]);

  const handleChange = (e) => {
    setPizzaToUpdate({
      ...pizzaToUpdate,
      [e.target.name]: e.target.value,
    });
  };

  const handleCheck = (e, t) => {
    const isChecked = e.target.checked;
    if (isChecked) {
      let newPizzaToppingObj = {
        pizzaId: id,
        toppingId: t.id,
      };
      let newArr = [...pizzaToUpdate.pizzaToppings, newPizzaToppingObj];
      setPizzaToUpdate({
        ...pizzaToUpdate,
        pizzaToppings: newArr,
      });
    } else {
      setPizzaToUpdate({
        ...pizzaToUpdate,
        pizzaToppings: pizzaToUpdate.pizzaToppings.filter(
          (pt) => pt.toppingId !== t.id
        ),
      });
    }
  };

  const handleSubmit = () => {
    fetchUpdatePizza(id, pizzaToUpdate.orderId, pizzaToUpdate).then(() => getSingleOrder());
    toggle();
  };

  if (!sizes || !cheeses || !sauces || !toppings || !pizzaToUpdate) {
    return <Spinner />;
  }
  return (
    <>
      <Button
        color="primary"
        onClick={toggle}
      >
        Update
      </Button>
      <Modal
        isOpen={modal}
        toggle={toggle}
      >
        <ModalHeader toggle={toggle}>Edit Pizza</ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label htmlFor="sizeId">Size</Label>
              <Input
                name="sizeId"
                type="select"
                value={pizzaToUpdate.sizeId}
                onChange={handleChange}
              >
                <option value={null}>Select a size</option>
                {sizes.map((s, index) => {
                  return (
                    <option
                      key={index}
                      value={s.id}
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
              <Label htmlFor="cheeseId">Cheese</Label>
              <Input
                name="cheeseId"
                type="select"
                onChange={handleChange}
                value={pizzaToUpdate.cheeseId}
              >
                <option value={null}>Select a cheese</option>
                {cheeses.map((c, index) => {
                  return (
                    <option
                      key={index}
                      value={c.id}
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
              <Label htmlFor="sauceId">Sauce</Label>
              <Input
                name="sauceId"
                type="select"
                onChange={handleChange}
                value={pizzaToUpdate.sauceId}
              >
                <option value={null}>Select a sauce</option>
                {sauces.map((s, index) => {
                  return (
                    <option
                      key={index}
                      value={s.id}
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
                    onChange={(e) => handleCheck(e, t)}
                    checked={
                      !!pizzaToUpdate.pizzaToppings.find(
                        (pt) => parseInt(pt.toppingId) == parseInt(t.id)
                      )
                    }
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
