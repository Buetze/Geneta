namespace Geneta.Simulation.Allel;

public class PetalShapeTrait : Trait
{
    public string Identifier { get; set; }
    public readonly Dictionary<(string, string), string> PhenotypeDefinition = new()
    {
        { ("E","E"), "oval" },
        { ("E","e"), "oval" },
        { ("e","e"), "pointed" }
    };
    
    public PetalShapeTrait(IPhenoStrategy phenoStrategy, (string, string) genotype) 
        : base(phenoStrategy, genotype)
    {
    }
    
    public override string GetPhenoType()
    {
        return base._phenoStrategy.GetPhenoType(GenoType, this.PhenotypeDefinition);
    }
}