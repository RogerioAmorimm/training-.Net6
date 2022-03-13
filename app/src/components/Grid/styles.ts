import styled from "styled-components";
import IProps from "./interfaces/IProps";

const getWidthPercent = (value: number) => ((100 / 12) * value).toFixed(4).toString().slice(0, -1).concat("%");

export const Container = styled.div<IProps>`
	${(props) => (props.fullHeight ? `height: 100%` : "")};

	display: ${(props) => (props.item ? "block" : "flex")};
	justify-content: ${(props) => props.justify || "flex-start"};
	align-items: ${(props) => props.align || "flex-start"};
	flex-flow: ${(props) => props.direction || "row"} wrap;
	${(props) => (props.paper ? `background-color: ${props.theme.palette.background.paper}` : "")};

	> .grid-item {
		${(props) => (props.spacing ? `padding: ${props.spacing * 2.5}px` : "")};
	}

	@media (min-width: ${(props) => props.theme.breakpoints.xs}) {
		${(props) => (props.xs ? `width: ${getWidthPercent(props.xs)};` : ``)}
	}

	@media (min-width: ${(props) => props.theme.breakpoints.sm}) {
		${(props) => (props.sm ? `width: ${getWidthPercent(props.sm)};` : ``)}
	}

	@media (min-width: ${(props) => props.theme.breakpoints.md}) {
		${(props) => (props.md ? `width: ${getWidthPercent(props.md)};` : ``)}
	}

	@media (min-width: ${(props) => props.theme.breakpoints.lg}) {
		${(props) => (props.lg ? `width: ${getWidthPercent(props.lg)};` : ``)}
	}

	@media (min-width: ${(props) => props.theme.breakpoints.xl}) {
		${(props) => (props.xl ? `width: ${getWidthPercent(props.xl)};` : ``)}
	}
`;
