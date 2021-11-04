import 'react-perfect-scrollbar/dist/css/styles.css';
import { useRoutes } from 'react-router-dom';
import { AuthProvider } from 'oidc-react';
import { ThemeProvider, StyledEngineProvider } from '@material-ui/core';
import GlobalStyles from './components/GlobalStyles';
import theme from './theme';
import routes from './routes';
import CustomCallback from './pages/CustomCallback';
import { AuthenticationProvider, oidcLog, InMemoryWebStorage } from '@axa-fr/react-oidc-context';
import oidcConfiguration from './configuration';



const App = () => {
  const content = useRoutes(routes);

  return (

    <StyledEngineProvider injectFirst>
      <ThemeProvider theme={theme}>
        <GlobalStyles />
        <AuthenticationProvider
          configuration={oidcConfiguration}
          loggerLevel={oidcLog.DEBUG}
          isEnabled={true}
          callbackComponentOverride={CustomCallback}
          UserStore={InMemoryWebStorage}
        >
          {content}
        </AuthenticationProvider>
      </ThemeProvider>
    </StyledEngineProvider>

  );
};

export default App;
