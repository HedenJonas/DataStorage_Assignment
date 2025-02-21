using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Presentation_ConsoleApp.Interfaces;

namespace Presentation_ConsoleApp.Dialogs;

public class MenuDialog(IProjectService projectService) : IMenuDialog
{
    private readonly IProjectService _projectService = projectService;
    
    public async Task ShowMenu()
    {
        bool IsRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1. List all projects.");
            Console.WriteLine("2. Create a project.");
            Console.WriteLine("3. List a project.");
            Console.WriteLine("4. Update a project.");
            Console.WriteLine("5. Delete a project.");
            Console.WriteLine("Q. Exit application.");
            Console.Write("Choose menu: ");
            var option = Console.ReadLine()!;


            switch (option.ToLower())
            {

                case "1":
                    await ShowAllProjects();
                    break;

                case "2":
                    await ShowAddProject();
                    break;

                case "3":
                    Console.Write("Enter project number to search: ");
                    string projectGet = Console.ReadLine()!;
                    await ShowProjectByProjectNumber(projectGet);
                    break;

                case "4":
                    Console.Write("Enter project number to search: ");
                    string projectUpdate = Console.ReadLine()!;
                    await ShowUpdateProjectByProjectNumber(projectUpdate);
                    break;

                case "5":
                    Console.Write("Enter project number to search: ");
                    string projectDelete = Console.ReadLine()!;
                    await ShowDeleteProject(projectDelete);
                    break;

                case "q":
                    ExitApplication();
                    break;

                default:
                    Console.WriteLine($"{option} is not a valid option, press any key to try again.");
                    Console.ReadKey();
                    break;
            }

        } while (IsRunning);

    }

    public void ExitApplication()
    {
        Environment.Exit(0);
    }

    public async Task ShowAllProjects()
    {
        try
        {
            var AllProjects = await _projectService.GetAllProjectsAsync();
            Console.Clear();
            Console.WriteLine("All users: ");

            if (AllProjects == null || !AllProjects.Any())
            {
                Console.WriteLine("No projects found, press any key.");
                Console.ReadKey();
                return;
            }

            foreach (var user in AllProjects)
            {
                Console.WriteLine($"Project number: {user.ProjectNumber}");
                Console.WriteLine($"Title: {user.Title}");
                Console.WriteLine($"Desciption: {user.Description}");
                Console.WriteLine($"Start date: {user.StartDate}");
                Console.WriteLine($"End date: {user.EndDate}");
                Console.WriteLine($"First name: {user.FirstName}");
                Console.WriteLine($"Last name: {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Billing address: {user.Address}");
                Console.WriteLine($"Service: {user.ProductName}");
                Console.WriteLine($"Service rate: {user.Rate}");
                Console.WriteLine($"Status: {user.StatusName}");
                Console.WriteLine($"project manager: {user.UserName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while fetching projects. {ex.Message}");
        }
        
        Console.ReadKey();
    }

    public async Task ShowAddProject()
    {
        var NewProject = ProjectFactory.Create();
        Console.Clear();
        Console.Write("Enter project number: ");
        NewProject.ProjectNumber = Console.ReadLine()!;

        Console.Write("Enter project title: ");
        NewProject.Title = Console.ReadLine()!;

        Console.Write("Enter project desciption: ");
        NewProject.Description = Console.ReadLine()!;

        NewProject.StartDate = GetDateFromUser("Enter start date of project: ");

        NewProject.EndDate = GetDateFromUser("Enter end date of project: ");

        Console.Write("Enter customer first name: ");
        NewProject.FirstName = Console.ReadLine()!;

        Console.Write("Enter customer last name: ");
        NewProject.LastName = Console.ReadLine()!;

        Console.Write("Enter customer email: ");
        NewProject.Email = Console.ReadLine()!;

        Console.Write("Enter billing address: ");
        NewProject.Address = Console.ReadLine()!;

        Console.Write("Enter service: ");
        NewProject.ProductName = Console.ReadLine()!;

        NewProject.Rate = GetDecimalFromUser("Enter service rate: ");

        Console.Write("Enter status on project: ");
        NewProject.StatusName = Console.ReadLine()!;

        Console.Write("Enter project manager: ");
        NewProject.UserName = Console.ReadLine()!;

        var project = await _projectService.CreateProjectAsync(NewProject);
        Console.WriteLine($"project with project number '{project.ProjectNumber}' was created!");
    }

    private static DateTime GetDateFromUser(string prompt)
    {
        DateTime date;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (DateTime.TryParse(input, out date))
            {
                return date;
            }

            Console.WriteLine("Invalid date format. Please try again.");
        }
    }

    private static decimal GetDecimalFromUser(string prompt)
    {
        decimal value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (decimal.TryParse(input, out value))
            {
                return value;
            }

            Console.WriteLine("Invalid decimal format. Please try again.");
        }
    }

    public async Task ShowUpdateProjectByProjectNumber(string projectNumber)
    {
        Console.Clear();
        try
        {
            var project = await _projectService.GetProjectAsync(p => p.ProjectNumber == projectNumber);
            if (project != null)
            {
                Console.WriteLine("Project found:");
                Console.WriteLine($"project number: {project.ProjectNumber}");
                Console.WriteLine($"Current title: {project.Title}. Enter new title: ");
                project.Title = Console.ReadLine()!;
                Console.WriteLine($"Current description: {project.Description}. Enter new description: ");
                project.Description = Console.ReadLine()!;
                Console.WriteLine($"Current start date: {project.StartDate}");
                project.EndDate = GetDateFromUser("New start date of project: ");
                Console.WriteLine($"Current end date: {project.EndDate}");
                project.StartDate = GetDateFromUser("New end date of project: ");
                Console.WriteLine($"Current first name: {project.FirstName}. Enter new first name: ");
                project.FirstName = Console.ReadLine()!;
                Console.WriteLine($"Current last name: {project.LastName}. Enter new last name: ");
                project.LastName = Console.ReadLine()!;
                Console.WriteLine($"Current email: {project.Email}. Enter new email: ");
                project.Email = Console.ReadLine()!;
                Console.WriteLine($"Current billing address: {project.Address}. Enter new address: ");
                project.Address = Console.ReadLine()!;
                Console.WriteLine($"Current service: {project.ProductName}. Enter new service: ");
                project.ProductName = Console.ReadLine()!;
                Console.WriteLine($"Current service rate: {project.Rate}. Enter new rate: ");
                project.Rate = GetDecimalFromUser("Enter new service rate: ");
                Console.WriteLine($"Current status: {project.StatusName}. Enter new status: ");
                project.StatusName = Console.ReadLine()!;
                Console.WriteLine($"Current project manager: {project.UserName}. Enter new manager: ");
                project.UserName = Console.ReadLine()!;

                var updatedProject = ProjectFactory.Create(project);
                await _projectService.UpdateProjectAsync(updatedProject);
            }
            else
                Console.WriteLine($"No project found with Project Number: {projectNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while fetching the project. {ex.Message}");
        }
        Console.ReadKey();
    }

    public async Task ShowProjectByProjectNumber(string projectNumber)
    {
        try
        {
            var project = await _projectService.GetProjectAsync(p => p.ProjectNumber == projectNumber);
            if (project != null)
            {
                Console.WriteLine("Project found:");
                Console.WriteLine($"Project number: {project.ProjectNumber}");
                Console.WriteLine($"Title: {project.Title}");
                Console.WriteLine($"Description: {project.Description}");
                Console.WriteLine($"Start date: {project.StartDate}");
                Console.WriteLine($"End date: {project.EndDate}");
                Console.WriteLine($"First name: {project.FirstName}");
                Console.WriteLine($"Last name: {project.LastName}");
                Console.WriteLine($"Email: {project.Email}");
                Console.WriteLine($"Billing address: {project.Address}");
                Console.WriteLine($"Service: {project.ProductName}");
                Console.WriteLine($"Service rate: {project.Rate}");
                Console.WriteLine($"Status: {project.StatusName}");
                Console.WriteLine($"Project manager: {project.UserName}");
            }
            else
                Console.WriteLine($"No project found with Project Number: {projectNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while fetching the project. {ex.Message}");
        }
        Console.ReadKey();
    }

    public async Task ShowDeleteProject(string projectNumber)
    {
        try
        {
            var project = await _projectService.GetProjectAsync(x => x.ProjectNumber == projectNumber);

            if (project.ProjectNumber == projectNumber)
            {
                await _projectService.DeleteProjectAsync(x => x.ProjectNumber == projectNumber);
                Console.WriteLine($"Project {nameof(project.ProjectNumber)} has been deleted!");
            }
            else
                Console.WriteLine($"No project found with Project Number: {projectNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while deleting the project. {ex.Message}");
        }
        Console.ReadKey();

    }
}
