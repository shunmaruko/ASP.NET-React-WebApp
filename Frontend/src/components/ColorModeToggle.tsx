import { useColorMode, useColorModeValue, IconButton } from '@chakra-ui/react';
import { SunIcon, MoonIcon } from '@chakra-ui/icons';

const ColorModeToggle = () => {
    const { toggleColorMode } = useColorMode();
    const Icon = useColorModeValue(MoonIcon, SunIcon);
    return (
        <IconButton aria-label="dark/light mode" icon={<Icon/>} onClick= { toggleColorMode } >
        </IconButton>
    )
}

export default ColorModeToggle;
