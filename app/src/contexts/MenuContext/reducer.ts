import IState from "./Interfaces/IState";
import DispatchType from "./types/DispatchType";

const reducer = (state: IState, action: DispatchType): IState => {
    switch (action.type) {
        case "SET_MENU_CONFIG": {
            return { ...state, ...action.payload };
        }
    }

}
export default reducer;
