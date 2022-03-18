import { useEffect, useState } from "react";
import IProps from "./interfaces/IProps";
import * as S from "./styles";
import Container from "../../components/Container";
import Button from "../../components/Button";
import { useTranslate } from "../../contexts/TranslateContext";
import EnumMsg from "../../translate/enums/EnumMsg";
import Listagem from "./_listagem";
import Cadastro from "./_cadastro";

function CadastroPage<T>({ formConfig, service, onlyList }: IProps<T>) {
	const [idEdit, setIdEdit] = useState<number>(0);
	const [showList, setShowList] = useState<boolean>(!idEdit);

	const { translate } = useTranslate();

	useEffect(() => {
		if (idEdit) setShowList(false);
	}, [idEdit]);

	useEffect(() => {
		if (showList) setIdEdit(0);
	}, [showList]);

	return (
		<Container paper selfCenter>
			{!onlyList
				? (
					<Button color="secondary" onClick={() => setShowList((v) => !v)}>
						{showList ? translate(EnumMsg.Adicionar) : translate(EnumMsg.Voltar)}
					</Button>

				)
				: null
			}
			<S.Content>
				{showList ? (
					<Listagem<T> onEdit={setIdEdit} service={service} />
				) : (
					<Cadastro idEdit={idEdit} onUpdated={() => setShowList(true)} formConfig={formConfig} service={service} />
				)}
			</S.Content>
		</Container>
	);
}

export default CadastroPage;
