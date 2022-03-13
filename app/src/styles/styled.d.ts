import "styled-components";

interface IPalette {
	main: string;
	dark: string;
	light: string;
}

declare module "styled-components" {
	export interface DefaultTheme {
		title: string;
		borderRadius: {
			none: string;
			small: string;
			medium: string;
			large: string;
			circle: string;
		};
		palette: {
			background: {
				main: string;
				paper: string;
			};
			primary: IPalette;
			secondary: IPalette;
			black: IPalette;
			status: {
				success: IPalette;
				error: IPalette;
				alert: IPalette;
			};
			text: {
				primary: string;
				secondary: string;
			};
		};
		breakpoints: {
			xs: string;
			sm: string;
			md: string;
			lg: string;
			xl: string;
		};
	}
}
