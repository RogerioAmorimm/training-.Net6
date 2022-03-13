import MenuPositionType from "../types/MenuPositionType";

export default interface IState {
	open: boolean;
	position: MenuPositionType;
	favorites: string[];
	hidden: string[];
}
