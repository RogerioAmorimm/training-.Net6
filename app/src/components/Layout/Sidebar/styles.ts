import styled, { css } from "styled-components";
import EnumMsg from "../../../translate/enums/EnumMsg";
import IconButton from "../../IconButton";
import Input from "../../Input";
import { LogoDesc } from "../../Logo/style";
import IStyledFixBtnProps from "./interfaces/IStyledFixBtnProps";
import IStyledSideProps from "./interfaces/IStyledSideProps";
import { SidebarItem, SidebarItemText, SubItemsContainer } from "./SidebarItem/styles";

export const FixBtn = styled.div<IStyledFixBtnProps>`
	position: absolute;
	height: 40px;
	width: 40px;
	display: flex;
	align-items: center;
	justify-content: center;
	top: calc(50% - 20px);
	cursor: pointer;

	@media (max-width: ${(props) => props.theme.breakpoints.md}) {
		display: none;
	}

	${(props) => (props.menuPosition === "right" ? "left: 0;" : "right: 0;")}
	${(props) => (!props.fixed ? "transform: rotate(45deg);" : "")}

	svg {
		color: ${(props) => props.theme.palette.text.secondary};
	}
`;



export const SearchContainer = styled.div`
	position: relative;
	display: flex;
	flex-flow: column nowrap;
	justify-content: center;
	align-items: stretch;
	padding: 0px 10px;
	margin: 0;
	transform: scaleY(0.85);
	transition: opacity 0.4s ease-in-out;
`;

export const SearchField = styled(Input).attrs({ rounded: "lg", label: EnumMsg.Pesquisar })``;

export const SearchIconContainer = styled.div`
	position: absolute;
	right: 10px;
	top: 0;
	height: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
	padding-right: 8px;

	svg {
		color: ${(props) => props.theme.palette.text.secondary};
	}
`;

export const ItemsContainer = styled.ul`
	flex: 1;
	padding: 0px;
	display: flex;
`;

export const Divider = styled.li`
	list-style: none;
`;

export const FooterActionsContainer = styled.div`
	display: flex;
	flex-flow: row nowrap;
	justify-content: space-evenly;
	align-items: center;
	overflow: hidden;
	transition: width 1.5s ease-in-out;
	padding: 5px 10px 5px;
	> *:last-child {
		margin-right: 0px;
	}
	> *:first-child {
		margin-left: 0px;
	}
`;

export const ConfigActionButton = styled(IconButton).attrs({ color: "white" })`
	margin: 0 5px;
`;

const LeftOrRightContainerStyle = css<IStyledSideProps>`
	position: fixed;
	z-index: 5;
	height: 100%;
	min-height: 100vh;
	width: 230px;
	background-color: ${(props) => props.theme.palette.background.paper};
	box-shadow: 2px 4px 4px 1px rgba(0, 0, 0, 0.25);
	box-shadow: ${(props) => (props.position === "left" ? "4px 0px 4px 0px rgba(0, 0, 0, 0.25)" : "-4px 0px 4px 0px rgba(0, 0, 0, 0.25)")};
	overflow: hidden;
	padding: 15px 0px 10px;
	display: flex;
	flex-flow: column nowrap;
	justify-content: flex-start;
	align-items: stretch;
	transition: width 0.15s ease-in-out;

	${(props) => (props.position === "right" ? "right: 0px" : "")};

	:hover {
		${SidebarItem} {
			::after {
				display: block;
			}
		}
	}

	:not(:hover) {
		${(props) =>
			!props.isOpen
				? `
				width: 60px;
				${LogoDesc} { display: none; }
				${FixBtn} { display: none; }
				${SearchContainer} { opacity: 0; }
				${SidebarItemText} { opacity: 0; }
				${SidebarItem} { ::after { display: none; } }
				${SubItemsContainer} { max-height: 0px; height: unset; }
				${FooterActionsContainer} { width: 0px; padding: 0px; }
			`
				: ""}
	}

	${SearchContainer} {
		margin-bottom: 15px;
	}


	${ItemsContainer} {
		justify-content: flex-start;
		overflow-x: hidden;
		overflow-y: auto;
		flex-flow: column nowrap;
		align-items: stretch;
	}

	${Divider} {
		background: linear-gradient(90.05deg, rgba(196, 196, 196, 0) -0.86%, #c4c4c4 102.45%);
		height: 2.7px;
		transform: rotate(180deg);
		margin: 7.5px 0;
	}
`;

const TopOrBottomContainerStyle = css<IStyledSideProps>`
	height: auto;
	width: 100%;
	min-width: 100vw;
	background-color: ${(props) => props.theme.palette.background.paper};
	box-shadow: ${(props) => (props.position === "top" ? "0px 4px 4px 0px rgba(0, 0, 0, 0.25)" : "0px -4px 4px 0px rgba(0, 0, 0, 0.25)")};
	overflow: hidden;
	padding: 2px 10px;
	display: flex;
	flex-flow: row nowrap;
	justify-content: flex-start;
	align-items: center;

	@media (min-width: ${(props) => props.theme.breakpoints.md}) {
		padding-left: 20px;
	}

	${SearchContainer} {
		width: 280px;
		margin-right: 15px;

		@media (max-width: ${(props) => props.theme.breakpoints.sm}) {
			display: none;
			/* display: flex; */
			justify-content: center;
			width: unset;
			margin-right: 0;
			margin-bottom: 15px;
		}
	}

	${ItemsContainer} {
		justify-content: flex-start;
		overflow-x: auto;
		overflow-y: hidden;
		flex-flow: row nowrap;
		align-items: center;
		margin-right: 15px;
		height: 100%;
		padding-bottom: 7.5px;
		padding-top: 7.5px;

		@media (max-width: ${(props) => props.theme.breakpoints.sm}) {
			margin-left: 15px;
		}
	}

	${Divider} {
		background: linear-gradient(0deg, rgba(196, 196, 196, 0) -0.86%, #c4c4c4 102.45%);
		padding: 0 1.25px;
		height: 100%;
		margin: 0 20px;

		@media (max-width: ${(props) => props.theme.breakpoints.sm}) {
			margin: 0 10px;
		}
	}
`;

export const Container = styled.nav<IStyledSideProps>`
	${(props) => (props.position === "right" || props.position === "left" ? LeftOrRightContainerStyle : TopOrBottomContainerStyle)}
`;

