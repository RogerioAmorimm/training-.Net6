import ITicketPage from "../../pages/TicketsPage/interfaces/ITicketPage";
import { getAxiosInstance } from "../BaseApiService/baseApi";
import ITicketServiceModule from "./interfaces/ITicketServiceModule";

const baseUrl = ""

const axiosInstance = getAxiosInstance(baseUrl);

export const OrigemProspectServiceModule: ITicketServiceModule = {
    get: function (): Promise<ITicketPage[]> {
        throw new Error("Function not implemented.");
    },
    getById: function (id: string,): Promise<ITicketPage | null> {
        throw new Error("Function not implemented.");
    },
    post: function (data: ITicketPage): Promise<void> {
        return axiosInstance.post("producer-ticket", data);
    },
    put: function (data: ITicketPage): Promise<void> {
        throw new Error("Function not implemented.");
    },
    delete: function (id: string): Promise<void> {
        throw new Error("Function not implemented.");
    }
}