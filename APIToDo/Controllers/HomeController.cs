using APITODO.Data;
using APITODO.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITODO.Controllers
{
    [ApiController] //Sempre colocar para retornar somente JSON
    public class HomeController : ControllerBase // Controller Base sempre traz mais métodos a serem utilizados
    {
        [HttpGet] //Metodo GET
        [Route("/")] //Rota para chamada
        public IActionResult Get([FromServices]AppDbContext context) //Estancia o DbContext dentro do parenteses como um parâmetro utilizando o [FromServices]
        {
            return Ok(context.Todos.ToList());
        }

        [HttpGet("/{id:int}")] //Metodo GET
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices]AppDbContext context
            )
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);

            if(todos == null)
                return NotFound();
            
            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post(
            [FromBody]TodoModel todo,
            [FromServices]AppDbContext context
            )
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"/{todo.Id}", todo); // O Created pede uma URL do ID ou Parametro passado, sempre passar essa URL
        }

        [HttpPut("/{id:int}")] //Atualizar / Editar : PUT
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody]TodoModel todo, 
            [FromServices]AppDbContext context
            )
        {
            //Recuperando o item do banco de dados pelo ID
            var model = context.Todos.FirstOrDefault(x => x.Id ==id);

            // Checando se é NULL
            if(model == null)
                return NotFound();

            // equiparando os dados da tela com os do DB
            model.Title = todo.Title;
            model.Done = todo.Done;

            //Salvando no BD
            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")] //Excluir / Deletar : DELETE
        public IActionResult Put(
            [FromRoute] int id, 
            [FromServices]AppDbContext context
            )
        {
            //Recuperando o item do banco de dados pelo ID
            var model = context.Todos.FirstOrDefault(x => x.Id ==id);
            if(model == null)
                return NotFound();

            //Salvando no BD
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}