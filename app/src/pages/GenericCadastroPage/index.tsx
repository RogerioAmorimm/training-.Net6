import { useEffect, useState } from "react";
import IProps from "./interfaces/IProps";
import * as S from "./styles";
import Container from "../../components/Container";
import Button from "../../components/Button";
import { useTranslate } from "../../contexts/TranslateContext";
import EnumMsg from "../../translate/enums/EnumMsg";
import Listagem from "./_listagem";
import Cadastro from "./_cadastro";
import { useAuth } from "../../contexts/AuthContext";
import { Role } from "../../contexts/AuthContext/types/Role";
import { Topics } from "../TicketsPage/types/Topic";
import { useTopics } from "../../contexts/TopicContext";

function CadastroPage<T>({ formConfig, service }: IProps<T>) {
	const [idEdit, setIdEdit] = useState<number>(0);
	const [showList, setShowList] = useState<boolean>(!idEdit);
	const { state: { role } } = useAuth();
	const { translate } = useTranslate();
	const { dispatch: topicDispatch } = useTopics();
	var array: { key: string, value: string }[] = [];

	for (let value in Topics) {
		if (Topics.hasOwnProperty(value) &&
			(isNaN(parseInt(value)))) {
			array.push({ key: Topics[value], value: value });
		}
	}
	useEffect(() => {
		if (idEdit) setShowList(false);
	}, [idEdit]);

	useEffect(() => {
		if (showList) setIdEdit(0);
	}, [showList]);

	return (
		<Container paper selfCenter>

			{role?.toString().toLowerCase() === Role[Role.Producer].toLowerCase()
				? (
					<Button color="secondary" onClick={() => setShowList((v) => !v)}>
						{showList ? translate(EnumMsg.Adicionar) : translate(EnumMsg.Voltar)}
					</Button>

				)
				: array.map((e) =>
					<Button key={`${e.key}:${e.value}`} style={{ margin: "10px" }} color="secondary" onClick={(teste) => {
						const value = +e.key;
						topicDispatch({ type: "TO_SET", payload: { topic: value } });
					}}>
						{e.value}
					</Button>)
			}
			<S.Content>
				{showList ? (
					<Listagem<T> onEdit={setIdEdit} service={service}/>
				) : (
					<Cadastro idEdit={idEdit} onUpdated={() => setShowList(true)} formConfig={formConfig} service={service} />

				)}
			</S.Content>
		</Container>
	);
}

export default CadastroPage;
