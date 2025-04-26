using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QnAB4.Model;
using System.ComponentModel.DataAnnotations;

namespace QnAB4.Controllers
{
    [Route("[controller]")]
    public class QuestionsController : Controller
    {
        [EnableCors("P2")]
        [HttpGet("GetQuestions")]
        public IActionResult GetQuestions()
        {
            int i = Convert.ToInt32("hfhg"); 
            return Ok("Test question");
        }
        [Authorize]
        [HttpGet("GetQuestion")]
        public IActionResult GetQuestion([Required]int QuestionID,string UserName)
        {
            return Ok("Query QuestionID"+ QuestionID.ToString());
        }
        [EnableCors("P1")]
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
