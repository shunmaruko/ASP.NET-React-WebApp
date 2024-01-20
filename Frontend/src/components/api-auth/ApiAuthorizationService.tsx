import { UserManager, WebStorageStateStore } from 'oidc-client-ts';
import { ApplicationName } from './ApiAuthorizationConstants'
const userStore = new WebStorageStateStore({ prefix: ApplicationName });
const settings = {
    userStore: userStore
}
const mgr = new UserManager(settings);
type User = {
    userName: string;
}

export const AuthenticationResultStatuses = {
    Redirect: 'redirect',
    Success: 'success',
    Fail: 'fail'
};

export type AuthenticationResultStatus = (typeof AuthenticationResultStatuses)[keyof typeof AuthenticationResultStatuses];
