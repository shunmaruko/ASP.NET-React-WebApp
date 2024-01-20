import { UserManager, UserManagerSettings } from 'oidc-client-ts';
import { ApplicationName } from './ApiAuthorizationConstants'

const setting = {
    authority: "",
    client_id: "",
    redirect_uri: "",
} as UserManagerSettings;

export const AuthenticationResultStatuses = {
    Redirect: 'redirect',
    Success: 'success',
    Fail: 'fail'
};

export type AuthenticationResultStatus = (typeof AuthenticationResultStatuses)[keyof typeof AuthenticationResultStatuses];
