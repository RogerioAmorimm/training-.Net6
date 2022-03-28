import { FC } from "react";
import CadastroPage from "../GenericCadastroPage";
import { configCadastro } from "./formConfig";
import IProps from "./interfaces/IProps";
import ITicketPage from "./interfaces/ITicketPage";
import { TicketServiceModule as service } from '../../services/RequestApiService'

const TicketsPage: FC<IProps> = () =>
    <CadastroPage<ITicketPage> formConfig={configCadastro} service={service} />;




export default TicketsPage;