namespace Elsa.Studio.Workflows.Services;

/// <summary>
/// Default implementation of <see cref="IPanelStateService"/>.
/// </summary>
public class DefaultPanelStateService : IPanelStateService
{
    private bool _areAllPanelsCollapsed = true;

    /// <inheritdoc />
    public event Action? PanelStateChanged;

    /// <inheritdoc />
    public bool AreAllPanelsCollapsed
    {
        get => _areAllPanelsCollapsed;
        set
        {
            if (_areAllPanelsCollapsed != value)
            {
                _areAllPanelsCollapsed = value;
                PanelStateChanged?.Invoke();
            }
        }
    }
}
