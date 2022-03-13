import { DefaultTheme } from "styled-components";

const LightTheme: DefaultTheme = {
	title: "light",
	borderRadius: {
		none: "0px",
		small: "2px",
		medium: "8px",
		large: "50px",
		circle: "50%",
	},
	palette: {
		background: {
			main: "#F4F4F4",
			paper: "#FFF",
		},
		primary: { main: "#0065AD", dark: "#4D93C6", light: "#FF6062" },
		secondary: { main: "#1D98D1", dark: "#003783", light: "#81C9FC" },
		black: { main: "#202020", dark: "#000", light: "#585858" },
		status: {
			error: { main: "#FE5052", dark: "#CE2022", light: "#FF8082" },
			success: { main: "#309E3A", dark: "#107a1A", light: "#709f3d" },
			alert: { main: "#FFF3CD", dark: "#f2dcad", light: "#fffbf4" },
		},
		text: {
			primary: "#1D1D1D",
			secondary: "#585858",
		},
	},
	breakpoints: {
		xs: "0px",
		sm: "600px",
		md: "960px",
		lg: "1280px",
		xl: "1920px",
	},
};

export default LightTheme;
