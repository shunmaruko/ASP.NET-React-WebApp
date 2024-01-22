const IdentityServerUrl = 'https://localhost:7226';
const clientUrl = `http://localhost:5173`;
const baseUrl = `${clientUrl}/authentication`;

export const ApplicationName = 'ASP.NET-React-Web';

export const QueryParameterNames = {
    ReturnUrl: 'returnUrl',
    Message: 'message'
};
export type QueryParameterName = (typeof QueryParameterNames)[keyof typeof QueryParameterNames];

export const LogoutActions = {
    LogoutCallback: 'logout-callback',
    Logout: 'logout',
    LoggedOut: 'logged-out'
};
export type LogoutAction = (typeof LogoutActions)[keyof typeof LogoutActions];

export const LoginActions = {
    Login: 'login',
    LoginCallback: 'login-callback',
    LoginFailed: 'login-failed',
    SignIn: 'signin'
};
export type LoginAction = (typeof LoginActions)[keyof typeof LoginActions];

export const ApiAutorizationPaths = {
    ServerUrl: IdentityServerUrl,
    ClientAuthBaseUrl: baseUrl,
    DefaultLoginRedirectPath: '/',
    ApiAuthorizationClientConfigurationUrl: `${IdentityServerUrl}$/_configuration/${ApplicationName}`,
    Login: `${baseUrl}/${LoginActions.Login}`,
    LoginFailed: `${baseUrl}/${LoginActions.LoginFailed}`,
    LoginCallback: `${baseUrl}/${LoginActions.LoginCallback}`,
    SignIn: `${baseUrl}/${LoginActions.SignIn}`,
    LogOut: `${baseUrl}/${LogoutActions.Logout}`,
    LoggedOut: `${baseUrl}/${LogoutActions.LoggedOut}`,
    LogOutCallback: `${baseUrl}/${LogoutActions.LogoutCallback}`,
}
export type ApiAutorizationPath = (typeof ApiAutorizationPaths)[keyof typeof ApiAutorizationPaths];