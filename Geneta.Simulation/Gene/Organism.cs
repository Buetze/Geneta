using Geneta.Simulation.Allel;
using Geneta.Simulation.Flower;

namespace Geneta.Simulation;

public class Organism : IOrganism
{
    private FlowerPhenotype? _phenotype;
    
    public FlowerPhenotype Phenotype 
    { 
        get => _phenotype ??= PhenoTypeDefinitions.GetPhenotype(this);
        set => _phenotype = value;
    }
    
    public Dictionary<Traits, ITrait> Genotype { get; set; }
  
    public Organism()
    {
        Genotype = new Dictionary<Traits, ITrait>();
    }
}

public interface IOrganism
{
    FlowerPhenotype Phenotype { get; set; }
    public Dictionary<Traits, ITrait> Genotype { get; set; }

}