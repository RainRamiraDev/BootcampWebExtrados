import './Hero.css';
import Banner from './banner';

function Hero() {
    return (
        <section className='hero'>
            <Banner width="100%" height="100%" alt="Banner" />
            <div className='hero-content'>
                <h1>Bienvenido a mi Landing Page!</h1>
                <p>Esta es una página para la tarea número 1 del bootcamp.</p>
                <a href="#contacto" className='hero-btn'>Contáctame</a>
            </div>
        </section>
    );
}

export default Hero;
