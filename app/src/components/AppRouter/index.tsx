import { FC, useCallback, useEffect, useState } from "react";
import IProps from "./interfaces/IProps";
import { useParams, useLocation, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";

const AppRouter: FC<IProps> = ({ component: Component, layout: Layout, name, icon, isPrivate, path }) => {
	const [allowedAccess, setAllowedAccess] = useState<boolean>(false);

	const params = useParams();
	const location = useLocation();
	const navigate = useNavigate();

	const { state: authState } = useAuth();

	useEffect(() => {
		if (isPrivate) {
			if (authState.token && authState.user) setAllowedAccess(true);
			else navigate("/");
		} else setAllowedAccess(true);
	}, [isPrivate, authState.token, authState.user, navigate]);

	useEffect(() => {
		if (!authState.user && !authState.token && path !== "/") {
			navigate("/");
		}
	}, [authState.user, authState.token, navigate, path]);

	const getChildren = useCallback(() => {
		if (allowedAccess) return Component ? <Component routeLocation={location} routeNavigate={navigate} routeParams={params} /> : <div />;
		return <div />;
	}, [allowedAccess, Component, location, params, navigate]);

	return Layout ? <Layout name={name} icon={icon} children={getChildren()} /> : <>{getChildren()}</>;
};

export default AppRouter;
