import React, { useState } from 'react';
import api from '../../Services/Api'
import './Modal.css'

// Componente Modal
const Modal = ({ isOpen, onClose, content }) => {
 // 1. Definindo o estado para armazenar o valor do input
 const [nomeFilmeValue, setNomeFilmeValue] = useState('');
 const [generoFilmeValue, setGeneroFilmeValue] = useState('');

 // 2. Função para lidar com a mudança no input
 const handleNomeFilmeChange = (event) => {
   // Atualiza o estado com o novo valor do input
   setNomeFilmeValue(event.target.value);
  };

  const handleGeneroFilmeChange = (event) => {
    // Atualiza o estado com o novo valor do input
    setGeneroFilmeValue(event.target.value);
  };
 

// Estado para armazenar o arquivo selecionado
const [selectedFile, setSelectedFile] = useState(null);

// Função que é chamada quando o arquivo é selecionado
const handleFileChange = (event) => {
  const file = event.target.files[0]; // Pega o primeiro arquivo selecionado
  setSelectedFile(file);
};

  // Função para enviar o arquivo (exemplo, você pode integrar com uma API ou backend)
  const handleFileUpload = async () => {
    if (selectedFile) {
      // Aqui você pode fazer o upload do arquivo, por exemplo, enviar para um servidor
      console.log('Arquivo selecionado:', selectedFile);

      const formData = new FormData();
      formData.append('file', selectedFile); // Adiciona o arquivo
      formData.append('movieName', nomeFilmeValue); // Adiciona o nome do filme
      formData.append('genre', generoFilmeValue); // Adiciona o gênero

      try{
        await api.post("/upload", formData).then((response) => {
          onClose()
      });
      }
      catch(error)
      {
        console.error('Erro ao publicar filme:', error);
      }

    } else {
      alert('Por favor, selecione um arquivo primeiro');
    }
  };

  if (!isOpen) return null;  // Não renderiza a modal se isOpen for falso

  return (
    <div className="modalOverlayStyle">
      <div className='header-model'>
        <h2>Selecione um arquivo para upload</h2>
        <button className="close-modal" onClick={onClose}>x</button>
        </div>
      <div className="modalContentStyle">
        <input 
        className='inputFile'
        type="file" 
        onChange={handleFileChange} 
        />
        <span>Nome do filme</span>
        <input type="text" placeholder="Genero do filme"  onChange={handleGeneroFilmeChange}  value={generoFilmeValue}/>
        <input type="text" placeholder="Nome do filme"  onChange={handleNomeFilmeChange}  value={nomeFilmeValue}/>
        <button className='inputFile button-patter' onClick={handleFileUpload}>Confirmar</button>
      </div>
    </div>
  );
};

export default Modal;
