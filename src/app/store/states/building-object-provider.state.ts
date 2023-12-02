import { Provider } from "src/app/types/providers";

export interface IBuildingObjectProviderState {
    providers: Provider[];
    selectedProvider: Provider | null;
}

export const initialBuildingObjectProviderState: IBuildingObjectProviderState = {
    providers: [],
    selectedProvider: null
};
