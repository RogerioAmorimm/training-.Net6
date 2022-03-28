import { HubConnection, HubConnectionState } from "@microsoft/signalr";
import ITicketPage from "../../pages/TicketsPage/interfaces/ITicketPage";
import { Topics } from "../../pages/TicketsPage/types/Topic";
import { getAxiosInstance, getSignalRInstance } from "../BaseApiService/baseApi";
import ITicketServiceModule from "./interfaces/ITicketServiceModule";

const baseUrlProducer = "http://localhost:12140/";
const axiosInstanceProducer = getAxiosInstance(baseUrlProducer);


export const TicketServiceModule: ITicketServiceModule = {
    post: function (data: ITicketPage): Promise<void> {
        data.typeTopic = +Topics[data.typeTopic];
        return axiosInstanceProducer.post("ProducerTicket/producer-ticket", data);
    },
    openConnectionSinalR: async function (baseUrl: string, token: string): Promise<HubConnection> {
        const signalRInstanceConsumer = getSignalRInstance(baseUrl, token);
        if (signalRInstanceConsumer.state === HubConnectionState.Connected)
            await signalRInstanceConsumer.stop();
        await signalRInstanceConsumer.start();
        return signalRInstanceConsumer;
    },
}