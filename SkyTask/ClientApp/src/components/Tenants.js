import React, { Component } from 'react';

export class Tenants extends Component {
    static displayName = Tenants.name;

    constructor(props) {
        super(props);
        this.state = { tenants: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderTable(tenants) {
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

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Tenants.renderTable(this.state.tenants);

        return (
            <div>
                <h1 id="tabelLabel" >Tenants</h1>
                {contents}
                <a href="/edit-tenant">Add tenant</a>
            </div>
        );
    }

    async populateData() {
        const response = await fetch('tenants');
        const data = await response.json();
        this.setState({ tenants: data, loading: false });
    }
}
