const _apiUrl = '/api/customer';

export const fetchCustomers = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

// export const fetchSingleEmployee = (id) => {
//   return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
// };
