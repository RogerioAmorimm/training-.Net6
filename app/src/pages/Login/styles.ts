import styled from "styled-components";
import Image from "../../assets/img/login_page.jpg";
import Grid from "../../components/Grid";

export const GridContainer = styled(Grid)`
	height: 100vh;
	min-height: 480px;
`;

export const LeftPanel = styled(Grid)`
	height: 100%;
	padding: 60px 10px;
	@media (min-width: ${(props) => props.theme.breakpoints.md}) {
		padding-left: 60px;
	}
	@media (min-height: 700px) {
		padding-top: 100px;
		padding-bottom: 100px;
	} ;
`;

export const LeftPanelHeader = styled(Grid).attrs((props) => ({ item: true }))`
	flex: 2;
`;

export const LeftPanelMain = styled(Grid).attrs((props) => ({ item: true }))`
	flex: 3;
`;

export const LeftPanelFooter = styled(Grid).attrs((props) => ({ item: true }))`
	flex: 2;
`;

export const RightPanel = styled.div`
	height: 100%;
	background: url("${Image}");
	background-size: cover;
`;

export const RightPanelShadow = styled.div`
	position: "absolute";
	top: 0;
	left: 0;
	display: flex;
	align-items: center;
	justify-content: center;
	background-color: rgba(0, 0, 0, 0.8);
	height: 100%;
	padding: 50px;
	padding-bottom: 156px;
`;

export const RightPanelText = styled.p`
	color: #fff;
	font-size: 16px;
	max-width: 330px;
`;

export const IconContainer = styled.div`
	display: flex;
	justify-content: center;
	align-items: center;
	text-align: center;
	padding: 10px;
	border-radius: ${(props) => props.theme.borderRadius.medium};
	background-color: ${(props) => props.theme.palette.primary.main};
`;

export const Form = styled.form`
	height: 100%;
`;
