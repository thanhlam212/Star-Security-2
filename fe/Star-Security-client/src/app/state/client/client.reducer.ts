import { ClientActions, EClientActions } from "./client.actions";
import { IClientLoginState, IClientState } from "./client.state";

const initialLoginState : IClientLoginState = {
    loading : false,
    success : false,
    fail : false,
    username : '',
    token : null,
};

const initialRegistrationState : IClientLoginState = {
    loading : false,
    success : false,
    fail : false,
    username : '',
    token : null,
};

const initialState : IClientState = {
    login : initialLoginState,
    registration : initialRegistrationState,
};

export function clientReducer(
    state = initialState,
    action : ClientActions
) : IClientState {
    switch (action.type) {
        case EClientActions.LOGIN:
            return {
                ...state,
                login: {...initialLoginState, loading : true},
            };
        case EClientActions.LOGIN_SUCCESS: 
            return {
                ...state,
                login: {
                    ...state.login,
                    loading : false,
                    success : true,
                    username : action.payload.username,
                    token : action.payload.token,
                },
            };
        case EClientActions.LOGIN_FAIL:
            return {
                ...state,
                login: {
                    ...state.login,
                    loading : false,
                    fail : true,
                },
            };
        case EClientActions.REGISTER:
            return {
                ...state,
                registration : {...initialRegistrationState, loading: true},
            };
        case EClientActions.REGISTER_SUCCESS:
            return {
                ...state,
                registration : {
                    ...state.registration,
                    loading : false,
                    success : true,
                    username : action.payload.username,
                },
            };
        case EClientActions.REGISTER_FAIL:
            return {
                ...state,
                registration : {
                    ...state.registration,
                    loading : false,
                    fail : true,
                },
            };
        case EClientActions.LOG_OUT:
            return {
                ...state,
                login : initialLoginState,
                registration : initialRegistrationState,
            };
        default : 
            return state;    
    };
}