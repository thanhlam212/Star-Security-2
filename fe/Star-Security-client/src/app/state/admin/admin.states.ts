export interface IAdminLoginState {
    loading: boolean;
    success: boolean;
    error: boolean;
    username: string;
    tokenAdmin: string | null;
}

export interface IAdminState {
    loginAdmin: IAdminLoginState;
}