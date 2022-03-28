import { Role } from "../../../contexts/AuthContext/types/Role";

export default interface IRegisterParameter {
    email: string;
    password: string;
    repassword: string;
    UserName: string;
    role:  Role;
}
