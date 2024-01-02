export interface LoadConditions {
    filter: string[] | null,
    sorter: (SortDefinition | null)[] | null,
    page: number | null,
    pageSize: number | null
}

export interface SortDefinition{
    field: string;
    order: string;
}

export interface PropertyWithValue{
    property: string;
    value: string;
}

export interface FilterDefinition{
    property: string;
    comparor: string;
    value: string;
}

export interface LoadResult<T>{
    totalCount: number;
    data: T[];
}