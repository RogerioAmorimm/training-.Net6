import { FC } from "react";
import IProps from "./interfaces/IProps";
import EnumFieldType from "../../Form/enums/EnumFieldType";
import TextField from "../TextField";
import CheckField from "../CheckField";

const GenericField: FC<IProps> = ({ type, config, name, label }) => {
	switch (type) {
		case EnumFieldType.text:
			return <TextField {...(config || {})} name={name} label={label} />;

		case EnumFieldType.email:
			return <TextField {...(config || {})} name={name} label={label} mode="email" />;

		case EnumFieldType.password:
			return <TextField {...(config || {})} name={name} label={label} mode="password" />;

		case EnumFieldType.phone:
			return <TextField {...(config || {})} name={name} label={label} mode="tel" />;

		case EnumFieldType.boolean:
			return <CheckField {...(config || {})} name={name} label={label} />;

		default:
			return <TextField {...(config || {})} name={name} label={label} />;
	}
};

export default GenericField;
