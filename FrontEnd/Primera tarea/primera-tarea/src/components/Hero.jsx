import './Hero.css';

function Hero(){
    return(
        <section className='hero'>
            <div className='hero-content'>
            <h1>Bienvenido a mi Landing Page!</h1>
            <p>Esta es una pagina para la tarea numero 1 del bootcamp.</p>
            <a href="#contacto" className='hero-btn'>Contáctame</a>
            </div>
        </section>
    );
}

export default Hero;