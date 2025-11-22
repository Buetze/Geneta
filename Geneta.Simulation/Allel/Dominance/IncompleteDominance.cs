namespace Geneta.Simulation.Allel;

public class IncompleteDominance : IPhenoStrategy
{
    public string GetPhenoType((string, string) genotypeTuple,
        Dictionary<(string, string), string> phenotypeDefinition)
    {
        return phenotypeDefinition[Sort(genotypeTuple)];
    }
    
    private static (string, string) Sort((string A1, string A2) a)
        => (a.A1.CompareTo(a.A2) > 0) ? (a.A1, a.A2) : (a.A2, a.A1);
}