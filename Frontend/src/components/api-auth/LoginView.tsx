//import { useState } from 'react'

const LoginView = () => {
    //const [isAutheticated, setIsAutheticated] = useState(false);
    const isAutheticated = false;
    return (
            isAutheticated ? authenticatedView() : annonymousView()
    )
}

const authenticatedView = () => {
    return (
        <>
            "Login view"
        </>
  )
}

const annonymousView = () => {
    return (
        <>
            "Annonymous view"
        </>
    )
}

export default LoginView;