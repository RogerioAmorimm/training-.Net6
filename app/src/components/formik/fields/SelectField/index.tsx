import { FC } from "react";
import IProps from "./interfaces/IProps";
import { SelectBox } from "devextreme-react";
import * as  S from './style';

import { useField, useFormikContext } from "formik";
const SelectField: FC<IProps> = (props) => {
	const [inputProps, meta] = useField(props.name);
	const { setFieldValue } = useFormikContext();
	return (
		<S.Container rounded={props.rounded} errors={props.errors} required={props.required} >
			<SelectBox
				value={inputProps.value?.toString() || ""}
				dataSource={(props.data ?? [])}
				name={inputProps.name}
				onValueChange={(value) => {
					setFieldValue(inputProps.name, value)
				}}
				onItemClick={(e) => {
					setFieldValue(inputProps.name, e.itemData)
				}}
			/>
		</S.Container>
	);
};

export default SelectField;
