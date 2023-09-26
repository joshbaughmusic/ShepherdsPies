const _apiUrl = '/api/order'

export const fetchAllOrders = () => {
    return fetch(_apiUrl).then(res => res.json())
}