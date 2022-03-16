import styled from "styled-components";
import IStyledNavProps from "./interfaces/IStyledNavProps";

export const Container = styled.div<IStyledNavProps>`
	height: 55px;
	display: flex;
	flex-direction: ${(props) => (props.reverse ? "row-reverse" : "row")};
	justify-content: flex-end;
	align-items: baseline;
	padding: 10px 20px;
	margin-bottom: 5px;
	> * {
		margin: 0px 5px;
	}
	padding-left: ${(props) => (props.menuPosition === "left" ? (props.menuIsOpen ? "240px" : "70px") : "10px")};
	padding-right: ${(props) => (props.menuPosition === "right" ? (props.menuIsOpen ? "240px" : "70px") : "10px")};
	z-index: 4;

	transition: padding 0.2s ease-in-out;

	@media (max-width: ${(props) => props.theme.breakpoints.md}) {
		padding-left: ${(props) => (props.menuPosition === "left" ? "70px" : "10px")};
		padding-right: ${(props) => (props.menuPosition === "right" ? "70px" : "10px")};
	}
`;

export const LangContainer = styled.div`
	opacity: 0.4;
	cursor: pointer;
	display: flex;
	align-items: center;
	transition: all 0.2s ease-in-out;

	:hover {
		opacity: 1;
	}
`;

export const Separator = styled.div`
	flex: 1;
`;
