const _env = import.meta.env;

export const NODE_ENV = _env.VUE_APP_BASE_URL_ENV;

export const BASE_URL = _env.VUE_BASE_URL;

export const API = {
    BASE_URL: _env.VITE_URL_API,
    TIMEOUT: 30000,
};