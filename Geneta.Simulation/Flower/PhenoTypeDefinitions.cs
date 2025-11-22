using Geneta.Simulation.Flower;

namespace Geneta.Simulation;

public static class PhenoTypeDefinitions
{
    public static Dictionary<(string, string), string> PetalColor = new()
    {
        { ("A","A"), "#FF00FF" },
        { ("A","a"), "#FF66FF" },
        { ("a","a"), "#AAFFFF" }
    };

    public static Dictionary<(string, string), int> PetalCount = new()
    {
        { ("B","B"), 7 },
        { ("B","b"), 7 },
        { ("b","b"), 5 }
    };

    public static Dictionary<(string, string), double> PetalWidth = new()
    {
        { ("C","C"), 40.0 },
        { ("C","c"), 40.0 },
        { ("c","c"), 30.0 }
    };

    public static Dictionary<(string, string), double> PetalLength = new()
    {
        { ("D","D"), 80.0 },
        { ("D","d"), 70.0 },
        { ("d","d"), 60.0 }
    };

    public static Dictionary<(string, string), string> PetalShape = new()
    {
        { ("E","E"), "oval" },
        { ("E","e"), "oval" },
        { ("e","e"), "pointed" }
    };

    public static Dictionary<(string, string), string> CenterColor = new()
    {
        { ("F","F"), "#FFFF00" },  // Bright yellow
        { ("F","f"), "#FFE666" },  // Light yellow
        { ("f","f"), "#FFD700" }   // Golden
    };

    public static FlowerPhenotype GetPhenotype(Organism org)
    {
        var p = new FlowerPhenotype();

        p.PetalColor = org.Genotype[Traits.PetalColor].GetPhenoType();
        p.PetalCount = int.Parse(org.Genotype[Traits.PetalCount].GetPhenoType());
        p.PetalWidth = double.Parse(org.Genotype[Traits.PetalWidth].GetPhenoType());
        p.PetalLength = double.Parse(org.Genotype[Traits.PetalLength].GetPhenoType());
        p.PetalShape = org.Genotype[Traits.PetalShape].GetPhenoType();
        p.CenterColor = org.Genotype[Traits.CenterColor].GetPhenoType();

        return p;

    }

    private static (string, string) Sort((string A1, string A2) a)
        => (a.A1.CompareTo(a.A2) > 0) ? (a.A1, a.A2) : (a.A2, a.A1);
}