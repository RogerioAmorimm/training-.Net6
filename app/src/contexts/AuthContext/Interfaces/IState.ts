import Role from "../types/Role";
import IUser from "./IUser";

export default interface IState {
	user?: IUser | null;
	token?: string | null;
	role?: Role | null;
}
