import { LoadResult } from "src/app/types/loader";
import { Provider } from "src/app/types/providers";

export interface IProviderState {
    loadResult: LoadResult<Provider> | null;
    selectedProvider: Provider | null;
}

export const initialProviderState: IProviderState = {
    loadResult: null,
    selectedProvider: null
};
