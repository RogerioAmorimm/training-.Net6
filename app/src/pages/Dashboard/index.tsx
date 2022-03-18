import { FC } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import TicketsPage from "../TicketsPage";
import IProps from "./Interfaces/IProps";

const DashboardPage: FC<IProps> = (props) => {
    const { state: { role } } = useAuth();
    const params = useParams();
    const location = useLocation();
    const navigate = useNavigate();

    return role === "client"
        ? <TicketsPage onlylistMode={true} routeLocation={location} routeNavigate={navigate} routeParams={params} />
        : <TicketsPage onlylistMode={false} routeLocation={location} routeNavigate={navigate} routeParams={params} />;

}


export default DashboardPage;