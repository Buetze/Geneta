namespace Geneta.Simulation.Allel;

public interface IPhenoStrategy
{
    public string GetPhenoType((string, string) genotypeTuple,Dictionary<(string, string), string> phenotypeDefinition);

}