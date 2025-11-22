using Geneta.Simulation.Allel;

namespace Geneta.Simulation;

public static class Genetics
{
    private static Random _rnd = new();

    public static Organism CreateOffspring(IOrganism p1, IOrganism p2)
    {
        var child = new Organism();

        foreach (var gene in p1.Genotype.Keys)
        {
            var allele1 = _rnd.Next(0, 2) == 0 ? p1.Genotype[gene].GenoType.A1 : p1.Genotype[gene].GenoType.A2;
            var allele2 = _rnd.Next(0, 2) == 0 ? p2.Genotype[gene].GenoType.A1 : p2.Genotype[gene].GenoType.A2;

            child.Genotype[gene] = TraitFactory.CreateTrait(gene, (allele1, allele2));
        }

        return child;
    }
}