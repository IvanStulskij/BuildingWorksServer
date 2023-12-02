import { DictionaryActions, EDictionaryActions } from "../actions/dictionaries.actions";
import { IDictionaryState } from "../states/dictionary.state";

export const dictionaryReducer = (
    state = [],
    action: DictionaryActions
) : IDictionaryState => {
    switch (action.type) {
        case EDictionaryActions.GetBuildingObjectTypesSuccess: {
            return {
                ...state,
                dictionaryItems: action.payload
            }
        }
        default: {
            return {
                ...state,
                dictionaryItems: []
            }
        }
    }
}