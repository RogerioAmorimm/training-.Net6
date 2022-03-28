import EnumFieldType from "../../components/formik/Form/enums/EnumFieldType";
import { IConfigField } from "../../components/formik/Form/interfaces/IConfigField";
import EnumMsg from "../../translate/enums/EnumMsg";
import validator from "validator";
import { Role } from "../../contexts/AuthContext/types/Role";


export const configCadastro: IConfigField[] = [
    {
        name: "UserName",
        label: EnumMsg.UserName,
        fieldType: EnumFieldType.text,
        divSize: { xs: 12, lg: 9, xl: 10 },
        validate: async (value: string) => {
            if (validator.isEmpty(value, { ignore_whitespace: true })) return EnumMsg.UserNameEhObrigatorio;
            else {
                if (!validator.isLength(value?.trim() || "", { min: 2 })) return EnumMsg.UserNameDeveTerNoMinimoDoisCaracteres;
                if (!validator.isLength(value?.trim() || "", { max: 16 })) return EnumMsg.UserNameDeveTerNoMaximoCemCaracteres;
            }
        },
    },
    {
        name: "Email",
        label: EnumMsg.Email,
        fieldType: EnumFieldType.email,
        divSize: { xs: 12, lg: 9, xl: 10 },
        validate: async (value: string) => {
            if (validator.isEmpty(value, { ignore_whitespace: true })) return EnumMsg.EmailEhObrigatorio;
        }
    },
    {
        name: "Password",
        label: EnumMsg.Senha,
        fieldType: EnumFieldType.password,
        divSize: { xs: 12, lg: 9, xl: 10 },
        validate: async (value: string) => {
            if (validator.isEmpty(value, { ignore_whitespace: true })) return EnumMsg.SenhaEhObrigatorio;
        }
    },
    {
        name: "RePassword",
        label: EnumMsg.ReSenha,
        fieldType: EnumFieldType.password,
        divSize: { xs: 12, lg: 9, xl: 10 },
        validate: async (value: string) => {
            if (validator.isEmpty(value, { ignore_whitespace: true })) return EnumMsg.SenhaEhObrigatorio;
        }
    },
    {
        name: "role",
        label: EnumMsg.Roles,
        fieldType: EnumFieldType.select,
        divSize: { xs: 12, lg: 9, xl: 10 },
        editorConfig:
        {
            data: [Role[Role.Producer], Role[Role.Consumer]]
        },
    },

]

