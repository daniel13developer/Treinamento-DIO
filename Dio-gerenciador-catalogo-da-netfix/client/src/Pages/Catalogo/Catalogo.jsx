import './Catalogo.css'
import logo from '../../assets/logo.png';
import React, { useState, useEffect } from 'react';
import axios from 'axios'; // Importando o axios
import api from './Services/Api';
import Modal from './Components/Modal/Modal'
export default (props) => {
  const [filmesPorCategoria, setFilmesPorCategoria] = useState({});

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalContent, setModalContent] = useState({ title: 'teste', body: 'teste' });

  // Função para abrir a Modal com conteúdo dinâmico
  const openModal = (title, body) => {
    setModalContent({ title, body });
    setIsModalOpen(true);
  };

  // Função para fechar a Modal
  const closeModal = () => {
    setIsModalOpen(false);

    fetchFilmes();
  };
  
  const li = (
    <div className='primary-color' style={{ paddingLeft: '150px', paddingRight: '150px' }}>
      <Modal isOpen={isModalOpen} onClose={closeModal} />

      <div>
        {Array.isArray(filmesPorCategoria) && filmesPorCategoria.length > 0 ? (
          filmesPorCategoria.map((categoria) => (
            <div key={categoria.nomeDoGrupo} style={{ marginBottom: '30px' }}>
              <h2 style={{ textAlign: 'start', color: 'red' }}>{categoria.nomeDoGrupo}</h2>
              <div style={{ display: 'flex', flexWrap: 'wrap',     gap: '20px' }}>
                {categoria.filmes.map((filme, index) => (
                  <div key={filme.id} style={{ marginBottom: '20px', textAlign: 'center', width: '150px' }}>
                    <img
                      src={filme.url}
                      alt={filme.nome}
                      style={{ width: '100%', height: 'auto', borderRadius: '8px', marginBottom: '10px' }}
                    />
                    <span>{filme.nome}</span>
                  </div>
                ))}
              </div>
            </div>
          ))
        ) : (
          <p>Carregando filmes...</p>
        )}
      </div>
    </div>
  );

  // Usando o useEffect para fazer a chamada à API assim que o componente for montado
  useEffect(() => {
    fetchFilmes();
  }, []); // O array vazio faz a chamada apenas uma vez quando o componente monta


const fetchFilmes = async () => {
  try {
    // Supondo que sua API retorne os filmes agrupados por categoria.
    await api.get("catalogo").then((response) => {
      setFilmesPorCategoria(response.data);
    });

    // const data = await response.json();

    // Atualizando o estado com os dados recebidos
    // setFilmesPorCategoria(data);
  } catch (error) {
    console.error('Erro ao buscar filmes:', error);
  }
};

  return (
    <>
    <div className="catalogo-content">
    <header>
            <img src={logo} alt="logo" />
    </header>

    <div className='cabecalho'>
    <button onClick={() => openModal('teste', 'Mais informações sobre o filme!')} className='button-patter'>
  Adicionar
</button>
    </div>

    <div>
      {li}
    </div>
    <div>

    </div>
      </div>
    </>
  );
};
