import React, { createContext, FC, useContext, useEffect, useReducer } from "react";
import IState from "./Interfaces/IState";
import IUser from "./Interfaces/IUser";
import IValue from "./Interfaces/IValue";
import reducer from "./reducer";

export const tokenStorageKey: string = "tsk";
const storageToken = localStorage.getItem(tokenStorageKey) as string | null;

const userStorageKey: string = "usk";
const storageUser = JSON.parse(localStorage.getItem(userStorageKey) || "null") as IUser | null;

const AuthContext = createContext({} as IValue);

const initialState: IState = { user: storageUser, token: storageToken };
export const AuthProvider: FC = ({ children }) => {
    const [state, dispatch] = useReducer(reducer, initialState);

    useEffect(() => {
        if (state.token && state.user) {
            localStorage.setItem(userStorageKey, JSON.stringify(state.user));
            localStorage.setItem(tokenStorageKey, state.token);
        } else {
            localStorage.removeItem(tokenStorageKey);
            localStorage.removeItem(userStorageKey);
        }
    }, [state.user, state.token]);

    return <AuthContext.Provider value={{ state, dispatch }}>{children}</AuthContext.Provider>
}

export const useAuth = (): IValue => {
    const value = useContext(AuthContext);
    return value;
}