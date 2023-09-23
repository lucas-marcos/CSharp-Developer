using System.ComponentModel.DataAnnotations;

namespace Back.Models;

public class Entity
{
    [Key] public int Id { get; set; }
}