using Geneta.Simulation.Allel;

namespace Geneta.Simulation;

public static class SimulationConfiguration
{
    public static Traits Traits { get; set; } = Traits.PetalColor | Traits.PetalCount | Traits.PetalWidth | Traits.PetalLength | Traits.PetalShape | Traits.CenterColor;

    public static (int min, int max) AmountOfChildren { get; set; } = (19, 20);
    public static Dictionary<Traits, IPhenoStrategy> PhenoMapping { get; set; } = new()
    {
        { Traits.PetalColor, new CompleteDominance() },
        { Traits.PetalCount, new IncompleteDominance() },
        { Traits.PetalWidth, new IncompleteDominance() },
        { Traits.PetalLength, new CompleteDominance() },
        { Traits.PetalShape, new IncompleteDominance() },
        { Traits.CenterColor, new CompleteDominance() }
    };
}