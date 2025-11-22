namespace Geneta.Simulation.Allel;

public abstract class Trait : ITrait
{
    protected readonly IPhenoStrategy _phenoStrategy;
    public (string A1, string A2) GenoType { get; set; }
    public string Identifier { get; set; }

    public Dictionary<(string, string), string> PhenotypeDefinition;
    public virtual string GetPhenoType()
    {
        return _phenoStrategy.GetPhenoType(GenoType, PhenotypeDefinition);
    }
    
    public Trait(IPhenoStrategy phenoStrategy, (string, string) genotype)
    {
        _phenoStrategy = phenoStrategy;
        GenoType = genotype;
    }
}