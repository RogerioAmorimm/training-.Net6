import { createContext, FC, useContext, useEffect, useReducer } from "react";
import IState from "./Interfaces/IState";
import IValue from "./Interfaces/IValue";
import reducer from "./reducer";


const menuStorageKey: string = "msk";
const storageConfig = JSON.parse(localStorage.getItem(menuStorageKey) || "null") as IState | null;

const MenuContext = createContext({} as IValue);

const initialState: IState = storageConfig || { open: true, favorites: [], hidden: [], position: "left" };
export const MenuProvider: FC = ({ children }) => {

    const [state, menuDispatch] = useReducer(reducer, initialState);

    useEffect(() => {
        localStorage.setItem(menuStorageKey, JSON.stringify(state));
    }, [state]);

    return <MenuContext.Provider value={{ state, dispatch: menuDispatch }}>{children}</MenuContext.Provider>;
}

export const useMenu = (): IValue => {
    const value = useContext(MenuContext);
    return value;
}