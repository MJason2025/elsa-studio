using Elsa.Studio.Workflows.Services;
using Microsoft.AspNetCore.Components;

namespace Elsa.Studio.Workflows.Components.WorkflowDefinitionEditor;

public partial class WorkflowDefinitionEditor : IDisposable
{
    [Inject] private IPanelStateService PanelStateService { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        PanelStateService.PanelStateChanged += OnPanelStateChanged;
    }

    private void OnPanelStateChanged()
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        PanelStateService.PanelStateChanged -= OnPanelStateChanged;
    }
}
