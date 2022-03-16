import { createContext, FC, useContext, useEffect, useReducer } from "react"

import IState from "./interfaces/IState";
import IValue from "./interfaces/IValue";
import reducer from "./reduce";


const ticketsStorageKey: string = "tcksk";

const storageTickets = JSON.parse(localStorage.getItem(ticketsStorageKey) || "null") as IState | null;

const initialState: IState = storageTickets || { itens: [] };

const TicketsContext = createContext({} as IValue);

export const TicketProvider: FC = ({ children }) => {
    
    const [state, ticketDispatch] = useReducer(reducer, initialState);
    
    useEffect(() => {
        localStorage.setItem(ticketsStorageKey, JSON.stringify(state));
    }, [state]);

    return (
        <TicketsContext.Provider value={{ state, dispatch: ticketDispatch }}>{children}</TicketsContext.Provider>
    )
}

export const useTickets = (): IValue => {
    const value = useContext(TicketsContext);
    return value;
}