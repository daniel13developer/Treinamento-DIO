import { Routes, Route } from 'react-router-dom';

import Login from './Login/Login'
import Home from './Home/Home'
import NotFound from './NotFound/NotFound';
import Catalogo from './Catalogo/Catalogo';

const Content = props => (
    <main className="Content">
      {/* Toda essa parte está diferente da do professor, analisem as diferenças */}
      <Routes>
        <Route path="/login" element={<Login />} />
        {/* <Route path="/param/:id" element={<Param />} /> */}
        <Route path="/" exact element={<Home />} />
        {/* <Route path="*" element={<NotFound />} /> */}
        <Route path="*" element={<NotFound />} />
        <Route path="/catalogo" element={<Catalogo />} />
      </Routes>
      {/* --------------------------------------------------- */}
    </main>
  );
   
  export default Content;