import axios from 'axios'
const baseURL = "/api"

const dealOneCard = () => {
    const request = axios.get(`${baseURL}`)
    return request.then(response => response.data)
}

const shuffle = () => {
    const request = axios.get(`${baseURL}/shuffle`)
    return request.then(response => response.data)
}

const cut = () => {
    const request = axios.get(`${baseURL}/cut`)
    return request.then(response => response.data)
}
export default { dealOneCard, shuffle, cut }