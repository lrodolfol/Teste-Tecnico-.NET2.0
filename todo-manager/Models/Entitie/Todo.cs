using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using todo_manager.Interfaces;

namespace todo_manager.Models.Entitie
{
    public class Todo
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório: Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Titulo")]
        [StringLength(20, ErrorMessage = "Campo não pode exceder 20 caracteres: Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: User Story")]
        [StringLength(120, ErrorMessage = "Campo não pode exceder 120 caracteres: User Story")]
        public string UserStory { get; set; }

        [DefaultValue(null)]
        public DateTime DeadLine { get; set; }

        [DefaultValue(1)]
        [Range(1, 3, ErrorMessage = "Campo deve deve estar entre 1 e 3")]
        public int IdPriority { get; set; }

        public virtual Priority Priority { get; set; }

    }
}
