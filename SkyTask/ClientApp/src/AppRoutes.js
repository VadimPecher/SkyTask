import { Tenants } from "./components/Tenants";
import { EditTenant } from "./components/EditTenant";

const AppRoutes = [
  {
    index: true,
    element: <Tenants />
  },
  {
    path: 'edit-tenant/:id?',
    element: <EditTenant />
  }
];

export default AppRoutes;
