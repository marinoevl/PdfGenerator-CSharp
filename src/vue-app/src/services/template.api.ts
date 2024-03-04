import apiClient from '@/core/api/';
const baseApiURL = 'api/template';

export const getAllTemplate = async () =>
    await apiClient.get(`${baseApiURL}`);

export const getTemplateById = async (id: string) =>
    await apiClient.get(
        `${baseApiURL}/${id}`
    );

export const createTemplate = async (name: string, content: string) =>
    await apiClient.post(`${baseApiURL}`, {
        name,
        content
    });

export const updateTemplate = async (id: string, content: string) =>
    await apiClient.put(`${baseApiURL}/${id}`, content);

export const deleteTemplate = async (id: string) =>
    await apiClient.delete(`${baseApiURL}/${id}`);