import { useState } from 'react';
import './App.css';
import LoginForm from './components/api-auth/LoginForm';
import LoginView from './components/api-auth/LoginView';
import Layout from './components/Layout';
//import { Route, Routes } from 'react-router-dom';
//import AppRoutes from './AppRoutes';
//<Routes>
//    {AppRoutes.map((route, index) => {
//        const { element, ...rest } = route;
//        return <Route key={index} {...rest} element={element} />;
//    })}
//</Routes>
function App() {
  const [count, setCount] = useState(0)
    return (
        <Layout>
          <>
              <LoginForm />
              <LoginView />
              <div className="card">
                  <button onClick={() => setCount((count) => count + 1)}>
                      count is {count}
                  </button>
                  <p>
                      Edit <code>src/App.tsx</code> and save to test HMR
                  </p>
              </div>
            </>
        </Layout>
  )
}

export default App
