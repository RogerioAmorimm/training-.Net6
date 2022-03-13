import { NavigateFunction, Params,Location  } from "react-router-dom";

export default interface IPageProps {
    routeParams: Params<string>;
    routeNavigate: NavigateFunction;
    routeLocation: Location;
};  