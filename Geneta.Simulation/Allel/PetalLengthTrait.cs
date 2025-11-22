namespace Geneta.Simulation.Allel;

public class PetalLengthTrait : Trait
{
    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("D","D"), "80.0" },
        { ("D","d"), "70.0" },
        { ("d","d"), "60.0" }
    };
    
    public PetalLengthTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) 
        : base(phenoStrategy, genotype)
    {
    }
    public override string GetPhenoType()
    {
        return base._phenoStrategy.GetPhenoType(GenoType, this.PhenotypeDefinition);
    }
}