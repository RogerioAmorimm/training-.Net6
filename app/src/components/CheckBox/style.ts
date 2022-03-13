import styled from "styled-components";
import IProps from "./interfaces/IProps";

export const Container = styled.div<IProps>`
	.dx-checkbox-icon {
		border-color: ${(props) => props.theme.palette.black.main} !important;
		border-radius: 6px !important;
	}
`;
