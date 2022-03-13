import { ComponentProps, FC } from "react";
import * as S from "./styles";
import IProps from "./interfaces/IProps";

const Grid: FC<IProps> = ({ children, ...props }) => {
    const styledProps = props as ComponentProps<typeof S.Container>;

    return (
        <S.Container {...styledProps} className={`${props.className} ${props.item ? "grid-item" : "grid-container"}`}>
            {children}
        </S.Container>
    );
};

export default Grid;
