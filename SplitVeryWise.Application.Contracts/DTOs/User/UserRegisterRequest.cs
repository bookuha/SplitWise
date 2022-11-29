namespace SplitVeryWise.Application.Contracts.DTOs.User;

public record UserRegisterRequest(
    string Name,
    string Password);