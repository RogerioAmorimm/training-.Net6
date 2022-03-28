import { createContext, FC, useContext, useEffect, useReducer } from "react"

import IState from "./interfaces/IState";
import IValue from "./interfaces/IValue";
import reducer from "./reduce";

const initialState: IState = { topic: 0 }

const TopicContext = createContext({} as IValue);

export const TopicProvider: FC = ({ children }) => {
    
    const [state, topicDispatch] = useReducer(reducer, initialState);

    return (
        <TopicContext.Provider value={{ state, dispatch: topicDispatch }}>{children}</TopicContext.Provider>
    )
}

export const useTopics = (): IValue => {
    const value = useContext(TopicContext);
    return value;
}