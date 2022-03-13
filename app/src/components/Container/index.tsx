import { FC, ComponentProps } from "react";
import * as S from "./styles";
import IProps from "./interfaces/IProps";

const Container: FC<IProps> = ({ children, ...props }) => {
	const styledProps = props as ComponentProps<typeof S.Container>;

	return <S.Container {...styledProps}>{children}</S.Container>;
};

export default Container;
