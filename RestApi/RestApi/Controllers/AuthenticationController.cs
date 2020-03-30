using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using EmailService;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IEmailSender _emailSender;

        public AuthenticationController(UserManager<User> userManager, IMapper mapper, IAuthenticationManager authManager, IEmailSender emailSender)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { confirmationToken, email = user.Email }, Request.Scheme);

            var message = new Message(new string[] { user.Email }, "Account confirmation email link", confirmationLink);

            await _emailSender.SendEmailAsync(message);

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return BadRequest("User with such e-mail doesn't exist.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Redirect("http://localhost:4200/home");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized(new { error = "Wrong email or password" });
            }

            var token = await _authManager.CreateToken();

            var userId = await _authManager.GetUserId(user.Email);

            var expirationDate = _authManager.GetExpirationDate(token);
            
            if(!await _authManager.IsEmailConfirmed(user.Email))
            {
                return Unauthorized(new { error = "Email not confirmed." });
            }

            return Ok(new { token, userId, expirationDate });
        }
    }
}
