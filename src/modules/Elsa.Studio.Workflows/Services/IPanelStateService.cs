namespace Elsa.Studio.Workflows.Services;

/// <summary>
/// Service for managing the global collapse/expand state of panels in the workflow editor.
/// </summary>
public interface IPanelStateService
{
    /// <summary>
    /// Raised when the panel state changes.
    /// </summary>
    event Action? PanelStateChanged;
    
    /// <summary>
    /// Gets or sets whether all panels should be collapsed.
    /// </summary>
    bool AreAllPanelsCollapsed { get; set; }
}
