#define MovieDateRatingDA
#if MovieDateRatingDA
// <snippet1>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    [Key]
    [StringLength(20)]
    public string? Id { get; set; }=string.Empty;
    [Required]
    [StringLength(20)]
    public string? Name { get; set; }= string.Empty;
    [Required]
    [StringLength(3)]
    public string? Sex { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string? Birth { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string? Phone { get; set; }=string.Empty;
    [Required]
    [StringLength(20)]
    public string? School { get; set; } = string.Empty;
    [Required]
    public int Grade { get; set; }
}
// </snippet1>
#endif
