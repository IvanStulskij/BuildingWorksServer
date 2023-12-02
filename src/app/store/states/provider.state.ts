import { Provider } from "src/app/types/providers";

export interface IProviderState {
    providers: Provider[];
    selectedProvider: Provider | null;
}

export const initialProviderState: IProviderState = {
    providers: [],
    selectedProvider: null
};
