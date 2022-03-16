import { FC } from "react";
import Tickets from "../../components/Tickets";
import { useAuth } from "../../contexts/AuthContext";
import NewTicketPage from "../NewTicketPage";
import IProps from "./Interfaces/IProps";

const DashboardPage: FC<IProps> = (props) => {
    const { state: { role } } = useAuth();
    debugger;
    switch (role) {
        case "client":
            return <NewTicketPage />
        case "seller":
            return <Tickets />
        default:
            return <Tickets />
    }

}


export default DashboardPage;