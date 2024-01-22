import { useEffect, useState } from 'react'
import { getUserInfo } from './ApiAuthorizationService'
import LoginOrSignInForm from './/LoginForm';

const LoginView = () => {
    const [isAutheticated, setIsAutheticated] = useState<boolean>(false);
    useEffect(() => {
        async () => {
            const userInfo = await getUserInfo();
            if (userInfo?.isAuthorized) {
                setIsAutheticated(userInfo.isAuthorized);
            }
        }
    }, [])
    return (
            isAutheticated ? authenticatedView() : annonymousView()
    )
}

const authenticatedView = () => {
    return (
        <>
            "Logged in  view"
        </>
  )
}

const annonymousView = () => {
    return (
        <>
            <LoginOrSignInForm />
        </>
    )
}

export default LoginView;