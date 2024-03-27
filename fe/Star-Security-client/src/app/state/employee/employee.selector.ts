import { createFeatureSelector, createSelector } from "@ngrx/store";
import { IEmployeeLoginState, IEmployeeState } from "./employee.slates";

const getEmployeeState = createFeatureSelector<IEmployeeState>('employee');

// Selectors for login state
export const getLoginState = createSelector(
    getEmployeeState,
    (state: IEmployeeState) => state.login
);

export const getLoadingLogin = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => loginState.loading
);

export const getSuccessLogin = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => loginState.success
);

export const getFailLogin = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => loginState.error
);


export const getToken = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => loginState.token
);

export const getEmployeeEmail = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => loginState.username
);

export const getIsLoggedOut = createSelector(
    getLoginState,
    (loginState: IEmployeeLoginState) => !loginState.token && !loginState.loading && !loginState.success
)