import { createSelector, createFeatureSelector } from "@ngrx/store";
import { IClientState, IClientLoginState, IClientRegistrationState } from "./client.state";
import { Login } from "../employee";


const getClienState = createFeatureSelector<IClientState>('user');

// Selectors for login state
export const getLoginState = createSelector(
    getClienState,
    (state : IClientState) => state.login
);

export const getLoadingLogin = createSelector(
    getLoginState,
    (loginState : IClientLoginState) => loginState.loading
);

export const getSuccessLogin = createSelector(
    getLoginState,
    (loginState : IClientLoginState) => loginState.success
);

export const getFailLogin = createSelector(
    getLoginState,
    (loginState : IClientLoginState) => loginState.fail
);

// Selectors for registation state

export const getRegistrationState = createSelector(
    getClienState,
    (state : IClientState) => state.registration
);

export const getLoadingRegistration = createSelector(
    getRegistrationState,
    (registrationState: IClientRegistrationState) => registrationState.loading
);
  
export const getSuccessRegistration = createSelector(
    getRegistrationState,
    (registrationState: IClientRegistrationState) => registrationState.success
);
  
export const getFailRegistration = createSelector(
    getRegistrationState,
    (registrationState: IClientRegistrationState) => registrationState.fail
);

export const getIsLoggedOut = createSelector(
    getLoginState,
    getRegistrationState,
    (loginState: IClientLoginState, registrationState: IClientRegistrationState) =>
      !loginState.loading && !registrationState.loading && !loginState.success && !registrationState.success
);