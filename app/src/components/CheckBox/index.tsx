import { FC } from "react";
import IProps from "./interfaces/IProps";
import * as S from "./style";
import { CheckBox as DevCheck, Validator } from "devextreme-react";
import { CustomRule } from "devextreme-react/data-grid";
import { useTranslate } from "../../contexts/TranslateContext";

const CheckBox: FC<IProps> = ({ errors, label, ...props }) => {
	const { translate } = useTranslate();

	return (
		<S.Container>
			<DevCheck {...props} text={label ? translate(label) : ""}>
				<Validator>
					{errors?.length
						? errors
								.reduce<string[]>((arr, curr) => (arr.indexOf(curr) >= 0 ? arr : [...arr, curr]), [])
								.map((err) => <CustomRule key={err} message={err} validationCallback={() => false} />)
						: null}
				</Validator>
			</DevCheck>
		</S.Container>
	);
};

export default CheckBox;
