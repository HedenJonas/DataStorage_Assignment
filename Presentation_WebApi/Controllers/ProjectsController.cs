using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebApi.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;


    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            if (await _projectService.CheckIfProjectExistsAsync(x => x.ProjectNumber == form.ProjectNumber))
                return Conflict("Project with same projectnumber already exists.");

            var project = await _projectService.CreateProjectAsync(form);
            if (project != null)
                return Ok(project);
        }    

        return BadRequest();
    }
}
