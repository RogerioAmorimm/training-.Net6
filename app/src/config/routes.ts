import IRouteProps from "../components/AppRouter/interfaces/IProps";
import LoginPage from "../pages/Login";
import EnumMsg from "../translate/enums/EnumMsg";

const routes: IRouteProps[] = [
    {
        path: '/',
        component: LoginPage,
        name: EnumMsg.Acessar,
        isPrivate: false,
        displayOnMenu: false
    }
]

export default routes;
