import IState from "./Interfaces/IState";
import DispatchType from "./types/DispatchType";

const reducer = (state: IState, action: DispatchType): IState => {
    switch (action.type) {
        case "SET_MENU_CONFIG": {
            return { ...state, ...action.payload };
        }
        case "SET_MENU_OPEN": {
            return { ...state, open: action.payload }
        }
        case "SET_MENU_POSITION": {
            return { ...state, position: action.payload || "left" }
        }
        case "SET_MENU_FAVORITES": {
            const fav = action.payload || [];
            return {
                ...state,
                favorites: fav,
                hidden: state.hidden?.filter((x) => fav.indexOf(x) === -1) || []
            };
        }
        case "SET_MENU_HIDDEN": {
            const hidden = action.payload || [];
            return { ...state, hidden: hidden, favorites: state.favorites?.filter((x) => hidden.indexOf(x) === -1) || [] };

        }
        case "CLEAR_MENU_CONFIG": {
            return { open: true, favorites: [], hidden: [], position: "left" };
        }
        default:
            return state;

    }

}
export default reducer;
