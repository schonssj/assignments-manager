using AssignmentsManager.Application.Entities.Assignments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AssignmentsManager.Application.InputModels.Assignments;
using Microsoft.AspNetCore.Http;
using AssignmentsManager.Application.ViewModels.Assignments;
using System.Collections.Generic;

namespace AssignmentsManager.API.Controllers.Assignments
{
    [Produces("application/json")]
    [Route("api/assignments")]
    [ApiController]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService) => _assignmentService = assignmentService;

        /// <summary>
        /// Retorna uma tarefa cadastrada através do seu Id.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     GET /assignments/1
        /// </remarks>
        /// <param name="id">Id da tarefa.</param>
        /// <returns>Um objeto do tipo Tarefa.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="404">Registro não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AssignmentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var assignment = await _assignmentService.GetById(id);

            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        /// <summary>
        /// Retorna todas as tarefas cadastradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição: 
        ///     
        ///     GET /assignments
        /// </remarks>
        /// <returns>Uma lista de tarefas.</returns>
        /// <response code="200">Sucesso.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<AssignmentViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _assignmentService.GetAll();
            return Ok(assignments);
        }
        
        /// <summary>
        /// Retorna todas as tarefas já realizadas.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição: 
        ///     
        ///     GET /assignments/done
        /// </remarks>
        /// <returns>Uma lista de tarefas.</returns>
        /// <response code="200">Sucesso.</response>
        [HttpGet("done")]
        [ProducesResponseType(typeof(List<AssignmentViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDone()
        {
            var assignments = await _assignmentService.GetDone();
            return Ok(assignments);
        }
        
        /// <summary>
        /// Retorna todas as tarefas ainda não realizadas.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição: 
        ///     
        ///     GET /assignments/not-done-yet
        /// </remarks>
        /// <returns>Uma lista de tarefas.</returns>
        /// <response code="200">Sucesso.</response>
        [HttpGet("not-done-yet")]
        [ProducesResponseType(typeof(List<AssignmentViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNotDoneYet()
        {
            var assignments = await _assignmentService.GetNotDoneYet();
            return Ok(assignments);
        }

        /// <summary>
        /// Cadastra uma nova tarefa.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /assignments
        ///     {
        ///        "title": "Título",
        ///        "description": "Descrição",
        ///        "hasBeenDone": false
        ///     }
        /// </remarks>
        /// <param name="createAssignmentInputModel">Modelo dos dados de entrada.</param>
        /// <response code="201">Retorna a tarefa cadastrada.</response>
        /// <response code="400">Modelo dos dados de entrada inválido.</response>
        [HttpPost]
        [ProducesResponseType(typeof(AssignmentViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAssignment([FromBody]CreateAssignmentInputModel createAssignmentInputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var id = await _assignmentService.CreateAssignment(createAssignmentInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, createAssignmentInputModel);
        }

        /// <summary>
        /// Atualiza uma tarefa cadastrada.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /assignments
        ///     {
        ///        "id": 1
        ///        "title": "Novo título.",
        ///        "description": "Nova descrição.",
        ///        "hasBeenDone": false
        ///     }
        /// </remarks>
        /// <param name="updateAssignmentInputModel">Modelo dos dados de entrada.</param>
        /// <response code="201">Retorna a tarefa atualizada.</response>
        /// <response code="400">Modelo dos dados de entrada inválido.</response>
        /// <response code="404">Registro não encontrado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(AssignmentViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAssignment([FromBody] UpdateAssignmentInputModel updateAssignmentInputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _assignmentService.UpdateAssignment(updateAssignmentInputModel);

            if (response == 0)
                return NotFound();

            return CreatedAtAction(nameof(GetById), updateAssignmentInputModel);
        }

        /// <summary>
        /// Remove uma tarefa cadastrada da base de dados.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /assignments/1
        /// </remarks>
        /// <param name="id">Id da tarefa.</param>
        /// <response code="200">Sucesso.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var response = await _assignmentService.DeleteAssignment(id);

            if (response == 0)
                return NotFound();

            return Ok(response);
        }
    }
}
