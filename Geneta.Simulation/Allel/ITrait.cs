namespace Geneta.Simulation.Allel;

public interface ITrait
{
    (string A1, string A2) GenoType { get; set; }
    string Identifier { get; set; }
    string GetPhenoType();
}