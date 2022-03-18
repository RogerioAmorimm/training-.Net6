import EnumMsg from "../../../translate/enums/EnumMsg";

export default interface IProps {
	message: EnumMsg;
	open: boolean;
	handleCancel: () => void;
	handleConfirm: () => void;
}
