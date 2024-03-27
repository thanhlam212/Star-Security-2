export interface IClientRegistrationState {
    loading: boolean;
    success: boolean;
    fail: boolean;
    username: string;
  }
  
  export interface IClientLoginState {
    loading: boolean;
    success: boolean;
    fail: boolean;
    username: string;
    token: string | null;
  }
  
  export interface IClientState {
    login: IClientLoginState;
    registration: IClientRegistrationState; 
  }