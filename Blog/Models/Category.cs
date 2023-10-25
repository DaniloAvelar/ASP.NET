<<<<<<< HEAD
using System.Collections.Generic;

=======
>>>>>>> d0b3793719c3dee71a2387b0a161fe768cc71c57
namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        
        public IList<Post> Posts { get; set; }
    }
}