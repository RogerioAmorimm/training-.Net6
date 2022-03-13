import React from "react";
import EnumMsg from "../../../translate/enums/EnumMsg";
import DispatchType from "../types/DispatchType";
import IState from "./IState";

export default interface IValue {
	state: IState;
	dispatch: React.Dispatch<DispatchType>;
	translate: (key: EnumMsg) => string;
}
