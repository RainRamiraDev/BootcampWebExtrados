import './Header.css';
import Logo from './Logo';  // Importa el nuevo componente

function Header() {
  return (
    <header className='header'>
      <div className='logo'>
      <Logo />
      </div>
      <nav className='nav'>
        <ul>
            <li><a href='#inicio'>Inicio</a></li>
            <li><a href='#sobre'>Nosotros</a></li>
            <li><a href='#contacto'>Contacto</a></li>
        </ul>
      </nav>
    </header>
  );
}

export default Header;
