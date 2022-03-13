import IUser from "../../../contexts/AuthContext/Interfaces/IUser";

export default interface ISignInResult {
	token: string;
    user: IUser
}
