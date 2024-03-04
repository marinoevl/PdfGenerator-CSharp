import axios from 'axios';

import { API, NODE_ENV } from '@/config';

const api = axios.create({
    baseURL: API.BASE_URL,
    timeout: NODE_ENV === 'production' ? API.TIMEOUT : undefined,
    headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
    },
});

//Interceptor here

export default api;