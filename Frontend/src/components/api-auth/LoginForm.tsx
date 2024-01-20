import {
    Flex,
    Heading,
    Input,
    Button,
    Link,
    Box,
    FormHelperText,
    FormControl,
    FormLabel,
    useColorModeValue,
} from '@chakra-ui/react';

const LoginForm = () => {
    const formBackground = useColorModeValue('gray.200', 'gray.700');
    return (
        <Flex h="100vh" alignItems="center" justifyContent="center">
            <Flex
                flexDirection="column"
                p={12}
                bg={formBackground}
                borderRadius={8}
                boxShadow="lg"
            >
                <Heading mb={6}>Log In</Heading>
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
                <FormHelperText id="password-helper-text">Forgot password?</FormHelperText>
                </FormControl>
                <Button colorScheme="teal" mb={8}>
                    Log In
                </Button>
                <Box>
                    New to us?{" "}
                    <Link color="teal.500" href="#">
                        Sign Up
                    </Link>
                </Box>
                <Box>
                   Forgot password?{" "}
                    <Link color="teal.500" href="#">
                        Reset
                    </Link>
                </Box>
            </Flex>
        </Flex>
    );
};

export default LoginForm;
