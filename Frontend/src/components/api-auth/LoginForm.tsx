import { useState } from 'react';
import {
    Flex,
    Heading,
    Input,
    Button,
    Link,
    Box,
    FormControl,
    FormLabel,
    useColorModeValue,
} from '@chakra-ui/react';
import { ColorModes, ColorSchemes} from '../ColorTheme';

const loginStates = {
    login: "login",
    signup: "singnup"
}
type loginState = (typeof loginStates)[keyof typeof loginStates];

type FormProps = {
    setLoginState: React.Dispatch<React.SetStateAction<loginState>>;
};

const LoginForm = (props: FormProps) => {
    const { setLoginState } = props; 
    const formBackgroundColor = useColorModeValue(ColorModes.paleTheme.light, ColorModes.paleTheme.dark);
    const title = "Log In";
    return (
        <Flex h="100vh" alignItems="center" justifyContent="center">
            <Flex
                flexDirection="column"
                p={12}
                bg={formBackgroundColor}
                borderRadius={8}
                boxShadow="lg"
            >
                <Heading mb={6}>{title}</Heading>
                <FormControl isRequired >
                    <FormLabel>Email address</FormLabel>
                    <Input
                        placeholder="*******@gmail.com"
                        type="email"
                        variant="filled"
                        mb={3}
                    />
                </FormControl>
                <FormControl isRequired>
                    <FormLabel>Password</FormLabel>
                    <Input
                        placeholder="**********"
                        type="password"
                        variant="filled"
                        mb={6}
                        aria-describedby="password-helper-text"
                    />
                </FormControl>
                <Button colorScheme={ColorSchemes.Teal} mb={8}>
                    {title}
                </Button>
                <Box>
                    New to us?{" "}
                    <Link color="teal.500" href="#" onClick={() => {
                        setLoginState(loginStates.signup);
                    }}>
                        Sign Up
                    </Link>
                </Box>
                <Box>
                    Forgot password?{" "}
                    <Link color="teal.500" href="#" >
                        Reset
                    </Link>
                </Box>
            </Flex>
        </Flex>
    );
}

const SignUpForm = (props: FormProps) => {
    const { setLoginState } = props; 
    const formBackgroundColor = useColorModeValue(ColorModes.paleTheme.light, ColorModes.paleTheme.dark);
    const title =  "Sign Up";
    return (
        <Flex h="100vh" alignItems="center" justifyContent="center">
            <Flex
                flexDirection="column"
                p={12}
                bg={formBackgroundColor}
                borderRadius={8}
                boxShadow="lg"
            >
                <Heading mb={6}>{title}</Heading>
                <FormControl isRequired >
                    <FormLabel>Email address</FormLabel>
                    <Input
                        placeholder="*******@gmail.com"
                        type="email"
                        variant="filled"
                        mb={3}
                    />
                </FormControl>
                <FormControl isRequired>
                    <FormLabel>Password</FormLabel>
                    <Input
                        placeholder="**********"
                        type="password"
                        variant="filled"
                        mb={6}
                        aria-describedby="password-helper-text"
                    />
                </FormControl>
                <FormControl isRequired>
                    <FormLabel>Comfirm Password</FormLabel>
                    <Input
                        placeholder="**********"
                        type="password"
                        variant="filled"
                        mb={6}
                        aria-describedby="password-helper-text"
                    />
                </FormControl>
                <Button colorScheme={ColorSchemes.Teal} mb={8}>
                    {title}
                </Button>
                <Box>
                    Already have account?{" "}
                    <Link color="teal.500" href="#" onClick={() => {
                        setLoginState(loginStates.login);
                    }}>
                        Log In
                    </Link>
                </Box>
            </Flex>
        </Flex>
    );

}
const LoginOrSignInForm = () => {
    const [loginState, setLoginState] = useState<loginState>(loginStates.login);
    const isLogIn = loginState == loginStates.login;
    return (
        <>
            {isLogIn ? <LoginForm setLoginState={setLoginState} /> : <SignUpForm setLoginState={setLoginState} />}
        </>
        
    )
};

export default LoginOrSignInForm;
