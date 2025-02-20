namespace Presentation_ConsoleApp.Interfaces
{
    public interface IMenuDialog
    {
        void ExitApplication();
        Task ShowAddProject();
        Task ShowAllProjects();
        Task ShowMenu();
        Task ShowProjectByProjectNumber(string projectNumber);
        Task ShowUpdateProjectByProjectNumber(string projectNumber);
        Task ShowDeleteProject(string projectNumber);
    }
}