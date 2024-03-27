import * as fromEmployee from './employee'
import * as fromAdmin from './admin'
import * as fromClient from './client'
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';

export interface IAppState{
    employee: fromEmployee.IEmployeeState;
    admin: fromAdmin.IAdminState;
    client: fromClient.IClientState
}

export const appReducer: ActionReducerMap<IAppState> = {
    employee: fromEmployee.employeeReducer as ActionReducer<fromEmployee.IEmployeeState, Action>,
    admin: fromAdmin.adminReducer as ActionReducer<fromAdmin.IAdminState, Action>,
    client: fromClient.clientReducer as ActionReducer<fromClient.IClientState, Action>
}