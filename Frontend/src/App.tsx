import './App.css';
import { Route, Routes, BrowserRouter } from 'react-router-dom';
import Layout from './components/Layout';
import AppRoutes from './AppRoutes';

function App() {
    return (
        <Layout>
            <>
              <BrowserRouter>
                <Routes>
                   {AppRoutes.map((route, index) => {
                     const { element, ...rest } = route;
                      return <Route key={index} {...rest} element={element} />;
                  })}
                </Routes>
              </ BrowserRouter>
            </>
        </Layout>
  )
}

export default App
