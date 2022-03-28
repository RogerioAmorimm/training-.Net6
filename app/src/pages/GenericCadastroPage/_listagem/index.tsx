import { useCallback, useEffect, useState } from "react";
import IProps from "./interfaces/IProps";
import DataGrid, { Scrolling, LoadPanel, Column, SearchPanel } from "devextreme-react/data-grid";
import { useAuth } from "../../../contexts/AuthContext";
import notify from "devextreme/ui/notify";
import { useTranslate } from "../../../contexts/TranslateContext";
import EnumMsg from "../../../translate/enums/EnumMsg";
import IconButton from "../../../components/IconButton";
import { MdDelete, MdEdit } from "react-icons/md";
import { HubConnectionState } from "@microsoft/signalr";
import { Role } from "../../../contexts/AuthContext/types/Role";
import { useTopics } from "../../../contexts/TopicContext";

function Listagem<T>({ onEdit, service }: IProps<T>) {
	const [lista, setLista] = useState<T[]>([]);
	const [loading, setLoading] = useState<boolean>(true);
	const { state: { topic } } = useTopics();
	const {
		state: { role, token },
	} = useAuth();
	const { translate } = useTranslate();

	const handlerProducer = async () => {
		const connection = await service.openConnectionSinalR("http://localhost:12140/hub/ticket-hub", token ?? "");
		connection.invoke<T[]>("GetTicketsAsync").then((data) => setLista(data));

	}
	const handlerConsumer = async (topic: number) => {

		let connection = await service.openConnectionSinalR("http://localhost:12141/ticket-hub", token ?? "");

		connection.stream<T>("ListenTickets", topic)
			.subscribe({
				next: (item) => {
					setLista(lista => [...lista, item]);
				},
				complete: () => {
					console.log("completed");
				},
				error: (err) => {
					if (connection.state === HubConnectionState.Disconnecting)
						connection.off("ListenTickets");
					else {
						notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
						console.error(err);
					}
				}
			});
	};

	const handleRefresh = useCallback(
		async (topic: number) => {
			if (role?.toString().toLowerCase() === Role[Role.Consumer].toLowerCase())
				handlerConsumer(topic);
			else handlerProducer();
		},
		[translate, service]
	);

	useEffect(() => {
		setLista([]);
		handleRefresh(topic);
	}, [handleRefresh, topic])

	return (
		<>
			<DataGrid height={440} dataSource={lista} keyExpr={['typeTopic', 'description']} showBorders={true} onContentReady={() => setLoading(false)} showRowLines rowAlternationEnabled>
				<SearchPanel visible highlightCaseSensitive={false} placeholder={translate(EnumMsg.Pesquisar)} width={300} />

				<Scrolling mode="virtual" />
				<LoadPanel enabled={loading} />

				<Column dataField="typeTopic" caption={translate(EnumMsg.Topics)} />
				<Column dataField="description" caption={translate(EnumMsg.Descricao)} />
				<Column dataField="userName" caption={translate(EnumMsg.UserName)} />
				<Column cellRender={({ data }) => <IconButton icon={MdEdit} variant="outlined" color="secondary" onClick={() => onEdit(data.id)} />} width={50} />
				<Column cellRender={({ data }) => <IconButton icon={MdDelete} variant="outlined" onClick={() =>{}} />} width={50} />
			</DataGrid>
		</>
	);
}

export default Listagem;
