import IProps from "./interfaces/IProps";
import { Formik, Form } from "formik";
import Grid from "../../Grid";
import Button from "../../Button";
import { useTranslate } from "../../../contexts/TranslateContext";
import EnumMsg from "../../../translate/enums/EnumMsg";
import GenericField from "../fields/GenericField";

function MyForm<T>(props: IProps<T>) {
	const { translate } = useTranslate();

	const handleValidate = async (values: T) => {
		const errors: { [k: string]: string } = {};

		let haveFieldErrors = false;
		for (let k of Object.keys(values)) {
			let key = k as keyof typeof values;
			const funcValidate = props.config.find((x) => x.name === key)?.validate;
			if (funcValidate) {
				const fieldError = await funcValidate(values[key]);
				if (fieldError) {
					errors[k] = translate(fieldError as EnumMsg);
					haveFieldErrors = true;
				}
			}
		}
		if (haveFieldErrors) return errors;

		if (props.validate) {
			const geralErrors = await props.validate(values);
			return { ...errors, ...(geralErrors || {}) };
		}

		return {};
	};

	return (
		<Formik enableReinitialize initialValues={props.initialValues} validate={handleValidate} onSubmit={props.submit} validateOnMount>
			{({ isValid, isSubmitting }) => (
				<Form>
					<Grid spacing={2} align="center">
						{props.config?.map((c) => (
							<Grid key={c.name} item {...(c.divSize || {})}>
								<GenericField name={c.name} type={c.fieldType} config={c.editorConfig || {}} label={c.label} />
							</Grid>
						))}
						<Grid item xs={12}>
							<Grid justify="flex-end">
								<Button type="submit" color="success" disabled={isSubmitting || !isValid}>
									{translate(props.confirmText || EnumMsg.Confirmar)}
								</Button>
							</Grid>
						</Grid>
					</Grid>
				</Form>
			)}
		</Formik>
	);
}

export default MyForm;
