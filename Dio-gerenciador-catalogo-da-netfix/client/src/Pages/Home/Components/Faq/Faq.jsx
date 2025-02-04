import './Faq.css'
import React, { useState } from 'react';

export default  (props) =>{
    
  // Inicializando o estado para controlar a visibilidade do conteúdo
  const [isOpen, setIsOpen] = useState(false);

  // Função para alternar a visibilidade
  const toggleContent = () => {
    setIsOpen(!isOpen); // Altera o estado entre true e false
  };

  return (
    <div className="faq">
      <div className="faq-header">
        <h3>{props.title}</h3> {/* Recebe o título via props */}
        <button className="faq-toggle" onClick={toggleContent}>
          {isOpen ? '-' : '+'} {/* Alterna entre + e - */}
        </button>
      </div>
      {/* Exibe o conteúdo apenas se isOpen for true */}
      {isOpen && (
        <div className="faq-content">
          <p>{props.content}</p> {/* Exibe o conteúdo da FAQ */}
        </div>
      )}
    </div>
  );
};