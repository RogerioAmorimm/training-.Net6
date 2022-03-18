import { FC } from "react";
import { useField, useFormikContext } from "formik";
import IProps from "./interfaces/IProps";
import CheckBox from "../../../CheckBox";

const CheckField: FC<IProps> = (props) => {
	const [inputProps, meta] = useField(props.name);
	const { setFieldValue } = useFormikContext();

	return (
		<CheckBox
			{...props}
			name={inputProps.name}
			value={inputProps.value}
			onValueChange={(value) => setFieldValue(inputProps.name, value)}
			errors={meta.error?.length && meta.touched ? [meta.error] : []}
		/>
	);
};

export default CheckField;
