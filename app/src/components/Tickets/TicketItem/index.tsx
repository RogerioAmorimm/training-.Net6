import { FC } from "react";
import IProps from "./interfaces/IProps";

const TicketItem: FC<IProps> = ({ from, title, to }) => {
    return (
        <li key={title}>
            <span>{title}</span>
            <br />
            <span>{from} : {to}</span>
        </li>);
}

export default TicketItem;