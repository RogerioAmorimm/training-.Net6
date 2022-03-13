export default interface IDefaultServiceResponse<T> {
	data?: T;
	success: boolean;
	message?: string;
}
