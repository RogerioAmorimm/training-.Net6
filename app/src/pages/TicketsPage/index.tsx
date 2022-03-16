import { FC } from "react";
import { useTranslate } from "../../contexts/TranslateContext";
import IProps from "./interfaces/IProps";
import ITickeItem from '../../components/Tickets/TicketItem/interfaces/IProps';
import Tickets from "../../components/Tickets";

const TicketsPage: FC<IProps> = (props) => {
    const { translate } = useTranslate();
    const ticktesMock: ITickeItem[] = [
        { from: `from-1`, to: `to-1`, title: `title-1` },
        { from: `from-2`, to: `to-2`, title: `title-2` },
        { from: `from-3`, to: `to-3`, title: `title-3` },
        { from: `from-4`, to: `to-4`, title: `title-4` },
        { from: `from-5`, to: `to-5`, title: `title-5` },
    ];

    return <Tickets/>
}

export default TicketsPage;