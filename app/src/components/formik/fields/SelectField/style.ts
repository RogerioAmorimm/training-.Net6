import styled from "styled-components"; 
import { getBorderRadiusTheme, getColorTheme } from "../../../../styles/useful";
import InputProps from "../../../Input/interfaces/IProps";

export const Container = styled.div<InputProps>`
	padding-top: 5px;

	.dx-texteditor {
		border-radius: ${(props) => getBorderRadiusTheme(props.rounded, props.theme)} !important;
		border: 1px solid !important;
		padding-left: 0px !important;
		padding-right: 0px !important;
		border-color: ${(props) => getColorTheme(props.errors && props.errors.length ? "error" : "black", props.theme).main} !important;
	}

	* {
		border: 0px !important;
	}

	.dx-textbox {
		background-color: transparent !important;
	}
	.dx-texteditor-container,
	.dx-texteditor-container * {
		border-color: transparent !important;
	}

	input {
		padding: 0px 15px !important;
		border-radius: ${(props) => getBorderRadiusTheme(props.rounded, props.theme)} !important;
	}
	input:-webkit-autofill,
	input:-webkit-autofill:hover,
	input:-webkit-autofill:focus,
	input:-webkit-autofill:active {
		box-shadow: 0 0 0 30px white inset !important;
		-webkit-box-shadow: 0 0 0 30px white inset !important;
	}

	.dx-state-focused .dx-texteditor-label,
	.dx-textbox:not(.dx-texteditor-empty) .dx-texteditor-label {
		color: ${(props) => props.theme.palette.text.secondary} !important;
		margin-top: -10px !important;
		.dx-label {
			background-color: ${(props) => props.theme.palette.background.paper} !important;
			padding-left: 5px;
			padding-right: 5px;
		}
	}

	.dx-texteditor-empty .dx-label {
		padding-left: 10px;
	}

	.dx-texteditor.dx-invalid {
		border-color: ${(props) => getColorTheme("error", props.theme).main} !important;
		.dx-texteditor-label {
			color: ${(props) => getColorTheme("error", props.theme).main} !important;
		}
	}

	.dx-invalid-message-content {
		background-color: ${(props) => getColorTheme("error", props.theme).main} !important;
		left: unset !important;
		right: 0 !important;
		transform: translate(0px, 36px) !important;
	}
`;
