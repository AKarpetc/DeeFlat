import 'react-perfect-scrollbar/dist/css/styles.css';
import { useRoutes } from 'react-router-dom';
import { AuthProvider } from 'oidc-react';
import { ThemeProvider, StyledEngineProvider } from '@material-ui/core';
import GlobalStyles from './components/GlobalStyles';
import theme from './theme';
import routes from './routes';


const oidcConfig = {
  onSignIn: async (user: any) => {
    alert('You just signed in, congratz! Check out the console!');
    console.log(user);
   // window.location.hash = '';
  },
  authority: 'https://localhost:5001/',
  clientId: 'spa.client',
  client_secret: ["511536EF-F270-4058-80CA-1C89C192F69A"],
  grant_type: ["implicit"],
  responseType: 'id_token',
  redirectUri: 'http://localhost:3000',
  scope: "openid profile", // add other scopes here
};

const App = () => {
  const content = useRoutes(routes);

  return (
    <AuthProvider {...oidcConfig}>
      <StyledEngineProvider injectFirst>
        <ThemeProvider theme={theme}>
          <GlobalStyles />
          {content}
        </ThemeProvider>
      </StyledEngineProvider>
    </AuthProvider>
  );
};

export default App;
