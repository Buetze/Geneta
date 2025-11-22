namespace Geneta.Simulation.Allel;

public class PetalCountTrait : Trait
{
    public PetalCountTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) 
        : base(phenoStrategy, genotype)
    {
    }
    
    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("B","B"), "7" },
        { ("B","b"), "7" },
        { ("b","b"), "5" }
    };
    
    public override string GetPhenoType()
    {
        return base._phenoStrategy.GetPhenoType(GenoType, this.PhenotypeDefinition);
    }
}