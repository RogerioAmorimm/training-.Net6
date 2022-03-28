import { IConfigField } from "../../../components/formik/Form/interfaces/IConfigField";
import IBaseCadastroPageService from "../../../services/interfaces/IBaseCadastroPageServiceModule";

export default interface IProps<T> {
	service: IBaseCadastroPageService<T>;
	formConfig: IConfigField[];
}
