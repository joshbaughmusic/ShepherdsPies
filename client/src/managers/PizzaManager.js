const _apiUrl = '/api/pizza';

export const fetchSizes = () => {
  return fetch(`${_apiUrl}/sizes`).then((res) => res.json());
};
export const fetchCheeses = () => {
  return fetch(`${_apiUrl}/cheeses`).then((res) => res.json());
};
export const fetchSauces = () => {
  return fetch(`${_apiUrl}/sauces`).then((res) => res.json());
};
export const fetchToppings = () => {
  return fetch(`${_apiUrl}/toppings`).then((res) => res.json());
};

export const fetchSinglePizza = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchUpdatePizza = (pizzaId, orderId, pizza) => {
  return fetch(`${_apiUrl}/${orderId}/${pizzaId}/update`, {
    method: "PUT",
    headers: {"Content-Type": "application/json"},
    body: JSON.stringify(pizza)
  })
}