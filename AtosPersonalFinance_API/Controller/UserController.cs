﻿using AtosPersonalFinance_API.Data;
using AtosPersonalFinance_API.Models.Dtos;
using AtosPersonalFinance_API.Models.Entities;
using AtosPersonalFinance_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtosPersonalFinance_API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;

        public UserController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this._jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> CreateUserAsync(
            [FromServices] Context context,
            [FromBody] userDTO request
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                request.UserName = request.UserName.ToLower();

                var userExists = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => (u.UserName == request.UserName));

                if (userExists?.UserName == request.UserName)
                {
                    return BadRequest(new { message = "userName already exists." });
                }

                var newUser = new User
                {
                    UserName = request.UserName,
                    Password = HashPassword.Encript(request.Password),
                };

                await context.Users.AddAsync(newUser);

                await context.SaveChangesAsync();
                newUser.Password = null;

                string token = _jWTAuthenticationManager.Authenticate(
                    newUser.UserName,
                    request.Password
                );

                return Ok(new { newUser, token });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { message = "Failed to create user contact administrator.", error = ex }
                );
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(
            [FromServices] Context context,
            [FromBody] userDTO request
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                request.UserName = request.UserName.ToLower();

                var user = await context.Users.FirstOrDefaultAsync(
                    u => u.UserName == request.UserName
                );

                var message = new { message = "Username or password is invalid." };

                if (user == null)
                {
                    return BadRequest(message);
                }

                if (user.UserName != request.UserName)
                {
                    return BadRequest(message);
                }

                if (!HashPassword.Verify(request.Password, user.Password))
                {
                    return BadRequest(message);
                }

                user.Password = null;

                string token = _jWTAuthenticationManager.Authenticate(
                    user.UserName,
                    request.Password
                );

                return Ok(new { user, token });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        message = "Failed to log in contact your administrator",
                        error = ex.Message
                    }
                );
            }
        }
    }
}
