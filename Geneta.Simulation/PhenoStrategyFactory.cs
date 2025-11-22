using Geneta.Simulation.Allel;

namespace Geneta.Simulation;

public static class PhenoStrategyFactory
{
    public static IPhenoStrategy Create(PhenoStrategyType type)
    {
        return type switch
        {
            PhenoStrategyType.CompleteDominance => new CompleteDominance(),
            PhenoStrategyType.IncompleteDominance => new IncompleteDominance(),
            _ => throw new ArgumentException($"Unknown strategy type: {type}")
        };
    }

}