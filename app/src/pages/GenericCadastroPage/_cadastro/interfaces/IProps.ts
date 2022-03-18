import { IConfigField } from "../../../../components/formik/Form/interfaces/IConfigField";
import IBaseCadastroPageService from "../../../../services/interfaces/IBaseCadastroPageServiceModule";

export default interface IProps<T> {
	idEdit?: number;
	onAdded?: () => void;
	onUpdated?: () => void;
	service: IBaseCadastroPageService<T>;
	formConfig: IConfigField[];
}
