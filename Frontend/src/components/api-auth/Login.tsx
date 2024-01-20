import { useEffect } from 'react';
import { LoginActions, LoginAction } from './ApiAuthorizationConstants'

export const Login = (loginAction: LoginAction) => {
    //const [,] = useState<LoginAction>(LoginActions.LoginFailed);
    useEffect(() => {
        switch (loginAction) {
            case LoginActions.Login:
                onLogin(); break;
            case LoginActions.LoginCallback:
                onLoginCallback(); break;
            case LoginActions.SignIn:
                redirectToSignIn(); break;
            case LoginActions.LoginFailed:
                onLoginFailed(); break;
            default:
                throw new Error(`Invalid action '${loginAction}'`);
        }
    }, [loginAction])
    return(
        <>{loginAction}</>
    )
}
const onLogin = () => {
    console.log("login action")
}
const onLoginFailed = () => {
    console.log("login action failed")
}
const onLoginCallback = () => {
    console.log("login callback")
}
const redirectToSignIn = () => {
    console.log("redirect to sing in")
}