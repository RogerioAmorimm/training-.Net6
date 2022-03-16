import IState from "./interfaces/IState";
import DispatchType from "./types/DispatchType";

const reducer = (state: IState, action: DispatchType): IState => {
    switch (action.type) {
        case "TO_SET":
            return state;
        default:
            return state;
    }
}


export default reducer;