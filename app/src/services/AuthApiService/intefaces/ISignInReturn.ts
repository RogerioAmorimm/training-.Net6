import IUser from "../../../contexts/AuthContext/Interfaces/IUser";
import {Role} from "../../../contexts/AuthContext/types/Role";

export default interface ISignInResult {
    token: string;
    user: IUser;
    role: Role
}
