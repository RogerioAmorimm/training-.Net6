import styled, { css } from "styled-components";
import ISidebarItemStyledProps from "./interfaces/ISidebarItemStyledProps";
import IStyledSubItemsContainerProps from "./interfaces/IStyledSubItemsContainerProps";

export const Container = styled.li`
	list-style: none;
	display: flex;
	flex-flow: column nowrap;
	margin: 0;
	padding: 0;
`;

export const SidebarItemIconContainer = styled.div.attrs({ className: "icon-container" })`
	padding: 5px;
	border-radius: ${(props) => props.theme.borderRadius.medium};
	display: flex;
	justify-content: center;
	align-items: center;

	svg {
		color: ${(props) => props.theme.palette.text.primary};
	}
`;

export const SidebarItemText = styled.span`
	color: ${(props) => props.theme.palette.text.primary};
	white-space: nowrap;
	margin-left: 10px;
	overflow: hidden;
`;

export const SubItemsContainer = styled.div<IStyledSubItemsContainerProps>`
	max-height: ${(props) => (props.show ? "1000px" : "0px")};
	transition: max-height 0.3s ease-in-out;
	overflow: hidden;
	${(props) => (props.show ? "height: auto;" : "")}
`;

export const OptionsBtn = styled.div`
	font-size: 18px;
	color: ${(props) => props.theme.palette.text.secondary};
`;

const LeftOrRightSidebarItemStyle = css<ISidebarItemStyledProps>`
	position: relative;
	cursor: pointer;
	display: flex;
	flex-flow: row nowrap;
	justify-content: flex-start;
	align-items: center;
	padding-top: ${(props) => (props.isSubItem ? "10px" : "5px")};
	padding-bottom: ${(props) => (props.isSubItem ? "10px" : "5px")};
	padding-left: 15px;
	padding-right: ${(props) => (props.sideBarPosition === "right" ? "15px" : "5px")};
	border-radius: ${(props) => (props.isSubItem ? "0px" : props.theme.borderRadius.medium)};
	transition: 0.2s;

	${OptionsBtn} {
		position: absolute;
		right: ${(props) => (props.containsSubItem ? "25px" : "15px")};
		top: 5px;
		display: none;
	}

	:hover {
		background-color: #f5f5f5;

		@media (min-width: ${(props) => props.theme.breakpoints.md}) {
			${OptionsBtn} {
				display: block;
			}
		}
	}
	:active {
		background-color: #e9e9e9;
	}

	::before {
		content: "";
		display: ${(props) => (props.active ? "block" : "none")};
		position: absolute;
		width: 15px;
		border-radius: 7.5px;
		height: 30px;
		background-color: ${(props) => props.theme.palette.primary.main};
		${(props) => (props.sideBarPosition === "left" ? "left: -7.5px" : "right: -7.5px")}
	}

	${(props) =>
		props.containsSubItem
			? `
				::after {
					content: "";
					display: ${!props.sideBarCompactMode ? "block" : "none"};
					position: absolute;
					right: 15px;
					top: calc(50% - 2.5px);
					height: 5px;
					width: 5px;
					padding: 0px;
					margin: 0px;
					border-top: 2px solid ${props.theme.palette.text.secondary};
					border-right: 2px solid ${props.theme.palette.text.secondary};
					transform: ${props.showingSubItems ? "rotate(135deg)" : "rotate(45deg)"};
					transition: transform 0.3s;
				}
			`
			: ""}

	.icon-container {
		${(props) =>
			props.active &&
			`
		box-shadow: 0px 4px 4px rgb(0 0 0 / 15%);
		background-color: ${props.theme.palette.background.main}
	`}
	}
`;

const TopOrBottomSidebarItemStyle = css<ISidebarItemStyledProps>`
	position: relative;
	cursor: pointer;
	display: flex;
	flex-flow: row nowrap;
	justify-content: center;
	align-items: center;
	padding-top: 10px;
	padding-bottom: 10px;
	padding-left: ${(props) => (props.isSubItem ? "5px" : "5px")};
	padding-right: ${(props) => (props.isSubItem ? "5px" : "5px")};
	margin: 0 2.5px;
	border-radius: ${(props) => (props.isSubItem ? "0px" : props.theme.borderRadius.medium)};
	transition: 0.2s;

	${SidebarItemText} {
		${(props) => !props.isSubItem && "display: none;"}
		margin: 0px;
		padding-left: 0px;
	}

	${OptionsBtn} {
		width: 0;
		overflow: hidden;
		transition: width 0.2s;
	}

	:hover {
		background-color: #f5f5f5;

		@media (min-width: ${(props) => props.theme.breakpoints.md}) {
			${OptionsBtn} {
				width: 15px;
			}
		}
	}
	:active {
		background-color: #e9e9e9;
	}

	::before {
		content: "";
		display: ${(props) => (props.active ? "block" : "none")};
		position: absolute;
		background-color: ${(props) => props.theme.palette.primary.main};
		height: 10px;
		top: -10px;
		left: 0;
		right: 0;
		border-radius: 5px;
	}

	.icon-container {
		${(props) =>
			props.active &&
			`
		box-shadow: 0px 4px 4px rgb(0 0 0 / 15%);
		background-color: ${props.theme.palette.background.main}
	`}
	}
`;

export const SidebarItem = styled.div<ISidebarItemStyledProps>`
	${(props) => (props.sideBarPosition === "left" || props.sideBarPosition === "right" ? LeftOrRightSidebarItemStyle : TopOrBottomSidebarItemStyle)}
`;
