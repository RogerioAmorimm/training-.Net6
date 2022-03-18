import EnumMsg from "../../../../translate/enums/EnumMsg";
import EnumFieldType from "../enums/EnumFieldType";
import IFieldSize from "./IFieldSize";

export interface IConfigField {
	name: string;
	label?: EnumMsg;
	fieldType: EnumFieldType;
	validate?: (value: any) => Promise<EnumMsg | void>;
	editorConfig?: object;
	divSize?: IFieldSize;
}
