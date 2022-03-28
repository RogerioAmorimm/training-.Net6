import IUser from "../Interfaces/IUser";
import { Role } from "./Role";

interface IDispatch_SIGN_IN {
    type: "SIGN_IN";
    payload: { token: string; user: IUser, role: Role };
}
interface IDispatch_SIGN_OUT {
    type: "SIGN_OUT";
}
type DispatchType = IDispatch_SIGN_IN | IDispatch_SIGN_OUT;

export default DispatchType;
