export default interface IBaseCadastroPageService<T> {
	get: (topic: number) => Promise<T[]>;
	getById: (id: string) => Promise<T | null>;
	post: (data: T) => Promise<void>;
	put: (data: T) => Promise<void>;
	delete: (id: string) => Promise<void>;
}
