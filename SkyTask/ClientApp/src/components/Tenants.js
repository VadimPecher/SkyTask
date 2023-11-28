import React, { useState, useEffect } from 'react';

export function Tenants() {
    const [tenants, setTenants] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const dataFetch = async () => {
            const response = await fetch('tenants');
            const data = await response.json();
            setTenants(data);
            setLoading(false);
        };

        dataFetch();
    }, []);

    const renderTable = (tenants) => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Country</th>
                        <th>Portfolios</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {tenants.map(tenant =>
                        <tr key={tenant.tenantId}>
                            <td>{tenant.tenantName}</td>
                            <td>{tenant.tenantCountry}</td>
                            <td>{tenant.portfolios}</td>
                            <td><a href={'/edit-tenant/' + tenant.tenantId}>Edit</a></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    return (
        <div>
            <h1 id="tabelLabel" >Tenants</h1>
            {loading
                ? <p><em>Loading...</em></p>
                : renderTable(tenants)
            }
            <a href="/edit-tenant">Add tenant</a>
        </div>
    );
}
