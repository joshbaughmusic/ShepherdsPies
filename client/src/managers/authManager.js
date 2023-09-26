const _apiUrl = '/api/auth';

export const login = (email, password) => {
  return fetch(_apiUrl + '/login', {
    method: 'POST',
    credentials: 'same-origin',
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser();
    }
  });
};

export const logout = () => {
  return fetch(_apiUrl + '/logout');
};

export const tryGetLoggedInUser = () => {
  return fetch(_apiUrl + '/me').then((res) => {
    return res.status === 401 ? Promise.resolve(null) : res.json();
  });
};

export const register = (employee) => {
  employee.password = btoa(employee.password);
  return fetch(_apiUrl + '/register', {
    credentials: 'same-origin',
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(employee),
  }).then((res) => {
    if (res.errors) {
      return Promise.resolve(res.errors)
    } else {
      return fetch(_apiUrl + '/me').then((res) => res.json());
    }
  });
};
