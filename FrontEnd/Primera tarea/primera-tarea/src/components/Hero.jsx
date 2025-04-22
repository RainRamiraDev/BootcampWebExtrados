import './Hero.css';
import Banner from './banner';
import Usuario from './Usuario';

function Hero() {
    const nombre = "Jorge";     // 🧠 Creamos una variable "nombre" que se va a pasar como prop
    const edad = 30;            // 🎂 Otra prop con un número entero
    const activo = true;        // ✅ Una prop booleana que podría activar un renderizado condicional

    return (
        <section className='hero'>
            <Banner width="100%" height="100%" alt="Banner" />
            <div className='hero-content'>
                <h1>Bienvenido a mi Landing Page!</h1>
                <p>Esta es una página para la tarea número 1 del bootcamp.</p>
                <a href="#contacto" className='hero-btn'>Contáctame</a>
            </div>
            <Usuario nombre={nombre} edad={edad} activo={activo} />
        </section>
    );
}

export default Hero;
