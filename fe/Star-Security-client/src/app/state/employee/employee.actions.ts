import { Action } from "@ngrx/store";

export enum EEmployeeActions {
    LOGIN = '[Employee] Login',
    LOGIN_SUCCESS = '[Employee] Login Success',
    LOGIN_ERROR = '[Employee] Login Error',
    LOGOUT = '[Employee] Logout',
}

export class Login implements Action {
    public readonly type = EEmployeeActions.LOGIN;
    constructor(public payload: { email: string; password: string }) {}
}

export class LoginSuccess implements Action {
    public readonly type = EEmployeeActions.LOGIN_SUCCESS;
    constructor(public payload: { username: string, token: string }) {}
}

export class LoginError implements Action {
    public readonly type = EEmployeeActions.LOGIN_ERROR;
    constructor() {}
}

export class Logout implements Action {
    public readonly type = EEmployeeActions.LOGOUT;
}

export type EmployeeActions = Login | LoginSuccess | LoginError | Logout;