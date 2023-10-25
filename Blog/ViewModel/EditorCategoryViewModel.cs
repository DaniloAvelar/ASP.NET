using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModel
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 40 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Slug { get; set; }
    }
}
