namespace Geneta.Simulation.Allel;

public class CompleteDominance : IPhenoStrategy
{
    public string GetPhenoType((string, string) genotypeTuple,
        Dictionary<(string, string), string> phenotypeDefinition)
    {
        var isDominant = genotypeTuple.Item1.Any(char.IsUpper) || genotypeTuple.Item2.Any(char.IsUpper);
        return isDominant
            ? phenotypeDefinition[(genotypeTuple.Item1.ToUpper(), genotypeTuple.Item2.ToUpper())]
            : phenotypeDefinition[(genotypeTuple.Item1.ToLower(), genotypeTuple.Item2.ToLower())];
    }

    
}