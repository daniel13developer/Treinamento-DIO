import React, { useState } from 'react';
import './Carousel.css';
import imagem1 from '../../../../assets/top10/1.webp'
import imagem2 from '../../../../assets/top10/2.webp'
import imagem3 from '../../../../assets/top10/3.webp'
import imagem4 from '../../../../assets/top10/4.webp'
import imagem5 from '../../../../assets/top10/5.webp'
import imagem6 from '../../../../assets/top10/6.webp'
import imagem7 from '../../../../assets/top10/7.webp'
import imagem8 from '../../../../assets/top10/8.webp'
import imagem9 from '../../../../assets/top10/9.webp'
import imagem10 from '../../../../assets/top10/10.webp'

const Carousel = () => {
  const [currentIndex, setCurrentIndex] = useState(0);

  // Defina as imagens para o carrossel
  const [images, setImages] = useState([
    imagem1,
    imagem2,
    imagem3,
    imagem4,
    imagem5,
    imagem6,
    imagem7,
    imagem8,
    imagem9,
    imagem10
  ]);

  const nextSlide = () => {
    
    if (currentIndex === images.length - 1) {
      setCurrentIndex(0); // Vai para o início quando chega ao final
    } else {
      setCurrentIndex(1);
    }

    orderList();
  };

  const orderList = () => {
    setImages()
  };

  const divImages = images.map((image, i) => {
    return <img src={image} alt={`imagem ${i + 1}`} className="carousel-image" />
})

  return (
    <div className='carousel'>
    <div className="carousel-container">
      <div className="carousel-slide">
        {divImages}
      </div>
      <button className="carousel-image carousel-button">❯</button>
        </div>

    </div>
  );
};

export default Carousel;
