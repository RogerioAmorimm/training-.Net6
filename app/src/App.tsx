import { FC } from "react"
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { ThemeProvider } from "styled-components";
import AppRoute from "./components/AppRouter";
import routes from "./config/routes";
import { AuthProvider } from "./contexts/AuthContext";
import { TranslateProvider } from "./contexts/TranslateContext";
import LightTheme from "./styles/themes/LightTheme";
import GlobalStyles from './styles/globals'
import "devextreme/dist/css/dx.light.css";

const App: FC = () => {
  return (
    <AuthProvider>
      <TranslateProvider>
        <ThemeProvider theme={LightTheme}>
          <GlobalStyles />
          <BrowserRouter>
            <Routes>
              {routes.map((route) => {
                const routeComponent = <Route path={route.path} key={route.path} element={<AppRoute {...route} />} />;
                if (!route.subRoutes?.length) return routeComponent;
                else {
                  const itemRoutes = route.subRoutes.map((sub) => {
                    let path = route.path.concat("/").concat(sub.subPath);
                    path = path.replaceAll("//", "/");
                    return (
                      <Route
                        path={path}
                        key={path}
                        element={
                          <AppRoute
                            path={path}
                            component={sub.component}
                            displayOnMenu={route.displayOnMenu}
                            isPrivate={route.isPrivate}
                            name={sub.name}
                            icon={route.icon}
                            layout={route.layout}
                          />
                        }
                      />
                    );
                  });
                  if (route.path.replaceAll("/", "").length) itemRoutes.unshift(routeComponent);

                  return itemRoutes;
                }
              })}
            </Routes>
          </BrowserRouter>
        </ThemeProvider>
      </TranslateProvider>
    </AuthProvider>
  );
}

export default App
