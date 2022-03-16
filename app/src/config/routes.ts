import { MdDashboard } from "react-icons/md";
import IRouteProps from "../components/AppRouter/interfaces/IProps";
import Layout from "../components/Layout";
import DashboardPage from "../pages/Dashboard";
import LoginPage from "../pages/Login";
import NewTicketPage from "../pages/NewTicketPage";
import TicketsPage from "../pages/TicketsPage";
import EnumMsg from "../translate/enums/EnumMsg";
import EnumMenuGroup from "./enums/EnumMenuGroup";

const routes: IRouteProps[] = [
    {
        path: '/',
        component: LoginPage,
        name: EnumMsg.Acessar,
        isPrivate: false,
        displayOnMenu: false
    },
    {
		path: "/dashboard",
		component: DashboardPage,
		layout: Layout,
		name: EnumMsg.Dashboard,
		icon: MdDashboard,
		isPrivate: false,
		displayOnMenu: true,
		menuGroup: EnumMenuGroup.Resumos,
	},
	{
		path: "/new-ticket",
		component: NewTicketPage,
		layout: Layout,
		name: EnumMsg.NewTickets,
		icon: MdDashboard,
		isPrivate: false,
		displayOnMenu: true,
		menuGroup: EnumMenuGroup.Resumos,
	},
	{
		path: "/tickets",
		component: TicketsPage,
		layout: Layout,
		name: EnumMsg.Tickets,
		icon: MdDashboard,
		isPrivate: false,
		displayOnMenu: true,
		menuGroup: EnumMenuGroup.Resumos,
	},
]

export default routes;
