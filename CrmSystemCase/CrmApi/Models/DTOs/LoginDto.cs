namespace CrmApi.Models.DTOs
{
    public record LoginDto(string UserName, string Password);
    public record AuthResponseDto(string Token, UserDto User);
    public record UserDto(int Id, string Username, string Role, DateTime CreatedAt, DateTime? UpdatedAt);
}
