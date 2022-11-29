namespace SplitVeryWise.Application.Contracts.DTOs.User;

public record UserLoginRequest(
    string Name,
    string Password);