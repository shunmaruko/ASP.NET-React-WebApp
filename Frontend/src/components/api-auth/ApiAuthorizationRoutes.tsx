
//import { Logout } from './Logout'
import { ApiAutorizationPaths, LoginActions, LogoutActions } from './ApiAuthorizationConstants';
import { Login } from './Login'
import { Logout } from './Logout'


const ApiAuthorizationRoutes = [
    {
        path: ApiAutorizationPaths.Login,
        element: Login(LoginActions.Login)
    },
    {
        path: ApiAutorizationPaths.LoginFailed,
        element: Login(LoginActions.LoginFailed)
    },
    {
        path: ApiAutorizationPaths.LoginCallback,
        element: Login(LoginActions.LoginCallback)
    },
    {
        path: ApiAutorizationPaths.SignIn,
        element: Login(LoginActions.SignIn)
    },
    {
        path: ApiAutorizationPaths.LogOut,
        element: Logout(LogoutActions.Logout)
    },
    {
        path: ApiAutorizationPaths.LogOutCallback,
        element: Logout(LogoutActions.LogoutCallback)
    },
    {
        path: ApiAutorizationPaths.LoggedOut,
        element: Logout(LogoutActions.LoggedOut)
    }
];

export default ApiAuthorizationRoutes;

