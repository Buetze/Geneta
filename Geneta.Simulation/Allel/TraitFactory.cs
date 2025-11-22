using System.Diagnostics;

namespace Geneta.Simulation.Allel;

public static class TraitFactory
{
    public static ITrait CreateTrait(Traits trait, (string, string) allel) 
    {
        return trait switch
        {
            Traits.PetalColor => new PetalColorTrait(SimulationConfiguration.PhenoMapping[Traits.PetalColor], allel),
            Traits.CenterColor => new CenterColorTrait(SimulationConfiguration.PhenoMapping[Traits.CenterColor], allel),
            Traits.PetalCount => new PetalCountTrait(SimulationConfiguration.PhenoMapping[Traits.PetalCount], allel),
            Traits.PetalWidth => new PetalWidthTrait(SimulationConfiguration.PhenoMapping[Traits.PetalWidth], allel),
            Traits.PetalLength => new PetalLengthTrait(SimulationConfiguration.PhenoMapping[Traits.PetalLength], allel),
            Traits.PetalShape => new PetalShapeTrait(SimulationConfiguration.PhenoMapping[Traits.PetalShape], allel),
            _ => throw new ArgumentException($"Unknown trait: {trait}")
        };
    }
}