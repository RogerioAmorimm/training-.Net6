import { FC } from "react";
import Grid from "../Grid";
import IProps from "./interfaces/IProps";
import * as S from './style';
import { MdComputer } from "react-icons/md";

const Logo: FC<IProps> = ({ children }) =>
(
    <S.LogoContainer>
        <Grid item>
            <S.LogoIconContainer>
                <MdComputer size="20px" color="#FFF" />
            </S.LogoIconContainer>
        </Grid>
        <Grid item>
            <S.LogoDesc> App Request</S.LogoDesc>
        </Grid>
        {children}
    </S.LogoContainer>
);

export default Logo;