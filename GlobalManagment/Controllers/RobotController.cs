using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class RobotController : Controller
    {
        public static string _sharedMessage = "";
        private string currentMessage = "";

        public JsonResult GetRobotMessage()
        {
            currentMessage = _sharedMessage;
            if (currentMessage == _sharedMessage)
                _sharedMessage = "Empty";
            return Json(new { message = currentMessage});
        }

        [HttpGet("api/[controller]/start")]
        public IActionResult Start([FromQuery] string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return BadRequest("Sentence cannot be empty.");
            }

            _sharedMessage = sentence;
            return Ok("Message recorded.");
        }


        [HttpGet("api/[controller]")]
        public string GetNow()
        {
            return _sharedMessage;
        }
    }
}
