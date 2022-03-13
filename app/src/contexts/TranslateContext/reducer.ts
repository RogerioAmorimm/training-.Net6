
import IState from "./Intefaces/IState";
import DispatchType from "./types/DispatchType";

const reducer = (state: IState, action: DispatchType): IState => {
    switch (action.type) {
        case 'SET_LANG':
            return { ...state, lang: action.payload }
        default:
            return state;
    }
}

export default reducer;