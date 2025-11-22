namespace Geneta.Simulation.Allel;

public class CenterColorTrait : Trait
{
    public CenterColorTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) 
        : base(phenoStrategy, genotype)
    {
    }

    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("F","F"), "#FFFF00" },  // Bright yellow
        { ("F","f"), "#FFE666" },  // Light yellow
        { ("f","f"), "#FFD700" }   // Golden
    };
    
    public override string GetPhenoType()
    {
        return _phenoStrategy.GetPhenoType(GenoType, this.PhenotypeDefinition);
    }
}