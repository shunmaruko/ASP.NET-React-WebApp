import { Flex, Spacer } from '@chakra-ui/react'
import ColorModeToggle from "./ColorModeToggle"
import NavMenu from './NavMenu'

const Header = () => {
    return (
        <Flex>
            <NavMenu />
            <Spacer />
            <ColorModeToggle />
        </Flex>
    );
}
export default Header;