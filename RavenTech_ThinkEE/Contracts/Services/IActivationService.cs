namespace RavenTech_ThinkEE.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
