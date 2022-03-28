import { FC, useState } from "react";
import MyForm from "../../components/formik/Form";
import IProps from "./interfaces/IProps";
import { useAuth } from "../../contexts/AuthContext";
import { useTranslate } from "../../contexts/TranslateContext";
import { FormikHelpers } from "formik/dist/types";
import { configCadastro } from "./formConfig";
import IRegisterParameter from "../../services/AuthApiService/intefaces/IRegisterParameter";
import { register } from "../../services/AuthApiService";
import EnumMsg from "../../translate/enums/EnumMsg";
import notify from "devextreme/ui/notify";
import Button from "../../components/Button";
import ISignInResult from "../../services/AuthApiService/intefaces/ISignInReturn";
import { useNavigate } from "react-router-dom";

const Register: FC<IProps> = (props) => {
    const { translate } = useTranslate();
    const {
        dispatch
    } = useAuth();
    const navigate = useNavigate();
    const [initialValues, setInitialValues] = useState<IRegisterParameter>({} as IRegisterParameter);

    const handleSubmit = (data: IRegisterParameter, actions: FormikHelpers<IRegisterParameter>) => {
        actions.setSubmitting(true);
        register(data)
            .then((Response) => {

                if (Response.status === 206) {
                    notify((Response.data as string[])[0], "warning", 2000);
                    return;
                }

                const { role, token, user } = Response.data as ISignInResult;
                dispatch({ type: "SIGN_IN", payload: { token: token, user: user, role: role } });
                navigate("/dashboard");

            }).catch((err) => {

                console.error(err);
                notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
            })
            .finally(() => actions.setSubmitting(false));


    };
    return (
        <>
            <Button color="secondary" onClick={() => {
                props.setBackState((v) => !v)
            }}>
                {translate(EnumMsg.Voltar)}
            </Button>
            <MyForm<IRegisterParameter> config={configCadastro} initialValues={initialValues} submit={handleSubmit} />
        </>);
}
export default Register;