import React, { createContext, FC, useContext, useEffect, useReducer } from "react";
import IState from "./Interfaces/IState";
import IUser from "./Interfaces/IUser";
import IValue from "./Interfaces/IValue";
import reducer from "./reducer";
import Role from "./types/Role";

export const tokenStorageKey: string = "tsk";
const storageToken = localStorage.getItem(tokenStorageKey) as string | null;

const userStorageKey: string = "usk";
const storageUser = JSON.parse(localStorage.getItem(userStorageKey) || "null") as IUser | null;

const roleStorageKey: string = "rsk";
const roleUser = localStorage.getItem(roleStorageKey) as Role | null;

const AuthContext = createContext({} as IValue);

const initialState: IState = { user: storageUser, token: storageToken, role: roleUser};
export const AuthProvider: FC = ({ children }) => {
    const [state, dispatch] = useReducer(reducer, initialState);

    useEffect(() => {
        if (state.token && state.user && state.role) {
            localStorage.setItem(userStorageKey, JSON.stringify(state.user));
            localStorage.setItem(tokenStorageKey, state.token);
            localStorage.setItem(roleStorageKey, state.role);
            
        } else {
            localStorage.removeItem(tokenStorageKey);
            localStorage.removeItem(userStorageKey);
            localStorage.removeItem(roleStorageKey);
        }
    }, [state.user, state.token, state.role]);

    return <AuthContext.Provider value={{ state, dispatch }}>{children}</AuthContext.Provider>
}

export const useAuth = (): IValue => {
    const value = useContext(AuthContext);
    return value;
}