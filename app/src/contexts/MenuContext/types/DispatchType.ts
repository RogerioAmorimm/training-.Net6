import IState from "../Interfaces/IState";
import MenuPositionType from "./MenuPositionType";

interface IDispatch_SET_MENU_CONFIG {
    type: "SET_MENU_CONFIG";
    payload: IState;
}

interface IDispatch_SET_MENU_OPEN {
    type: "SET_MENU_OPEN";
    payload: boolean;
}

interface IDispatch_SET_MENU_POSITION {
    type: "SET_MENU_POSITION";
    payload: MenuPositionType;
}
interface IDispatch_SET_MENU_FAVORITES {
    type: "SET_MENU_FAVORITES";
    payload: string[];
}

interface IDispatch_SET_MENU_HIDDEN {
    type: "SET_MENU_HIDDEN";
    payload: string[];
}

interface IDispatch_CLEAR_MENU_CONFIG {
    type: "CLEAR_MENU_CONFIG";
    payload?: IState;
}

type DispatchType = IDispatch_SET_MENU_CONFIG
    | IDispatch_SET_MENU_OPEN
    | IDispatch_SET_MENU_POSITION
    | IDispatch_SET_MENU_FAVORITES
    | IDispatch_SET_MENU_HIDDEN
    | IDispatch_CLEAR_MENU_CONFIG;

export default DispatchType;