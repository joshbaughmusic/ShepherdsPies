const _apiUrl = '/api/order'

export const fetchAllOrders = () => {
    return fetch(_apiUrl).then(res => res.json())
}

export const fetchSingleOrder = (id) => {
    return fetch(`${_apiUrl}/${id}`).then(res => res.json())
}

export const fetchNewOrder = (orderWithPizzas) => {
    return fetch(`${_apiUrl}/create`, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(orderWithPizzas)
    }).then(res => res.json())
}