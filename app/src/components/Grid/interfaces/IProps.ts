import { HTMLProps } from "react";

export type Size = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12;

export default interface IProps extends HTMLProps<HTMLDivElement> {
	direction?: "row" | "column";
	justify?: "flex-start" | "flex-end" | "space-between" | "space-around" | "space-evenly" | "center";
	align?: "flex-start" | "flex-end" | "normal" | "stretch" | "start" | "end" | "center";
	spacing?: number;
	item?: boolean;
	xs?: Size;
	sm?: Size;
	md?: Size;
	lg?: Size;
	xl?: Size;
	fullHeight?: boolean;
	paper?: boolean;
}
