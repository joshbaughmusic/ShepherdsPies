const _apiUrl = '/api/customer';

export const fetchCustomers = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const fetchCreateCustomer = (customer) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(customer),
  }).then((res) => res.json());
};
