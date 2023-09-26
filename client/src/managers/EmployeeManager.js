const _apiUrl = '/api/employee';

export const fetchEmployees = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

// export const fetchSingleEmployee = (id) => {
//   return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
// };
