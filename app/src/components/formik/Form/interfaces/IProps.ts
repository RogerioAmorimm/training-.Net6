import { IConfigField } from "./IConfigField";
import { FormikHelpers } from "formik";
import EnumMsg from "../../../../translate/enums/EnumMsg";

export default interface IProps<T> {
	config: IConfigField[];
	initialValues: T;
	validate?: (data: T) => Promise<object | null>;
	submit: (data: T, actions: FormikHelpers<T>) => void;
	confirmText?: EnumMsg;
}
