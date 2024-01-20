import { useEffect } from 'react';
import { LogoutActions, LogoutAction } from './ApiAuthorizationConstants'

export const Logout = (logoutAction: LogoutAction) => {
    //const [,] = useState<LoginAction | null >(null);
    useEffect(() => {
        switch (logoutAction) {
            case LogoutActions.Logout:
                onLogout(); break;
            case LogoutActions.LoggedOut:
                onLoggedOut(); break;
            case LogoutActions.LogoutCallback:
                onLogoutCallback(); break;
            default:
                throw new Error(`Invalid action '${logoutAction}'`);
        }
    }, [logoutAction])
    return (
        <>{logoutAction}</>
    )
}
const onLogout = () => {
    console.log("logout action")
}
const onLoggedOut = () => {
    console.log("login action failed")
}
const onLogoutCallback = () => {
    console.log("logout callback")
}