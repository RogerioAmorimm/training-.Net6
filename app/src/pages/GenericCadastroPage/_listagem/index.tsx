import { useCallback, useEffect, useState } from "react";
import IProps from "./interfaces/IProps";
import DataGrid, { Scrolling, LoadPanel, Column, SearchPanel } from "devextreme-react/data-grid";
import { useAuth } from "../../../contexts/AuthContext";
import notify from "devextreme/ui/notify";
import { useTranslate } from "../../../contexts/TranslateContext";
import EnumMsg from "../../../translate/enums/EnumMsg";
import IconButton from "../../../components/IconButton";
import { MdDelete, MdEdit } from "react-icons/md";
import Confirm from "../../../components/Confirm";

function Listagem<T>({ onEdit, service }: IProps<T>) {
	const [lista, setLista] = useState<T[]>([]);
	const [loading, setLoading] = useState<boolean>(true);
	const [idDelete, setIdDelete] = useState<string>("");

	const {
		state: { user },
	} = useAuth();
	const { translate } = useTranslate();

	const handleRefresh = useCallback(
		(id: number) => {
			service
				.get()
				.then(setLista)
				.catch((err) => {
					notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
					console.error(err);
				});
		},
		[translate, service]
	);

	const handleDelete = () => {
		service
			.delete(idDelete)
			.then(() => {
				notify(translate(EnumMsg.Sucesso), "success", 2000);
				setIdDelete("");
			})
			.catch((err) => {
				notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
				console.error(err);
			});
	};

	return (
		<>
			<DataGrid height={440} dataSource={lista} keyExpr="id" showBorders={true} onContentReady={() => setLoading(false)} showRowLines rowAlternationEnabled>
				<SearchPanel visible highlightCaseSensitive={false} placeholder={translate(EnumMsg.Pesquisar)} width={300} />

				<Scrolling mode="virtual" />
				<LoadPanel enabled={loading} />

				<Column dataField="codigo" caption={translate(EnumMsg.Codigo)} />
				<Column dataField="descricao" caption={translate(EnumMsg.Descricao)} />
				<Column cellRender={({ data }) => <IconButton icon={MdEdit} variant="outlined" color="secondary" onClick={() => onEdit(data.id)} />} width={50} />
				<Column cellRender={({ data }) => <IconButton icon={MdDelete} variant="outlined" onClick={() => setIdDelete(data.id)} />} width={50} />
			</DataGrid>
			<Confirm handleCancel={() => setIdDelete(0)} handleConfirm={handleDelete} message={EnumMsg.ORegistroSeraExcluidoPermanentemente} open={!!idDelete} />
		</>
	);
}

export default Listagem;
