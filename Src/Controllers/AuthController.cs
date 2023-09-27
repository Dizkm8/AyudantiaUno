using AyudantiaUno.Src.DTO;
using AyundatiaUno.Src.Data;
using AyundatiaUno.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AyudantiaUno.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        // Inyectamos el contexto para poder acceder a la base de datos
        public AuthController(DataContext context)
        {
            // Guardamos en un atributo para utilizarlo cuando lo necesitemos
            _context = context;
        }

        // La ruta es localhost:5267/api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterClientDto registerClientDto)
        {
            // Generamos la sal
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            // Encriptamos la contraseña
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerClientDto.Password, salt);
            // Traspasamos la información del DTO al nuevo usuario a crear
            var user = new User()
            {
                Rut = registerClientDto.Rut,
                Email = registerClientDto.Email,
                Name = registerClientDto.Name,
                Password = passwordHash,
                // El id de rol del usuario debe coincidir con el de cliente
                // más adelante vamos a utilizar una manera más elegante
                RoleId = 2
            };
            // Agregamos el nuevo usuario
            await _context.Users.AddAsync(user);
            // Guardamos los cambios
            await _context.SaveChangesAsync();
            // IMPORTANTE: Actualmente devolvemos el emaill, pero se deberia devolver la información
            // y su JWT
            return registerClientDto.Email;
        }

        // La ruta es localhost:5267/api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto loginUserDto)
        {
            // Buscar al usuario por email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUserDto.Email);

            // Si el usuario es nulo es porque no existe, así que retornamos credenciales inválidas  -> Http 400 BadRequest
            // NO RETORNAR que el correo es inválido, ya que expone a tus usuarios
            if (user is null) return BadRequest("Invalid Credentials");

            // Comparamos la clave ingresada con la clave guardad en la base de datos
            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password);

            // Si no coinciden entonces retornamos credenciales inválidas -> Http 400 BadRequest
            if(!result) return BadRequest("Invalid Credentials");
            
            // IMPORTANTE: Actualmente devolvemos el email, pero se deberia devolver la información
            // y su JWT
            return "logged";
        }
    }
}