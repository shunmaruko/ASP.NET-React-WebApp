import { extendTheme, type ThemeConfig } from '@chakra-ui/react'

// color mode config
const config: ThemeConfig = {
    initialColorMode: 'dark',
    useSystemColorMode: false,
}
// Confirm default color mode is dark.
// For the detail, see https://github.com/chakra-ui/chakra-ui/discussions/5051
if (!localStorage.getItem("chakra-ui-color-mode")) {
    localStorage.setItem("chakra-ui-color-mode", "dark");
}
// extend the theme
const theme = extendTheme({ config })

export default theme