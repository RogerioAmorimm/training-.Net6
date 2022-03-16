import styled from "styled-components";
import Grid from "../Grid";

export const LogoContainer = styled(Grid).attrs({
    spacing: 1,
    align: "center",
    justify: "center",
})`
    margin-left: 0px !important;
	margin-right: 0px !important;
	padding: 0px 10px;
	margin-bottom: 25px;
	flex-wrap: nowrap;
	position: relative;
`;


export const LogoIconContainer = styled.div`
	display: flex;
	justify-content: center;
	align-items: center;
	text-align: center;
	padding: 7.5px;
	border-radius: ${(x) => x.theme.borderRadius.medium};
	background-color: ${(x) => x.theme.palette.primary.main};
`;

export const LogoDesc = styled.h1`
	font-size: 18px !important;
	font-weight: 600 !important;
	color: ${(x) => x.theme.palette.text.primary} !important;
	margin: 0;
	padding: 0;
	white-space: nowrap;
`;