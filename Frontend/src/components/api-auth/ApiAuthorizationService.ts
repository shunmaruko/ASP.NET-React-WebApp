/* eslint-disable @typescript-eslint/no-explicit-any */
import { UserManager, UserManagerSettings, User, Log } from 'oidc-client-ts';
import { ApplicationName, ApiAutorizationPaths } from './ApiAuthorizationConstants'
Log.setLogger(console);
Log.setLevel(Log.DEBUG);

const setting = {
    authority: ApiAutorizationPaths.ServerUrl,
    client_id: ApplicationName,
    redirect_uri: ApiAutorizationPaths.LoginCallback,
    post_logout_redirect_uri: ApiAutorizationPaths.LogOutCallback,
    automaticSilentRenew: true,
    silentRequestTimeout: 30,
    scope: "BackendAPI openid profile"
} as UserManagerSettings;

const userManager = new UserManager(setting);

type UserInfo = {
    isAuthorized: boolean,
    user: User,
    access_token: string,
}
const AuthenticationResultStatuses = {
    Redirect: 'redirect',
    Success: 'success',
    Fail: 'fail'
};

type AuthenticationResultStatus = (typeof AuthenticationResultStatuses)[keyof typeof AuthenticationResultStatuses];

const error = (): AuthenticationResultStatus => {
    return AuthenticationResultStatuses.Fail;
}
const success = (): AuthenticationResultStatus => {
    return AuthenticationResultStatuses.Success;
}
const redirect = (): AuthenticationResultStatus => {
    return AuthenticationResultStatuses.Redirect;
}

let userInfo: UserInfo | null = null;

const updateUserInfo = (user: User | null | void) => {
    const newUserinfo = {
        isAuthorized: !!user,
        user: user,
        access_token: user?.access_token,
     } as UserInfo;
    userInfo = newUserinfo;
};

const signIn =  async () => {
    console.log("try signin silent");
    try {
            const response = await fetch(ApiAutorizationPaths.ApiAuthorizationClientConfigurationUrl, {
                headers: {
                    mode: 'cors',
                }
            });
            if (!response.ok) {
                throw new Error(`Could not load settings for '${ApplicationName}'`);
            }
            console.log(response.json());
            const user = await userManager.signinSilent();
            console.log(user);
            updateUserInfo(user);
            console.log("try signin suceed");
            return success();
        } catch (err: any) {
            console.log(err.message);
            console.log("try signIn redirect");
            try {
                //await userManager.signinRedirect();
                console.log("succeed redirect");
                return redirect();
            } catch (err: any) {
                console.log(err.message);
                return error();
            }
        }        
};
const signInCallback = async (): Promise<AuthenticationResultStatus> => {
        try {
            const user = await userManager.signinCallback(ApiAutorizationPaths.LoginCallback);
            updateUserInfo(user);
            return success();
        } catch (err: any) {
            return error();
        }
}
const signOut = async (): Promise<AuthenticationResultStatus> => {
        try {
            const user = await userManager.signoutSilent();
            updateUserInfo(user);
            return success();
        } catch (err: any) {
            console.log("singout err");
            try {
                await userManager.signoutRedirect();
                return redirect();
            } catch (err: any) {
                console.log("callback error");
                return error();
            }


        }
};
const signOutCallback = async(): Promise<AuthenticationResultStatus> => {
        try {
            await userManager.signoutCallback(ApiAutorizationPaths.LogOutCallback);
            updateUserInfo(null);
            return success();
        } catch (err: any) {
            console.log("There was an error trying to log out")
            return error();
        }
}
const getUserInfo = async (): Promise<UserInfo | null> => {
    userManager.getUser()
        .then((user: User | null) => {
            console.log("succeed to get user");
            updateUserInfo(user);
        })
        .catch((err) => {
            console.error(err);
        }).finally(() => {
            return userInfo;
        });
}; 

export { signIn, signInCallback, signOut, signOutCallback, getUserInfo, AuthenticationResultStatuses};
export type { AuthenticationResultStatus };
