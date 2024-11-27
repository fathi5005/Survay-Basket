namespace Survay_Basket.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class pollsController : ControllerBase
    {
        public IPollService PollService { get; }

        public pollsController(IPollService pollService)
        {
            PollService = pollService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {

            return Ok(PollService.GetAll().MapToResponse());

        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var poll = PollService.Get(id);

            return poll is null ? NotFound() : Ok(poll.MapToResponse());

        }



        [HttpPost("")]

        public IActionResult AddPoll([FromBody] PollRequest request)
        {

            var poll = PollService.Add(request.MapToPoll());

            return CreatedAtAction(nameof(Get), new { id = poll.Id }, poll.MapToResponse());
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePoll([FromRoute] int id, [FromBody] PollRequest request)
        {

            var checkpoll = PollService.Update(id, request.MapToPoll());
            if (!checkpoll)
            {

                return NotFound();
            }

            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult DeletePoll([FromRoute] int id)
        {
            var checkDelete = PollService.Delete(id);

            if (!checkDelete)
            {

                return NotFound();
            }

            return NoContent();
        }



    }
}
