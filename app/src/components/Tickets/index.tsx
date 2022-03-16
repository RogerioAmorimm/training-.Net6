import { FC, memo } from "react";
import { useTickets } from "../../contexts/TicketsContext";
import IProps from "./interfaces/IProps";
import TicketItem from "./TicketItem";

const Tickets: FC<IProps> = () => {
    const { state: { itens } } = useTickets();
    return (
        <ul>
            {itens.map((e) =>
                <TicketItem from={e.from} title={e.title} to={e.to} key={`${e.from}${e.title}${e.to}`} />
            )};
        </ul>
    )
}

export default memo(Tickets)