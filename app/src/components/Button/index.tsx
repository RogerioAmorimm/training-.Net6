import { ComponentProps, FC } from "react";
import IProps from "./interfaces/IProps";
import * as S from "./styles";

const Button: FC<IProps> = ({ children, ...props }) => {
	const styledProps = props as ComponentProps<typeof S.Container>;

	return <S.Container {...styledProps}>{children}</S.Container>;
};

export default Button;
