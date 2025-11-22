namespace Geneta.Simulation.Allel;

public class PetalWidthTrait : Trait
{
    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("C","C"), "40.0"},
        { ("C","c"), "40.0" },
        { ("c","c"), "30.0" }
    };
    
    public PetalWidthTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) 
        : base(phenoStrategy, genotype)
    {
    }
    
    public override string GetPhenoType()
    {
        return base._phenoStrategy.GetPhenoType(GenoType, this.PhenotypeDefinition);
    }
}