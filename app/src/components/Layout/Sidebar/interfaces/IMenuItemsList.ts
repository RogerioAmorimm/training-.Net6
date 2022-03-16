import IMenuItem from "./IMenuItem";

export default interface IMenuItemsList {
	default: IMenuItem[];
	favorites: IMenuItem[];
	hidden: IMenuItem[];
}
