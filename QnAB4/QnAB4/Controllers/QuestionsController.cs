using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QnAB4.Model;
using System.ComponentModel.DataAnnotations;

namespace QnAB4.Controllers
{
    [Route("[controller]")]
    public class QuestionsController : Controller
    {
        [HttpGet("GetQuestions")]
        public IActionResult GetQuestions()
        {
            return Ok("Test question");
        }
        [Authorize]
        [HttpGet("GetQuestion")]
        public IActionResult GetQuestion([Required]int QuestionID,string UserName)
        {
            return Ok("Query QuestionID"+ QuestionID.ToString());
        }

        [HttpGet("GetQuestionV2/{QuestionID}/{UserName}")]
        public IActionResult GetQuestionV2(int QuestionID,string UserName)
        {
            return Ok("Query QuestionID" + QuestionID.ToString());
        }

        [HttpGet("ValidUser")]
        public IActionResult ValidUser(string UserName ,string Password)
        {
            return Unauthorized();
        }
        [Authorize]
        [HttpPost("SaveQuestion")]
        public IActionResult SaveQuestion([FromBody]BaseQuestion baseQuestion)
        {
            return Ok(baseQuestion);
        }
    }
}
