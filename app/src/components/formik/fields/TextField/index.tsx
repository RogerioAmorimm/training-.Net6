import { FC } from "react";
import { useField } from "formik";
import IProps from "./interfaces/IProps";
import Input from "../../../Input";

const TextField: FC<IProps> = (props) => {
	const [inputProps, meta] = useField(props.name);

	return (
		<Input
			{...props}
			name={inputProps.name}
			value={inputProps.value?.toString() || ""}
			onChange={(value, e) => e && inputProps.onChange(e)}
			onBlur={(e) => e && inputProps.onBlur(e)}
			errors={meta.error?.length ? [meta.error] : []}
			nativeValidations={false}
		/>
	);
};

export default TextField;
