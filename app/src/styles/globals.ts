import { createGlobalStyle } from "styled-components";

export default createGlobalStyle`
	* {
		margin: 0;
		padding: 0;
		box-sizing: border-box;
		font-family: "Helvetica Neue","Segoe UI",helvetica,verdana,sans-serif;
	}

	body {
		background-color: ${(props) => props.theme.palette.background.main} !important;
		font-size: 14px !important;
		color: ${(props) => props.theme.palette.text.primary} !important;
	}

	a {
		text-decoration: none;
		color: ${(props) => props.theme.palette.text.primary} !important;
		cursor: pointer;
	}

	#root {
		height: 100vh;
	}

	::-webkit-scrollbar {
		width: 5px;
		height: 5px;
	}
	::-webkit-scrollbar-button {
		width: 0px;
		height: 0px;
	}
	::-webkit-scrollbar-thumb {
		background: #a1a1a1;
		border: 0px none #f5f5f5;
		border-radius: 50px;
	}
	::-webkit-scrollbar-thumb:hover {
		background: #bababa;
	}
	::-webkit-scrollbar-thumb:active {
		background: #8f8f8f;
	}
	::-webkit-scrollbar-track {
		background: #f5f5f5;
		border: 0px none #f5f5f5;
		border-radius: 50px;
	}
	::-webkit-scrollbar-track:hover {
		background: #f5f5f5;
	}
	::-webkit-scrollbar-track:active {
		background: #fffafa;
	}
	::-webkit-scrollbar-corner {
		background: transparent;
	}
`;
