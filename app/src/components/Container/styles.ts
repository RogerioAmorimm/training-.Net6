import styled from "styled-components";
import IProps from "./interfaces/IProps";

export const Container = styled.div<IProps>`
	${(props) => (props.selfCenter ? "margin: 0 auto" : "")};
	width: 100%;
	display: block;
	padding: ${(props) => (props.noPadding ? "0px" : "25px")};
	${(props) => (props.maxWidth ? `max-width: ${props.theme.breakpoints[props.maxWidth]}` : "")};
	${(props) => (props.fullHeight ? `height: 100%` : "")};
	${(props) => (props.paper ? `background-color: ${props.theme.palette.background.paper}` : "")};
`;
