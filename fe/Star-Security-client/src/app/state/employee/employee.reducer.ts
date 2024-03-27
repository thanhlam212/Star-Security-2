import { EEmployeeActions, EmployeeActions } from "./employee.actions";
import { IEmployeeLoginState, IEmployeeState } from "./employee.states";


const initialLoginState: IEmployeeLoginState = {
    loading: false,
    success: false,
    error: false,
    username: '',
    token: null,
};

const initialState: IEmployeeState = {
    login: initialLoginState,
}

export function employeeReducer(
    state = initialState,
    action: EmployeeActions,
): IEmployeeState {
    switch (action.type) {
        case EEmployeeActions.LOGIN:
        return {
            ...state,
            login: { ...initialLoginState, loading: true },
        };
        case EEmployeeActions.LOGIN_SUCCESS:
        return {
            ...state,
            login: {
                ...state.login,
                loading: false,
                success: true,
                username: action.payload.username,
                token: action.payload.token,
            },
        };
        case EEmployeeActions.LOGIN_ERROR:
            return {
            ...state,
            login: { ...state.login, loading: false, error: true },
            };
    
        case EEmployeeActions.LOGOUT:
            return {
            ...state,
            login: initialLoginState,
            };
    
        default:
          return state;
      }
}