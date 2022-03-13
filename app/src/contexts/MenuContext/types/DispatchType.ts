import IState from "../Interfaces/IState";

interface IDispatch_SET_MENU_CONFIG {
    type: "SET_MENU_CONFIG";
    payload: IState;
}
type DispatchType = IDispatch_SET_MENU_CONFIG;
export default DispatchType;