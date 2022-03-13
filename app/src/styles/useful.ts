import { DefaultTheme } from "styled-components";
import { IPalette } from "./styled";
import { Colors, BorderRadius } from "./types";

export const getColorTheme = (name: Colors | undefined, theme: DefaultTheme): IPalette => {
	switch (name) {
		case "primary":
			return theme.palette.primary;

		case "secondary":
			return theme.palette.secondary;

		case "success":
			return theme.palette.status.success;

		case "error":
			return theme.palette.status.error;

		case "alert":
			return theme.palette.status.alert;

		case "black":
			return theme.palette.black;

		default:
			return theme.palette.primary;
	}
};

export const getBorderRadiusTheme = (name: BorderRadius | undefined, theme: DefaultTheme): string => {
	switch (name) {
		case "sm":
			return theme.borderRadius.small;

		case "md":
			return theme.borderRadius.medium;

		case "lg":
			return theme.borderRadius.large;

		case "none":
			return theme.borderRadius.none;

		case "circle":
			return theme.borderRadius.circle;

		default:
			return theme.borderRadius.medium;
	}
};
