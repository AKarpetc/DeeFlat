import { Navigate } from 'react-router-dom';
import DashboardLayout from './components/DashboardLayout';
import MainLayout from './components/MainLayout';
import Account from './pages/Account';
import CustomerList from './pages/CustomerList';
import CourcesList from './pages/CourcesList';
import GroupList from './pages/GroupList';
import Dashboard from './pages/Dashboard';
import Login from './pages/Login';
import NotFound from './pages/NotFound';
import ProductList from './pages/ProductList';
import Register from './pages/Register';
import Settings from './pages/Settings';
import { withOidcSecure, OidcSecure } from '@axa-fr/react-oidc-context';

var SecureAccount = function () {
  return (<OidcSecure>
    <Account />
  </OidcSecure>)
}

var SecureElement = function (Element) {
  return (<OidcSecure>
    <Element></Element>
  </OidcSecure>)
}

const routes = [
  {
    path: 'app',
    element: <DashboardLayout />,
    children: [
      { path: 'account', element: SecureElement(Account) },
      { path: 'customers', element: SecureElement(CustomerList) },
      { path: 'dashboard', element: <Dashboard /> },
      { path: 'products', element: <ProductList /> },
      { path: 'settings', element: <Settings /> },
      { path: 'learning', element: SecureElement(CourcesList) },
      { path: 'groups', element: SecureElement(GroupList) },
      { path: '*', element: <Navigate to="/404" /> }
    ]
  },
  {
    path: '/',
    element: <MainLayout />,
    children: [
      { path: 'login', element: <Login /> },
      { path: 'register', element: <Register /> },
      { path: '404', element: <NotFound /> },
      { path: '/', element: <Navigate to="/app/dashboard" /> },
      { path: '*', element: <Navigate to="/404" /> }
    ]
  }
];

export default routes;
