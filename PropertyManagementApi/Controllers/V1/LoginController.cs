using Microsoft.AspNetCore.Mvc;
using PropertyManagementApi.DTOs;
using PropertyManagementApi.Services;

namespace PropertyManagementApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Validate user and password for login
        /// </summary>
        /// <remarks>User information</remarks>
        /// <param name="loginRequest">Object with login data</param>
        /// <returns>Return data</returns>
        [ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> LoginUser(LoginRequest loginRequest)
        {
            try
            {
                var loginResponse = await _loginService.Login(loginRequest.Email, loginRequest.Password);
                if (loginResponse == null)
                    return StatusCode(401, loginResponse);
                else
                    return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Validation"))
                    return StatusCode(401, new ReturnDTO { Message = ex.Message, Status = 401 });
                else
                    return StatusCode(500, new ReturnDTO { Message = ex.Message, Status = 500 });
            }
        }
    }
}
