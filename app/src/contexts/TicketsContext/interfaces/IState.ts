export default interface IState {
    itens: ITicketState[];
}

export interface ITicketState {
    from: string,
    to: string,
    title: string
}