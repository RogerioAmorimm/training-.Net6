import { HTMLProps } from "react";
import { BorderRadius, Colors } from "../../../styles/types";

export default interface IProps extends HTMLProps<HTMLButtonElement> {
	color?: Colors | "white";
	variant?: "outlined" | "contained";
	rounded?: BorderRadius;
}
