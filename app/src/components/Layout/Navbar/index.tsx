import { FC, useState } from "react";
import * as S from "./styles";
import IProps from "./interfaces/IProps";
import { MdNotifications, MdPersonOutline } from "react-icons/md";
import ChangeLanguage from "../../ChangeLanguage";
import { useTranslate } from "../../../contexts/TranslateContext";
import IconButton from "../../IconButton";
import { useMenu } from "../../../contexts/MenuContext";
import Logo from "../../Logo";
import { Popover } from "devextreme-react";
import USAIcon from "../../ChangeLanguage/svg/USAIcon";
import SpainIcon from "../../ChangeLanguage/svg/SpainIcon";
import BrazilIcon from "../../ChangeLanguage/svg/BrazilIcon";

const Navbar: FC<IProps> = (props) => {
	const [changingLang, setChangingLang] = useState(false);

	const {
		state: { lang },
	} = useTranslate();

	const {
		state: { open: menuIsOpen, position: menuPosition },
	} = useMenu();

	return (
		<>
			<S.Container reverse={menuPosition === "right"} menuIsOpen={menuIsOpen} menuPosition={menuPosition}>
				{(menuPosition === "top" || menuPosition === "bottom") && <Logo />}
				<S.Separator />
				<S.LangContainer onClick={() => setChangingLang((v) => !v)} id="langNavBtnChanger">
					{lang === "enUS" && <USAIcon height="20" />}
					{lang === "es" && <SpainIcon height="20" />}
					{lang === "ptBR" && <BrazilIcon height="20" />}
				</S.LangContainer>
				<IconButton color="white" icon={MdNotifications} />
				<IconButton color="white" icon={MdPersonOutline} />
			</S.Container>

			<Popover
				target="#langNavBtnChanger"
				visible={changingLang}
				position="bottom"
				showEvent="dxclick"
				closeOnOutsideClick
				onHiding={() => setChangingLang(false)}
			>
				<ChangeLanguage callback={() => setChangingLang(false)} />
			</Popover>
		</>
	);
};

export default Navbar;
