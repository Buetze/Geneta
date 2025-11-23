using Geneta.Simulation.Allel;

namespace Geneta.Simulation;

public class Simulation
{
    private static Random _rnd = new();
    public List<Generation> Generations { get; set; } = new();

    public Generation? InitialGeneration => Generations?.FirstOrDefault();

    private Generation CreateNewGeneration(IOrganism organismOne, IOrganism organismTwo, Generation parentGeneration)
    {
        var newGeneration = GenerateOffspring(organismOne, organismTwo);

        return new Generation(newGeneration, parentGeneration, (parentGeneration?.GenerationNumber ?? 0) + 1, organismOne, organismTwo);
    }

    private static List<IOrganism> GenerateOffspring(IOrganism organismOne, IOrganism organismTwo)
    {
        var newGeneration = new List<IOrganism>();
        var numberOfChildren = _rnd.Next(SimulationConfiguration.AmountOfChildren.min, SimulationConfiguration.AmountOfChildren.max);
        for (int i = 0; i < numberOfChildren; i++)
        {
            newGeneration.Add(Genetics.CreateOffspring(organismOne, organismTwo));
        }

        return newGeneration;
    }

    public Generation GenerateNewGeneration(IOrganism organismOne, IOrganism organismTwo, Generation parentGeneration)
    {
        
        var newGeneration = CreateNewGeneration(organismOne, organismTwo, parentGeneration);
        Generations.Add(newGeneration);
        return newGeneration;
    }

    public void InstanciateInitialGeneration()
    {
        var initialParents = new List<IOrganism>();
        
        for (var i = 0; i < 2; i++)
        {
            var organism = new Organism();

            foreach (var trait in Enum.GetValues(typeof(Traits)))
            {
                organism.Genotype.Add((Traits)trait, TraitFactory.CreateTrait((Traits)trait, GetAllelFromConfiguration(trait is Traits traits ? traits : Traits.PetalColor)));
            }

            initialParents.Add(organism);
        }
        
        var FirstGeneration = GenerateOffspring(initialParents[0], initialParents[1]);;

        var initialGeneration = new Generation(FirstGeneration, 0);

        Generations.Add(initialGeneration);
    }

    private (string A1, string A2) GetAllelFromConfiguration(Traits trait)
    {
        var gene = TraitToGene(trait);
        var gene2 = SimulationConfiguration.Traits.HasFlag(trait) ? (char)(gene + 32) : gene;
        return (gene.ToString(), gene2.ToString());
    }

    private char TraitToGene(Traits trait)
    {
        return trait switch
        {
            Traits.PetalColor => 'A',
            Traits.PetalCount => 'B',
            Traits.PetalWidth => 'C',
            Traits.PetalLength => 'D',
            Traits.PetalShape => 'E',
            Traits.CenterColor => 'F',
            _ => throw new ArgumentOutOfRangeException(nameof(trait), trait, null)
        };
    }

    private (string A1, string A2) GetRandomAllelePair(char gene, Random random)
    {
        string allele1 = random.Next(2) == 0 ? gene.ToString().ToUpper() : gene.ToString().ToLower();
        string allele2 = random.Next(2) == 0 ? gene.ToString().ToUpper() : gene.ToString().ToLower();
        return (allele1, allele2);
    }
}