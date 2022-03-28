import { HubConnection } from "@microsoft/signalr";

export default interface IBaseCadastroPageService<T> {
	post: (data: T) => Promise<void>;
	openConnectionSinalR: (baseUrl:string, token: string) => Promise<HubConnection>;
}
