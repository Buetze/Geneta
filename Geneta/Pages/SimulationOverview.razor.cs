using Geneta.Components;
using Geneta.Simulation;
using Geneta.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Geneta.Pages;

public partial class SimulationOverview : ComponentBase
{
    [Inject] public SimulationService SimulationService { get; set; }
    [Inject] public DialogService DialogService { get; set; }

    public Drawer Drawer { get; set; }
    private IOrganism LeftOrganism { get; set; }
    private IOrganism RightOrganism { get; set; }

    public int GenerationIndex { 
        get => SimulationService.GenerationIndex; 
        set => SimulationService.GenerationIndex = value; 
    }

    public Generation CurrentGeneration => SimulationService.GetGeneration(@GenerationIndex);
    
    public SimulationOverview()
    {
    }

    private void SelectOrganism(IOrganism organism)
    {
        if (organism == LeftOrganism)
        {   
            LeftOrganism = null;
        }
        else if (organism == RightOrganism)
        {
            RightOrganism = null;
        }
        else if (LeftOrganism == null)
        {
            LeftOrganism = organism;
        }
        else if (RightOrganism == null)
        {
            RightOrganism = organism;
        }
    }

    private void RemoveSelectedOrganism(IOrganism organism)
    {
        if (LeftOrganism == organism)
        {
            LeftOrganism = null;
        }

        if (RightOrganism == organism)
        {
            RightOrganism = null;
        }
    }

    private void CreateNewGenerationFromGenes()
    {
        if (LeftOrganism != null && RightOrganism != null)
        {
            SimulationService.Simulation.GenerateNewGeneration(LeftOrganism, RightOrganism, SimulationService.Simulation.Generations.ElementAt(GenerationIndex));

            LeftOrganism = null;
            RightOrganism = null;
            
            GenerationIndex = SimulationService.Simulation.Generations.Count - 1;
            
            StateHasChanged();
        }
    }

    private async void OpenConfigrationModal()
    {
        var dialogOptions = new DialogOptions
        {
            Width = "800px",  // Adjust width as needed
            Height = "600px", // Adjust height as needed
            CloseDialogOnOverlayClick = true,
            CloseDialogOnEsc = true
        };

        await DialogService.OpenAsync<ConfigurationPage>("Configuration", 
            options: dialogOptions);
        StateHasChanged();
    }
    


    private void SelectIndex(int generationIndex)
    {
        GenerationIndex = generationIndex;
    }

}