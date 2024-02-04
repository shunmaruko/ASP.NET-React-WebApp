import LoginView from './components/api-auth/LoginView';
import ApiAuthorzationRoutes from './components/api-auth/ApiAuthorizationRoutes';

const TestComponent = () => {
    return (
        <>
            "test"
        </>
    )
};
const AppRoutes = [
    {
        index: true,
        element: <LoginView />

    },
    {
        path: '/Test', 
        element: <TestComponent />
    },
    ...ApiAuthorzationRoutes
]

export default AppRoutes;