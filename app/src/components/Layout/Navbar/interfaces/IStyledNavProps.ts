import MenuPositionType from "../../../../contexts/MenuContext/types/MenuPositionType";

export default interface IStyledNavProps {
	reverse: boolean;
	menuPosition: MenuPositionType;
	menuIsOpen: boolean;
}
