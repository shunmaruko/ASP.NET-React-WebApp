import { Container } from '@chakra-ui/react';
import Header from './Header';

type Props = {
    children: JSX.Element;
};
const Layout = (props: Props) => {
    return (
        <>
            <Header />
            <Container>
                {props.children}
            </Container>
        </>
        
    )
}

export default Layout