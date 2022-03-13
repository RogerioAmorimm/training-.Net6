import LangType from "../../../translate/types/LangTypes";


interface IDispatch_SET_LANG
{
    type:"SET_LANG";
    payload:LangType;
}

type DispatchType = IDispatch_SET_LANG;

export default DispatchType;