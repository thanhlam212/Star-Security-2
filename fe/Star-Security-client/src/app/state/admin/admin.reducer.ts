import { EAdminActions, AdminActions } from "./admin.actions";
import { IAdminLoginState, IAdminState } from "./admin.states";

const initialLoginState: IAdminLoginState = {
    loading: false,
    success: false,
    error: false,
    username: '',
    tokenAdmin: null,
};

const initialState: IAdminState = {
    loginAdmin: initialLoginState,
};

export function adminReducer(
    state = initialState,
    action: AdminActions
  ): IAdminState {
    switch (action.type) {
      case EAdminActions.LOGIN_ADMIN:
        return {
          ...state,
          loginAdmin: { ...initialLoginState, loading: true },
        };
      case EAdminActions.LOGIN_SUCCESS_ADMIN:
        return {
          ...state,
          loginAdmin: {
            ...state.loginAdmin,
            loading: false,
            success: true,
            username: action.payload.username,
            tokenAdmin: action.payload.tokenAdmin,
          },
        };
      case EAdminActions.LOGIN_FAIL_ADMIN:
        return {
          ...state,
          loginAdmin: { ...state.loginAdmin, loading: false, error: true },
        };
  
      case EAdminActions.LOGOUT_ADMIN:
        return {
          ...state,
          loginAdmin: initialLoginState,
        };
  
      default:
        return state;
    }
  }

