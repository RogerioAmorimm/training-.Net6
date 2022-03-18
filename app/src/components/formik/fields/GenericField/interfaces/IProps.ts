import EnumMsg from "../../../../../translate/enums/EnumMsg";
import EnumFieldType from "../../../Form/enums/EnumFieldType";

export default interface IProps {
	type: EnumFieldType;
	config: object;
	name: string;
	label?: EnumMsg;
}
