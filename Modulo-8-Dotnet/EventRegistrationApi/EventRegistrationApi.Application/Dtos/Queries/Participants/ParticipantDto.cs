using System.ComponentModel.DataAnnotations;


namespace EventRegistrationApi.Application.Dtos.Queries.Participants;

public class ParticipantDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name is required.")]
    [StringLength(100, ErrorMessage = "The name must contain 100 characters maximum.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The last name is required.")]
    [StringLength(100, ErrorMessage = "The last name must contain 100 characters maximum.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "The email is required.")]
    [StringLength(100, ErrorMessage = "The email must contain 100 characters maximum.")]
    public required string Email { get; set; }
}
