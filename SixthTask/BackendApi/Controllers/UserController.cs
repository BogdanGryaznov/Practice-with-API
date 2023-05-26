using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using BackendApi.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Запрос всей информации о пользователях
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Запрос информации о пользователе по определённому ID
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     GET
        ///     {
        ///         "id" : "12"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">ID Пользователя</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "idUser" : "12",
        ///         "login" : "ksas",
        ///         "password" : "ovr9999",
        ///         "roleId" : "0",
        ///         "address" : "none",
        ///         "isDeleted" : "false"
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Пользователь</param>
        /// <returns></returns>
         
        // Post api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Изменение информации об определённом пользоваетеле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /TODO
        ///     {
        ///         "idUser" : "12",
        ///         "login" : "ksas",
        ///         "password" : "ovr9999",
        ///         "roleId" : "0",
        ///         "address" : "none",
        ///         "isDeleted" : "false"
        ///     }
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя по его id 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE 
        ///     {
        ///         "id" : "12"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"> ID Пользователя</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
