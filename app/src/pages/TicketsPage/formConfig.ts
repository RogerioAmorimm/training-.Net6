import { IConfigField } from "../../components/formik/Form/interfaces/IConfigField";
import EnumFieldType from "../../components/formik/Form/enums/EnumFieldType";
import validator from "validator";
import EnumMsg from "../../translate/enums/EnumMsg";
import { Topics } from "./types/Topic";

export const configCadastro: IConfigField[] = [
	{
		name: "typeTopic",
		label: EnumMsg.Topics,
		fieldType: EnumFieldType.select,
		divSize: { xs: 12, lg: 3, xl: 2 },
		editorConfig:
		{
			data: [Topics[Topics.Ti], Topics[Topics.Email], Topics[Topics.Other]]
		},
	},
	{
		name: "description",
		label: EnumMsg.Descricao,
		fieldType: EnumFieldType.text,
		divSize: { xs: 12, lg: 9, xl: 10 },
		validate: async (value: string) => {
			if (validator.isEmpty(value, { ignore_whitespace: true })) return EnumMsg.DescricaoEhObrigatorio;
			else {
				if (!validator.isLength(value?.trim() || "", { min: 2 })) return EnumMsg.ADescricaoDeveTerNoMinimoDoisCaracteres;
				if (!validator.isLength(value?.trim() || "", { max: 100 })) return EnumMsg.ADescricaoDeveTerNoMaximoCemCaracteres;
			}
		},
	},
];


