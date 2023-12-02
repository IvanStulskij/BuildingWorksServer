import { DictionaryItem } from "src/app/types/common";

export interface IDictionaryState {
    dictionaryItems: DictionaryItem[];
}

export const initialDictionariesState: IDictionaryState = {
    dictionaryItems: [],
};
