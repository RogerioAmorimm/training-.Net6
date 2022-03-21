import ITicketPage from "../../pages/TicketsPage/interfaces/ITicketPage";
import { getAxiosInstance } from "../BaseApiService/baseApi";
import ITicketServiceModule from "./interfaces/ITicketServiceModule";

const baseUrlProducer = "http://localhost:12140/";
const axiosInstanceProducer = getAxiosInstance(baseUrlProducer);

const baseUrlConsumer = "https://localhost:44317/";
const axiosInstanceConsumer = getAxiosInstance(baseUrlConsumer);

export const TicketServiceModule: ITicketServiceModule = {
    get: async function (topic: number): Promise<ITicketPage[]> {
        var result = (await axiosInstanceConsumer.get(`ConsumerTicket/consumer-ticket?topic=${topic}`)).data
        return [result]
    },
    getById: function (id: string): Promise<ITicketPage | null> {
        throw new Error("Function not implemented.");
    },
    post: function (data: ITicketPage): Promise<void> { 
        data.typeTopic = +data.typeTopic;        
        return axiosInstanceProducer.post("ProducerTicket/producer-ticket", data);
    },
    put: function (data: ITicketPage): Promise<void> {
        throw new Error("Function not implemented.");
    },
    delete: function (id: string): Promise<void> {
        throw new Error("Function not implemented.");
    }
}