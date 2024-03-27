export interface IEmployeeLoginState{
    loading: boolean;
    success: boolean;
    error: boolean;
    username: string;
    token: string | null;
}

export interface IEmployeeState {
    login: IEmployeeLoginState;
}