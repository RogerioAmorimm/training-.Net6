import { createContext, FC, useReducer } from "react";
import IState from "./Interfaces/IState";
import IValue from "./Interfaces/IValue";
import reducer from "./reducer";


const menuStorageKey: string = "menu_config";
const storageConfig = JSON.parse(localStorage.getItem(menuStorageKey) || "null") as IState | null;

const MenuContext = createContext({} as IValue);

const initialState: IState = storageConfig || { open: true, favorites: [], hidden: [], position: "left" };
export const MenuProvider: FC = ({ children }) => {

    const [state, dispatch] = useReducer(reducer, initialState);
    return (
        <h1> teste</h1>
    );
}