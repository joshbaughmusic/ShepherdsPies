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
