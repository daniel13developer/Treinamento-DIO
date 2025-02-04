import axios from 'axios';

const apiUrl = process.env.REACT_APP_API_URL;

const api = axios.create({
  // baseURL: 'http://localhost:7233/api/', // Corrigido para 'baseURL'
  baseURL: apiUrl,
  headers: {
    'Content-Type': 'multipart/form-data',
  }
});

export default api;
