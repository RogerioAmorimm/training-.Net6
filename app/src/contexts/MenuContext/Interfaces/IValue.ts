import React from "react";
import DispatchType from "../types/DispatchType";
import IState from "./IState";

export default interface IValue {
	state: IState;
	dispatch: React.Dispatch<DispatchType>;
}
