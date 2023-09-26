const _apiUrl = '/api/order'

export const fetchAllOrders = () => {
    return fetch(_apiUrl).then(res => res.json())
}

export const fetchSingleOrder = (id) => {
    return fetch(`${_apiUrl}/${id}`).then(res => res.json())
}