import styled from "styled-components";
import { getBorderRadiusTheme, getColorTheme } from "../../styles/useful";
import IProps from "./interfaces/IProps";

export const Container = styled.button<IProps>`
	text-align: center;
	font-weight: 500;
	text-transform: uppercase;
	box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.15);
	padding: 8px 35px;
	cursor: pointer;

	background-color: ${(props) => {
		if (props.variant === "outlined") return "transparent";
		else return props.color === "white" ? "#FFF" : getColorTheme(props.color, props.theme).main;
	}};

	color: ${(props) => {
		switch (props.variant) {
			case "contained":
				return props.color !== "white" ? "#FFF" : props.theme.palette.text.secondary;

			case "outlined":
				return props.color === "white" ? props.theme.palette.text.secondary : getColorTheme(props.color, props.theme).main;

			default:
				return props.color !== "white" ? "#FFF" : props.theme.palette.text.secondary;
		}
	}};

	border: ${(props) => {
		switch (props.variant) {
			case "contained":
				return "0px";

			case "outlined":
				return `1px solid ${props.color === "white" ? "#F5F5F5" : getColorTheme(props.color, props.theme).main}`;

			default:
				return "0px";
		}
	}};

	border-radius: ${(props) => getBorderRadiusTheme(props.rounded, props.theme)};

	:not(:disabled) {
		:hover {
			box-shadow: #00000033 0px 2px 4px -1px, #00000024 0px 4px 5px 0px, #0000001f 0px 1px 10px 0px;
		}

		:active {
			background-color: ${(props) => {
				if (props.variant === "outlined") return "rgba(25, 118, 210, .04)";
				else {
					return props.color === "white" ? "#F5F5F5" : getColorTheme(props.color, props.theme).dark;
				}
			}};
		}
	}

	:disabled {
		opacity: 0.4;
		cursor: default;
	}
`;
