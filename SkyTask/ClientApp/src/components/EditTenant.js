import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

export function EditTenant(props) {
    const params = useParams();
    const id = params.id;
    const isUpdate = id != undefined;

    const [name, setName] = useState('');
    const [country, setCountry] = useState('');
    const [error, setError] = useState('');

    // for editing:
    useEffect(() => {
        const dataFetch = async () => {

            if (id) {
                const saved = await (
                    await fetch('tenants/get/' + id)
                ).json();

                // set state when the data received
                setName(saved.tenantName);
                setCountry(saved.tenantCountry);
            }
        };

        dataFetch();
    }, []);

    const handleChange = (event) => {
        switch (event.target.name) {
            case "name": setName(event.target.value); break;
            case "country": setCountry(event.target.value); break;
        }
    }

    const createUpdate = async (event) => {
        event.preventDefault();

        setError("");
        const data = {
            tenantId: id,
            tenantName: name,
            tenantCountry: country,
        };
        const response = await fetch('tenants/' + (isUpdate ? 'update' : 'create'),
            {
                method: isUpdate ? "PUT": "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            });
        if (response.ok) {
            window.open("/", "_self");
        }
        else {
            setError("Failure");
        }
    }

    return (
        <div>
            <h1>Add tenant</h1>
            <form onSubmit={createUpdate}>
                <div><input name="name" value={name} onChange={handleChange} placeholder="Name"></input></div>
                <div><input name="country" value={country} onChange={handleChange} placeholder="Country"></input></div>
                <button type="submit" className="btn btn-primary">{isUpdate ? "Update" : "Add"}</button>
                {error && <span style={{ color: 'red', padding:'10px' }} >{error}</span>}
            </form>
        </div>
    );
}
