namespace MyTasks.Components;
public partial class CopyText
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter, EditorRequired]
    public string TextToCopy { get; set; }

    [Parameter]
    public string Description { get; set; }

    public string ButtonText = "Copiar";
    public string ButtonIcon = "content_copy";
    public string ButtonIconColor = "background-color: transparent; color: royalblue; border: none;";

    public async Task CopyTextFunc()
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", TextToCopy);

        ButtonText = "Copiado";
        ButtonIcon = "check";
        ButtonIconColor = "background-color: transparent; color: limegreen; border: none;";
        StateHasChanged(); 

        await Task.Delay(2000); 

        ButtonText = "Copiar";
        ButtonIcon = "content_copy";
        ButtonIconColor = "background-color: transparent; color: royalblue; border: none;";
        StateHasChanged();
    }
}