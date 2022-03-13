import LangType from "../../../translate/types/LangTypes";

export default interface IProps {
	order?: LangType[];
	callback?: () => void;
}
