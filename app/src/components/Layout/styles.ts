import styled from "styled-components";
import IStyledContentContainerProps from "./interfaces/IStyledContainerLayoutProps";
import IStyledCurrentPageNameProps from "./interfaces/IStyledCurrentPageNameProps";

export const Container = styled.div`
	display: flex;
	flex-flow: column nowrap;
	width: 100%;
	height: 100vh;
	padding: 0;
	margin: 0;
	overflow: hidden;
	position: relative;
	::after {
		content: "";
		height: 180px;
		width: 100%;
		position: absolute;
		top: calc(30%);
		background-color: ${(props) => props.theme.palette.primary.main};
		z-index: -1;
	}
`;

export const CurrentPageName = styled.div<IStyledCurrentPageNameProps>`
	padding: 0px 20px 5px 40px;
	display: flex;
	justify-content: ${(props) => (props.reverse ? "flex-end" : "flex-start")};
	align-items: flex-end;
	font-weight: 600;

	> .pageNameSpan {
		margin-left: 10px;
	}
`;

export const ContentContainer = styled.div<IStyledContentContainerProps>`
	flex: 1;
	width: 100%;
	position: relative;
	display: flex;
	flex-flow: column nowrap;
	justify-content: flex-start;
	align-items: stretch;
	transition: padding 0.15s ease-in-out;
	padding-left: ${(props) => (props.menuPosition === "left" ? (props.menuIsOpen ? "230px" : "60px") : "")};
	padding-right: ${(props) => (props.menuPosition === "right" ? (props.menuIsOpen ? "230px" : "60px") : "")};
	z-index: 1;
	overflow: unset;

	@media (max-width: ${(props) => props.theme.breakpoints.md}) {
		padding-left: ${(props) => (props.menuPosition === "left" ? "60px" : "")};
		padding-right: ${(props) => (props.menuPosition === "right" ? "60px" : "")};
	}

	${CurrentPageName} {
		${(props) =>
			props.menuPosition === "left" || props.menuPosition === "right"
				? `
					@media (min-width: ${props.theme.breakpoints.md}) {
						margin-top: -30px;
					}
				`
				: "margin-top: 15px;"}
	}
`;

export const Main = styled.main`
	flex: 1;
	overflow: auto;
	padding: 2px 10px;
	> * {
		background-color: ${(props) => props.theme.palette.background.paper};
		border-radius: ${(props) => props.theme.borderRadius.medium};
		box-shadow: 1px 1px 4px rgba(0, 0, 0, 0.25);
		margin-bottom: 20px;
	}
	> *:nth-child(1) {
		min-height: calc(30% + 100px);
	}
`;
