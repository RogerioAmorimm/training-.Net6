import { useEffect, useState } from "react";
import notify from "devextreme/ui/notify";
import IProps from "./interfaces/IProps";
import Form from "../../../components/formik/Form";
import { FormikHelpers } from "formik";
import { useTranslate } from "../../../contexts/TranslateContext";
import EnumMsg from "../../../translate/enums/EnumMsg";
import { useAuth } from "../../../contexts/AuthContext";

function Cadastro<T>({ idEdit, onAdded, onUpdated, service, formConfig }: IProps<T>) {
	const { translate } = useTranslate();
	const {
		state: { user },
	} = useAuth();

	const [initialValues, setInitialValues] = useState<T>({} as T);
	
	const handleSubmit = (data: T, actions: FormikHelpers<T>) => {
		
		actions.setSubmitting(true);

		if (!idEdit) {
			service
				.post(data)
				.then(() => {
					actions.resetForm();
					notify(translate(EnumMsg.Sucesso), "success", 2000);
					onAdded && onAdded();
				})
				.catch((err) => {
					console.error(err);
					notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
				})
				.finally(() => actions.setSubmitting(false));
		} else {
			service
				.put(data)
				.then(() => {
					notify(translate(EnumMsg.Sucesso), "success", 2000);
					onUpdated && onUpdated();
				})
				.catch((err) => {
					console.error(err);
					notify(translate(EnumMsg.ErroInesperado), "warning", 2000);
				})
				.finally(() => actions.setSubmitting(false));
		}
	};


	return <Form<T> config={formConfig} initialValues={initialValues} submit={handleSubmit} />;
}

export default Cadastro;
