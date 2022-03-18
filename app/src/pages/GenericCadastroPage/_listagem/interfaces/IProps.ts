import IBaseCadastroPageService from "../../../../services/interfaces/IBaseCadastroPageServiceModule";

export default interface IProps<T> {
	onEdit: (idEdit: number) => void;
	service: IBaseCadastroPageService<T>;
}
