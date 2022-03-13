import { createContext, FC, useContext, useEffect, useReducer } from "react";
import LangType from "../../translate/types/LangTypes";
import IState from "./Intefaces/IState";
import reducer from "./reducer";
import EnumMsg from "../../translate/enums/EnumMsg";
import Messages from "../../translate/Message";
import IValue from "./Intefaces/IValue";

const langStorageKey: string = "lang";
const storageLang = localStorage.getItem(langStorageKey) as LangType | null;
const navigatorLang = window.navigator.language?.replace("-", "") as LangType | null;

const TranslateContext = createContext({} as IValue);

const initialState: IState = { lang: storageLang || navigatorLang || "ptBR" };

export const TranslateProvider: FC = ({ children }) => {
	const [state, dispatch] = useReducer(reducer, initialState);

	useEffect(() => {
		localStorage.setItem(langStorageKey, state.lang);
	}, [state.lang]);

	const translate = (key: EnumMsg): string => {
		const { lang } = state;

		let msg = Messages[key];
		if (!msg) return "MENSAGEM NÃO CADASTRADA";

		let translateValue = msg[lang];
		if (!translateValue) return "MENSAGEM NÃO TRADUZIDA";

		return translateValue;
	};

	return <TranslateContext.Provider value={{ state, dispatch, translate }}>{children}</TranslateContext.Provider>;
};

export const useTranslate = (): IValue => {
	const value = useContext(TranslateContext);
	return value;
};
