import IUser from "./IUser";

export default interface IState {
	user?: IUser | null;
	token?: string | null;
}
