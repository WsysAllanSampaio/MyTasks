using MyTasks.Services.Jira;

namespace MyTasks.Pages.Automations;

public partial class AutomationsPage 
{
    [Inject]
    public HttpClient HttpClient { get; set; }

    public string TaskNumber = "";

    private string taskDescription = "";
    public string TaskDescription 
    { 
        get => taskDescription; 
        set 
        {
            taskDescription = value.Replace("Wsys 2.0 - ", "")
                                   .Replace("WSYS 2.0 - ", "");

            TitlePage = taskDescription.Replace("Padronização - Tela ", "")
                                       .Replace("Segurança - Tela ", "");

            TaskType = TaskDescription.ToLower().Contains("padroniza") ? "feat" : "fix";
            TaskCommentFirstLine = TaskDescription.ToLower().Contains("padroniza") ? PadronizacaoValueText : SegurancaValueText;
        } 
    }

    public string TitlePage = "";
    public string TaskType = "";
    public string TaskCommentFirstLine = "";
    public string TaskComment = "";
    public string DataBase = "\"WSYS_APRESENTACAO_12082024_JONATHAN\"\n\n";

    public string PadronizacaoValueText = "Foram feitas as modificações solicitadas.\n\n";
    public string SegurancaValueText = "Foram feitas as modificações para exibir informações aos usuários de acordo com as suas restrições.\n\n";

    public async Task FindTasks()
    {
        JiraService Jira = new();

        await Jira.GetCurrentTask(HttpClient);
    }
}