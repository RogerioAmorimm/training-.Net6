import { FC } from "react";
import IProps from "./interfaces/IProps";
import { Popup, Position, ToolbarItem } from "devextreme-react/popup";
import { useTranslate } from "../../contexts/TranslateContext";
import EnumMsg from "../../translate/enums/EnumMsg";

const Confirm: FC<IProps> = ({ message, open, ...actions }) => {
	const { translate } = useTranslate();

	return (
		<Popup
			visible={open}
			dragEnabled={false}
			closeOnOutsideClick={false}
			showCloseButton={false}
			showTitle={true}
			title={translate(EnumMsg.Confirmacao)}
			width="auto"
			height="auto"
		>
			<Position at="center" my="center" of="#root" />
			<ToolbarItem
				widget="dxButton"
				toolbar="bottom"
				location="after"
				options={{ text: translate(EnumMsg.Cancelar), onClick: () => actions.handleCancel() }}
			/>
			<ToolbarItem
				widget="dxButton"
				toolbar="bottom"
				location="after"
				options={{ text: translate(EnumMsg.Confirmar), onClick: () => actions.handleConfirm(), type: "success" }}
			/>
			<p>{translate(message)}</p>
		</Popup>
	);
};

export default Confirm;
