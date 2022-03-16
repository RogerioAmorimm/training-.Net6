import MenuPositionType from "../../../../../contexts/MenuContext/types/MenuPositionType";

export default interface ISidebarItemStyledProps {
	active?: boolean;
	isSubItem?: boolean;
	containsSubItem?: boolean;
	showingSubItems?: boolean;
	sideBarCompactMode?: boolean;
	sideBarPosition: MenuPositionType;
}
