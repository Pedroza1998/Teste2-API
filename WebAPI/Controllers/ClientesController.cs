using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Entidade;
using Infraestrutura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class ClientesController
    {
        [ApiController]
        [Route("clientes")]
        public class UserController : ControllerBase
        {
            [HttpGet]
            [Route("")]
            public async Task<ActionResult<List<Clientes>>> Get([FromServices] DataContext Context)
            {
                var Clientes = await Context.Clientes.ToListAsync();
                return Clientes;
            }
            
            [HttpPost]
            [Route("")]
            public async Task<ActionResult<Clientes>> Post(
                [FromServices] DataContext context,
                [FromBody]Clientes model)
                {
                    if (ModelState.IsValid)
                    {
                        context.Clientes.Add(model);
                        await context.SaveChangesAsync();
                        return model;
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
            
            [HttpDelete("{id:int}")]
            [Route("")]
            public async Task<ActionResult<Clientes>> Delete([FromServices] DataContext context, int id)
            {
                try
                {
                    var _clientes = context.Clientes.Find(id);
                    context.Clientes.Remove(_clientes);
                    await context.SaveChangesAsync();
                    _clientes = null;
                    return Ok("User Deleted!");
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
            }

            [HttpPut("{id:int}")]
            [Route("")]
            public async Task<ActionResult<Clientes>> Put(
                [FromServices] DataContext context,
                [FromBody]Clientes model, int id)
                {
                    if (ModelState.IsValid)
                    {
                        var _clientes = context.Clientes.Find(id);
                        _clientes.nome = model.nome;
                        _clientes.endereço = model.endereço;
                        await context.SaveChangesAsync();
                        return Ok("Sucess in update");
                    }
                    else
                    {
                        return BadRequest(ModelState);
                     }
                }
        }
    }
}