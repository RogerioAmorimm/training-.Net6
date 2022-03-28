import { Button } from "devextreme-react/autocomplete";
import { FC } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import TicketsPage from "../TicketsPage";
import IProps from "./Interfaces/IProps";

const DashboardPage: FC<IProps> = (props) => {
    const params = useParams();
    const location = useLocation();
    const navigate = useNavigate();

    return (
        <>
            <TicketsPage routeLocation={location} routeNavigate={navigate} routeParams={params} />
        </>
    );

}


export default DashboardPage;