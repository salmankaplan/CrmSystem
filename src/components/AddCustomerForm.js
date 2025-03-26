import { useState } from "react";
import axios from "axios";

function AddCustomerForm({ onCustomerAdded }) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [region, setRegion] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const token = localStorage.getItem("token");
      const response = await axios.post(
        "http://localhost:5022/api/createCustomer",
        { firstName, lastName, email, region },
        { headers: { Authorization: `Bearer ${token}` } }
      );
      onCustomerAdded(response.data);
    } catch (error) {
      console.error("Error adding customer", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" placeholder="First Name" value={firstName} onChange={(e) => setFirstName(e.target.value)} required />
      <input type="text" placeholder="Last Name" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
      <input type="email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} required />
      <input type="text" placeholder="Region" value={region} onChange={(e) => setRegion(e.target.value)} required />
      <button type="submit">Add Customer</button>
    </form>
  );
}

export default AddCustomerForm;