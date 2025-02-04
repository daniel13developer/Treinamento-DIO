import logo from '../../assets/logo.png';
import globo from '../../assets/globo.png';
import './Home.css';
import Curve from './Components/Curve/Curve';
import Pipoca from '../../assets/netflix-svg/pipoca';
import Carousel from './Components/Carousel/Carousel';
import Faq from './Components/Faq/Faq';

import Televisao from '../../assets/netflix-svg/televisao'
import BaixarSeries from '../../assets/netflix-svg/baixar_series'
import Lupa from '../../assets/netflix-svg/lupa'
import Perfis from '../../assets/netflix-svg/perfis'
import { useNavigate } from 'react-router-dom';


export default (props) => {
  const navigate = useNavigate();

  function handleVamosLa (){
    navigate('/login');
  }
  
  return (
    <>
      <div id="Home">
        <div className="opactity_controller">
          <header>
            <img src={logo} alt="logo" />
          </header>

          <div className="content">
            <h1>Filmes, séries e muito mais, sem limites</h1>
            <h2>A partir de R$ 20,90. Cancele quando quiser.</h2>
            <h3>Quer assistir? Informe seu email para criar ou reiniciar sua assinatura.</h3>
            <input type="text" placeholder="Email" />
            <button className='button-patter' onClick={handleVamosLa}>Vamos lá {'>'}</button>
          </div>

          <div className="default-ltr-cache-dulgtd">
            <Curve />
          </div>

          <div className="dark-body">

            <div className='pop-card'>
              <Pipoca />

              <div className='pop-card-container'>
                <div>
                  <h1>A Netflix que você adora por apenas R$ 20,90. </h1>
                  <h2>Aproveite nossa opção mais acessível, o plano com anúncios.</h2>
                </div>
                
                <button className='saiba-mais'>Saiba Mais</button>
              </div>

            </div>
          </div>

          {/* inicio catalogo */}
          <div className="dark-body em-alta">
            <div className='faq-home-content'>
              <h1>Em Alta</h1>

              <select className="row-select-dropdown">
                <option label="Brasil" value="Brasil">Brasil</option>
                <option label="Global" value="global">Global</option>
              </select>

              <select className="row-select-dropdown">
                <option label="Filmes" value="">Filmes</option>
                <option label="Global" value="global">Global</option>
              </select>
            </div>

          </div>

          <div className='background-black'>
            <Carousel /> {/* Aqui estamos usando o carrossel */}
          </div>

          <div className='background-black color-white'>
            <div className='card-content'>
              <div className='card'>
                <h1>Aproveite na TV</h1>
                <span>Assista em Smart TVs, PlayStation, Xbox, Chromecast, Apple TV, aparelhos de Blu-ray e outros dispositivos.</span>
                <div className='margin-end'>
                  <Televisao />
                </div>
              </div>
              <div className='card'>
                <h1>Baixe séries para assistir offline</h1>
                <span>Salve seus títulos favoritos e sempre tenha algo para assistir.</span>

                <div className='margin-end'>
                  <BaixarSeries />
                </div>
              </div>
              <div className='card'>
                <h1>Assista onde quiser</h1>
                <span>Assista a quantos filmes e séries quiser no celular, tablet, laptop e TV.</span>

                <div className='margin-end'>
                  <Lupa />
                </div>
              </div>
              <div className='card'>
                <h1>Crie perfis para crianças</h1>
                <span>Deixe as crianças se aventurarem com seus personagens favoritos em um espaço feito só para elas, sem pagar a mais por isso.</span>
                <div className='margin-end'>
                  <Perfis />
                </div>
              </div>
            </div>
          </div>

          <div className='background-black color-white'>
            <div className='faq-home-content'>
            <h1>Perguntas frequentes</h1>
              <Faq
                title="O que é a Netflix?"
                content="A Netflix é um serviço de streaming que oferece uma ampla variedade de séries, filmes e documentários premiados em milhares de aparelhos conectados à internet. ocê pode assistir a quantos filmes e séries quiser, quando e onde quiser – tudo por um preço mensal acessível. Aqui você sempre encontra novidades. A cada semana, adicionamos novas séries e filmes."
              />
              <Faq
                title="Quanto custa a Netflix?"
                content="Assista à Netflix no seu celular, tablet, Smart TV, notebook ou aparelho de streaming por uma taxa mensal única. Os planos variam de R$ 20,90 a R$ 59,90 por mês. Sem contrato nem taxas extras."
              />
              <Faq
                title="Onde posso assistir?"
                content="Assista onde quiser, quando quiser. Acesse sua conta Netflix em netflix.com para assistir no computador ou em qualquer aparelho conectado à internet compatível com o aplicativo Netflix, como Smart TVs, smartphones, tablets, aparelhos de streaming e videogames."
              />
              <Faq
                title=" Como faço para cancelar?"
                content="A Netflix é flexível. Não há contratos nem compromissos. Você pode cancelar a sua conta na internet com apenas dois cliques. Não há taxa de cancelamento – você pode começar ou encerrar a sua assinatura a qualquer momento."
              />
              <Faq
                title="O que eu posso assistir na Netflix?"
                content="A Netflix tem um grande catálogo de filmes, documentários, séries, originais Netflix premiados e muito mais. Assista o quanto quiser, quando quiser."
              />
              <Faq
                title="A Netflix é adequada para crianças?"
                content="A experiência infantil da Netflix faz parte da sua assinatura para que as crianças se divirtam em seu próprio espaço com séries e filmes familiares sob a supervisão dos responsáveis. O recurso de controle parental, incluso nos perfis para crianças e protegido por PIN, permite restringir a classificação etária do conteúdo que as crianças podem ver e bloquear títulos específicos que você não quer que elas assistam."
              />
            </div>
          </div>

      <div className='background-black text-color'>
        <div className='faq-home-content'>
        <span>Quer assistir? Informe seu email para criar ou reiniciar sua assinatura.</span>
        <button className='button-patter'>Vamos lá {'>'}</button>
        </div>
      </div>

          <footer>
            <p>Dúvidas? Ligue <a>0000-000-0000</a></p>

            <ul>
              <li>Termos dos Cartões pré-pagos</li>
              <li>Termos de uso</li>
              <li>Declaração de privacidade</li>
            </ul>

            <div>
              <img src={globo} alt="globo" />
              <select name="select" id="select">
                <option value="a">Português</option>
                <option value="b">Inglês</option>
              </select>
            </div>
          </footer>
        </div>
      </div>
    </>
  );
};
