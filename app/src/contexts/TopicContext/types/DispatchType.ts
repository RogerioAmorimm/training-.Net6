
interface IDispatch_TO_SET {
    type: "TO_SET",
    payload: { topic: number; };
}

type DispatchType = IDispatch_TO_SET

export default DispatchType;