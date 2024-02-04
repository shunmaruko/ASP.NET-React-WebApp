import { LoginActions, LoginAction } from './ApiAuthorizationConstants'
import { signInCallback } from './ApiAuthorizationService';
export const Login = (loginAction: LoginAction) => {
    console.log(loginAction);
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
    console.log("login callback");
    return signInCallback();
}
const redirectToSignIn = () => {
    console.log("redirect to sing in")
}