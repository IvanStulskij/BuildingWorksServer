import { LoadResult } from "src/app/types/loader";
import { Provider } from "src/app/types/providers";

export interface IBuildingObjectProviderState {
    providers: LoadResult<Provider> | null;
    selectedProvider: Provider | null;
}

export const initialBuildingObjectProviderState: IBuildingObjectProviderState = {
    providers: null,
    selectedProvider: null
};
