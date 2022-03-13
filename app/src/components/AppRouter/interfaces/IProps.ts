import { FC } from "react";
import { IconType } from "react-icons/lib";
import EnumMenuGroup from "../../../config/enums/EnumMenuGroup";
import IDefaultLayoutProps from "../../../config/interfaces/IDefaultLayoutProps";
import IPageProps from "../../../pages/interfaces/IPageProps";
import EnumMsg from "../../../translate/enums/EnumMsg";

export interface ISubRouteProps {
	subPath: string;
	component: FC<IPageProps>;
	name: EnumMsg;
}

export default interface IProps {
	path: string;
	component?: FC<IPageProps>;
	layout?: FC<IDefaultLayoutProps>;
	name: EnumMsg;
	icon?: IconType;
	isPrivate: boolean;
	displayOnMenu: boolean;
	menuGroup?: EnumMenuGroup;
	subRoutes?: ISubRouteProps[];
}
