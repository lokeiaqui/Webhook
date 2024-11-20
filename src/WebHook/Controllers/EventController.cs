using Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebHook.Controllers
{
    [ApiController]
    [Route("api/webhook/events")]
    public class EventController(IMessageBrokerService _messageBrokerService) : ControllerBase
    {
        [HttpPost("v1/send-event")]
        public async Task<IActionResult> Post(object payload)
        {
            await _messageBrokerService.PublishAsync(payload, CancellationToken.None);

            Console.WriteLine("New event", payload);

            return Accepted();
        }
    }
}