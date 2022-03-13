import { ICheckBoxOptions } from "devextreme-react/check-box";
import EnumMsg from "../../../translate/enums/EnumMsg";

export default interface IProps extends ICheckBoxOptions {
	errors?: string[];
	label?: EnumMsg;
}
