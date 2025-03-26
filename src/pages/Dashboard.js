import { useEffect, useState } from "react";
import { getCustomers, deleteCustomer } from "../services/api";
import AddCustomerForm from "../components/AddCustomerForm";

function Dashboard() {
  const [customers, setCustomers] = useState([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    fetchCustomers();
  }, []);

  const fetchCustomers = async () => {
    try {
      const data = await getCustomers();
      setCustomers(data);
    } catch (error) {
      console.error("Error fetching customers:", error);
    }
  };

  const handleDelete = async (customerId) => {
    if (window.confirm("Are you sure?")) {
      try {
        await deleteCustomer(customerId);
        setCustomers(customers.filter((c) => c.id !== customerId));
      } catch (error) {
        console.error("Error deleting customer:", error);
      }
    }
  };

  const filteredCustomers = customers.filter((customer) =>
    customer.firstName.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="dashboard">
      <h2>Customer Management</h2>
      <input type="text" placeholder="Search by name..." value={search} onChange={(e) => setSearch(e.target.value)} />
      
      <AddCustomerForm onCustomerAdded={fetchCustomers} />

      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Region</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredCustomers.map((customer) => (
            <tr key={customer.id}>
              <td>{customer.firstName} {customer.lastName}</td>
              <td>{customer.email}</td>
              <td>{customer.region}</td>
              <td>
                <button onClick={() => handleDelete(customer.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Dashboard;