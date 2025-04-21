import banner from '../assets/beltanebanner.png';

const Banner = ({ width = '100%', height = '100%', alt = 'Banner' }) => {
  return (
    <img
      src={banner} // Usamos la importación de la imagen
      alt={alt}
      className="hero-bg"
      style={{
        width: width,
        height: height,
        objectFit: 'cover',
        display: 'block',
      }}
    />
  );
};

export default Banner;
