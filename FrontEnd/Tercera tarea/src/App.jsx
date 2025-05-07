
import { Provider } from 'react-redux'; // Importamos el Provider de Redux
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Importamos React Router
import Store from './storage/store'; // Importamos el store
import Counter from './components/counter'; // Componente que muestra el contador
import About from './components/about'; // Componente "Acerca de"

const App = () => {
  return (
    <Provider store={Store}> {/* Proveemos el store de Redux a la app */}
      <Router> {/* Configuramos el enrutamiento con React Router */}
        <Routes>
          <Route path="/" element={<Counter />} /> {/* Ruta para el contador */}
          <Route path="/about" element={<About />} /> {/* Ruta para "Acerca de" */}
        </Routes>
      </Router>
    </Provider>
  );
};

export default App;
