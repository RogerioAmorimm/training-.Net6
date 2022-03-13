import styled from "styled-components";
import { HTMLProps } from "react";

export const Container = styled.div<HTMLProps<HTMLDivElement>>`
	display: flex;
	justify-content: center;
	align-items: center;
`;

export const FlagContainer = styled.div<HTMLProps<HTMLDivElement>>`
	padding: 0px 2.5px;
	display: inline-block;
`;

export const Flag = styled.div<HTMLProps<HTMLDivElement>>`
	position: relative;
	cursor: pointer;
	transition: all 0.2s ease-in-out;
	opacity: ${(props) => (props.disabled ? ".2" : "1")};
	:hover {
		opacity: 1;
	}
`;
