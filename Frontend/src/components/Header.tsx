import {
    useColorMode,
    useColorModeValue,
    IconButton,
    Flex,
    Icon,
    Spacer,
    Link,
} from '@chakra-ui/react';
import { SunIcon, MoonIcon } from '@chakra-ui/icons';
import { FaGithub } from "react-icons/fa";
import NavMenu from './NavMenu';

const GitHubIconButton = () => {
    return (
        <Link href="https://github.com/shunmaruko/ASP.NET-React-WebApp" isExternal>
            <IconButton aria-label="view source code on github" icon={<Icon as={FaGithub} />} >
            </IconButton>
        </Link>
    )
}

const ColorModeToggle = () => {
    const { toggleColorMode } = useColorMode();
    const Icon = useColorModeValue(MoonIcon, SunIcon);
    return (
          <IconButton aria-label="dark/light mode" icon={<Icon />} onClick={toggleColorMode} >
          </IconButton>
    );
}

const Header = () => {
    return (
        <Flex>
            <NavMenu />
            <Spacer />
            <GitHubIconButton />
            <ColorModeToggle />
        </Flex>
    );
}
export default Header;