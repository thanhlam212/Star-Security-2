import * as fromEmployee from './employee'
import * as fromAdmin from './admin'
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';

export interface IAppState{
    employee: fromEmployee.IEmployeeState;
    admin: fromAdmin.IAdminState;
}

export const appReducer: ActionReducerMap<IAppState> = {
    employee: fromEmployee.employeeReducer as ActionReducer<fromEmployee.IEmployeeState, Action>,
    admin: fromAdmin.adminReducer as ActionReducer<fromAdmin.IAdminState, Action>,
}