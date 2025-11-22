namespace Geneta.Simulation;


public class Generation
{
    private readonly Generation _parentGeneration;
    public List<IOrganism> Organism { get; set; }
    
    public (IOrganism left, IOrganism right) Parents { get; set; }

    public int GenerationNumber { get; set; }

    public Generation(List<IOrganism> organism, Generation parentGeneration, int generationNumber)
    {
        _parentGeneration = parentGeneration;
        Organism = organism;
        GenerationNumber = generationNumber;
    }
    
    public Generation(List<IOrganism> organism, Generation parentGeneration, int generationNumber, IOrganism leftOrganism, IOrganism rightOrganism) : this(organism, parentGeneration, generationNumber)
    {
        Parents = (leftOrganism, rightOrganism);
    }
    
    public Generation(List<IOrganism> organism, int generationNumber)
    {
        Organism = organism;
        GenerationNumber = generationNumber;
    }
}
