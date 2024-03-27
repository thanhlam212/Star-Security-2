import { Action } from "@ngrx/store";

export enum EClientActions{
    LOGIN = '[USER] Login',
    LOGIN_SUCCESS = '[USER] Login Success',
    LOGIN_FAIL = '[USER] Login Fail',
    REGISTER = '[USER] Register',
    REGISTER_SUCCESS = '[USER] Register Success',
    REGISTER_FAIL = '[USER] Register Fail',
    LOG_OUT = '[USER] Logout'
}

export class Login implements Action {
    public readonly type = EClientActions.LOGIN;
    constructor(public payload : { email : string, password: string}) {}
}

export class LoginSuccess implements Action {
    public readonly type = EClientActions.LOGIN_SUCCESS;
    constructor(public payload : { username : string, token : string}) {}
}

export class LoginFail implements Action {
    public readonly type = EClientActions.LOGIN_FAIL;
    constructor(){}
}

export class Register implements Action {
    public readonly type = EClientActions.REGISTER;
    constructor(public payload : { username : string, email : string, password : string}){}
}

export class RegisterSuccess implements Action {
    public readonly type = EClientActions.REGISTER_SUCCESS;
    constructor(public payload : {username : string, token : string}) {}
}

export class RegisterFail implements Action { 
    public readonly type = EClientActions.REGISTER_FAIL;
}

export class Logout implements Action{
    public readonly type = EClientActions.LOG_OUT;
}

export type ClientActions = Login | LoginSuccess | LoginFail | Register | RegisterSuccess | RegisterFail | Logout;