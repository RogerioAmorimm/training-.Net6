import { FC } from "react";
import FormTicket from "../../components/FormTicket";
import { useTranslate } from "../../contexts/TranslateContext";
import EnumMsg from "../../translate/enums/EnumMsg";
import IProps from "./interfaces/IProps";

const NewTicketPage: FC<IProps> = () => {
    const { translate } = useTranslate();
    return (
        <>
            <h1> EM CONSTRUÇÃO {translate(EnumMsg.NewTickets)}</h1>
            <FormTicket />
        </>);
}

export default NewTicketPage;