using Geneta.Simulation;

namespace Geneta.Services;

public class SimulationService
{
    public Simulation.Simulation Simulation { get; set; }
    
    public int GenerationIndex { get; set; } = 0;

    public SimulationService()
    {
        Simulation = new Simulation.Simulation();
        Simulation.InstanciateInitialGeneration();
    }
    
    public Generation GetGeneration(int generationIndex)
    {
        return Simulation.Generations.ElementAt(generationIndex);
    }

    public void CreateNewSimulation()
    {
        Simulation = new Simulation.Simulation();
        Simulation.InstanciateInitialGeneration();
    }
}