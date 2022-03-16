import { ComponentProps, FC } from "react";
import IProps from "./interfaces/IProps";
import * as S from './styles';

const IconButton: FC<IProps> = ({ icon: Icon, ...btnProps }) => {
    const styledProps = btnProps as ComponentProps<typeof S.Container>;
    return (
        <S.Container {...styledProps}>
            <Icon size="20px" />
        </S.Container>
    );
}

export default IconButton;