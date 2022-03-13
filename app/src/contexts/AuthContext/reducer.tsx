import IState from "./Interfaces/IState";
import DispatchType from "./types/DispatchType";

const reducer = (state: IState, action: DispatchType): IState => {
    switch (action.type) {
        case "SIGN_IN":
            return { ...state, token: action.payload.token, user: action.payload.user };
        case "SIGN_OUT":
            return { ...state, token: null };
        default:
            return state;
    }
};

export default reducer;
