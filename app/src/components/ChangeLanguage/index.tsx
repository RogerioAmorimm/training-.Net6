import { FC } from "react";
import IProps from "./interfaces/IProps";
import * as S from "./style";
import { useTranslate } from "../../contexts/TranslateContext";
import LangType from "../../translate/types/LangTypes";
import BrazilIcon from "./svg/BrazilIcon";
import USAIcon from "./svg/USAIcon";
import SpainIcon from "./svg/SpainIcon";

const ChangeLanguage: FC<IProps> = ({ callback, order = ["ptBR", "enUS", "es"] }) => {
	const {
		state: { lang },
		dispatch: translateDispatch,
	} = useTranslate();

	const handleChangeLang = (newLang: LangType): void => {
		translateDispatch({
			type: "SET_LANG",
			payload: newLang,
		});
		callback && callback();
	};

	order = order.reduce((arr, value) => (arr.indexOf(value) === -1 ? [...arr, value] : arr), [] as LangType[]);
	if (!order || order.length < 3) {
		if (order.indexOf("ptBR") === -1) order.push("ptBR");
		if (order.indexOf("enUS") === -1) order.push("enUS");
		if (order.indexOf("es") === -1) order.push("es");
	} else if (order.length > 3) {
		order.splice(3);
	}

	const ptBRFlag = (
		<S.FlagContainer key="ptBR">
			<S.Flag disabled={lang !== "ptBR"} onClick={() => handleChangeLang("ptBR")}>
				<BrazilIcon height="20" />
			</S.Flag>
		</S.FlagContainer>
	);

	const enUSFlag = (
		<S.FlagContainer key="enUS">
			<S.Flag disabled={lang !== "enUS"} onClick={() => handleChangeLang("enUS")}>
				<USAIcon height="20" />
			</S.Flag>
		</S.FlagContainer>
	);

	const esFlag = (
		<S.FlagContainer key="es">
			<S.Flag disabled={lang !== "es"} onClick={() => handleChangeLang("es")}>
				<SpainIcon height="20" />
			</S.Flag>
		</S.FlagContainer>
	);

	return (
		<S.Container>
			{order.map((lang) => {
				if (lang === "ptBR") return ptBRFlag;
				if (lang === "enUS") return enUSFlag;
				if (lang === "es") return esFlag;
				return "";
			})}
		</S.Container>
	);
};

export default ChangeLanguage;
