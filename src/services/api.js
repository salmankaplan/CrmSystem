import axios from "axios";

const API_URL = "http://localhost:5022/api";

const api = axios.create({
    baseURL: API_URL,
    headers: {
      "Content-Type": "application/json",
    },
  });


  api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  }, (error) => {
    return Promise.reject(error);
  });

  export const getCustomers = async () => {
    try {
      const response = await api.get("/getCustomers");
      return response.data;
    } catch (error) {
      console.error("Error fetching customers:", error);
      throw error;
    }
  };

  export const addCustomer = async (customerData) => {
    try {
      const response = await api.post("/createCustomers", customerData);
      return response.data;
    } catch (error) {
      console.error("Error adding customer:", error);
      throw error;
    }
  };
  

  export const updateCustomer = async (customerId, customerData) => {
    try {
      const response = await api.put(`/updateCustomers/${customerId}`, customerData);
      return response.data;
    } catch (error) {
      console.error("Error updating customer:", error);
      throw error;
    }
  };
  
  export const deleteCustomer = async (customerId) => {
    try {
      await api.delete(`/deleteCustomers/${customerId}`);
    } catch (error) {
      console.error("Error deleting customer:", error);
      throw error;
    }
  };

  export const login = async (credentials) => {
    try {
      const response = await api.post("/auth/login", credentials);
      localStorage.setItem("token", response.data.token);
      return response.data;
    } catch (error) {
      console.error("Login error:", error);
      throw error;
    }
  };
  
  export const logout = () => {
    localStorage.removeItem("token");
  };