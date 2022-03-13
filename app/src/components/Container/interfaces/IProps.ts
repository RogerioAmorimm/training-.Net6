import { HTMLProps } from "react";

export default interface IProps extends HTMLProps<HTMLDivElement> {
	noPadding?: boolean;
	maxWidth?: "sm" | "md" | "lg" | "xl";
	fullHeight?: boolean;
	paper?: boolean;
	selfCenter?: boolean;
}
