using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //GET Categorias
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync
            (
                [FromServices]BlogDataContext context
            ) 
        {

            try
            {
                var categories = await context.Categories.ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05X01 - Não foi possivel localizar as categorias.");
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("05X11 - Falha interna no servidor"));
            }
        }


        //GET By Id Categoria
        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync
            (
                [FromRoute] int id,
                [FromServices] BlogDataContext context
            )
        {
            try
            {
                var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));
                }

                return Ok(new ResultViewModel<Category>(category));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("05X12 - Falha interna no servidor"));
            }
        }


        //POST Categoria
        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync
            (
                [FromBody] EditorCategoryViewModel model,
                [FromServices] BlogDataContext context
            )
        {
            if(!ModelState.IsValid) 
            {
                //return BadRequest(ModelState.Values);
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            }

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Posts = null,
                    Name = model.Name,
                    Slug = model.Slug.ToLower(),
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}",new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05X03 - Não foi possivel incluir a categoria."));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("05X13 - Falha interna no servidor"));
            }
                
           
        }

        //PUT Categoria
        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync
            (   
                [FromRoute] int id,
                [FromBody] EditorCategoryViewModel model,
                [FromServices] BlogDataContext context
            )
        {
            //Validando o MODEL, para saber se o mesmo esta váliso, porem o .Net ja faz isso nativamente
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>("Conteúdo não encontrado"));

            try
            {
                var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

                category.Name = model.Name;
                category.Slug = model.Slug;


                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05X04 - Não foi possivel atualizar a categoria."));
            }
            catch (Exception ex) { }
            {
                return StatusCode(500, new ResultViewModel<Category>("05X14 - Falha interna no servidor"));
            }
        }

        //DELETE By Id Categoria
        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteByAsync
            (
                [FromRoute] int id,
                [FromServices] BlogDataContext context
            )
        {
            try
            {
                var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado."));
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05X05 - Não foi possivel excluir a categoria."));
            }
            catch (Exception ex) { }
            {
                return StatusCode(500, new ResultViewModel<Category>("05X15 - Falha interna no servidor"));
            }

        }
    }
}
