import { useEffect, useState } from 'react';
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  Form,
  FormGroup,
  Label,
  Input,
  Spinner,
} from 'reactstrap';
import {
  fetchAddPizza,
  fetchCheeses,
  fetchSauces,
  fetchSizes,
  fetchToppings,
} from '../../managers/PizzaManager.js';

export const PizzaAdd = ({ getSingleOrder, orderId }) => {
  const [newPizza, setNewPizza] = useState({
    size: null,
    cheese: null,
    sauce: null,
    pizzaToppings: [],
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
    if (newPizza.sizeId) {
      if (newPizza.sizeId == 1) {
        price += 10;
      } else if (newPizza.sizeId == 2) {
        price += 12;
      } else {
        price += 15;
      }
    }
    price += newPizza.pizzaToppings.length * 0.5;
    setTotalPizzaPrice(price);
  }, [newPizza]);

  const handleChange = (e) => {
    setNewPizza({
      ...newPizza,
      [e.target.name]: e.target.value,
    });
  };

  const handleCheck = (e, t) => {
    const isChecked = e.target.checked;
    if (isChecked) {
      let newPizzaToppingObj = {
        toppingId: t.id,
        topping: toppings.find((top) => top.id === t.id),
      };
      let newArr = [...newPizza.pizzaToppings, newPizzaToppingObj];
      setNewPizza({
        ...newPizza,
        pizzaToppings: newArr,
      });
    } else {
      setNewPizza({
        ...newPizza,
        pizzaToppings: newPizza.pizzaToppings.filter(
          (pt) => pt.toppingId !== t.id
        ),
      });
    }
  };

  const handleSubmit = () => {
    let newPizzaToSubmit = { ...newPizza };
    newPizzaToSubmit.orderId = orderId;
    newPizzaToSubmit.size = sizes.find((x) => x.id == newPizzaToSubmit.sizeId);
    newPizzaToSubmit.cheese = cheeses.find(
      (x) => x.id == newPizzaToSubmit.cheeseId
    );
    newPizzaToSubmit.sauce = sauces.find(
      (x) => x.id == newPizzaToSubmit.sauceId
    );

    fetchAddPizza(orderId, newPizzaToSubmit).then(() => getSingleOrder());
    setNewPizza({
      size: null,
      cheese: null,
      sauce: null,
      pizzaToppings: [],
    });
    toggle();
  };

  if (!sizes || !cheeses || !sauces || !toppings || !newPizza) {
    return <Spinner/>;
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
        <ModalHeader toggle={toggle}>Add New Pizza</ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label htmlFor="sizeId">Size</Label>
              <Input
                name="sizeId"
                type="select"
                value={newPizza.sizeId}
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
                value={newPizza.cheeseId}
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
                value={newPizza.sauceId}
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
                      !!newPizza.pizzaToppings.find(
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
