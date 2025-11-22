namespace Geneta.Simulation.Allel;

public class PetalColorTrait : Trait
{
    public PetalColorTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) : base(phenoStrategy, genotype)
    {
    }
    
    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("A","A"), "#FF00FF" },
        { ("A","a"), "#FF66FF" },
        { ("a","a"), "#AAFFFF" }
    };
    public override string GetPhenoType()
    {
        return base._phenoStrategy.GetPhenoType(GenoType, PhenotypeDefinition);
    }
}