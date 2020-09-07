using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FindStringCoreWebapplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FindSubtextController : ControllerBase
    {
        private readonly ILogger<FindSubtextController> _logger;

        public FindSubtextController(ILogger<FindSubtextController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get method to search the position of the subtext in text using regular expression.
        /// </summary>
        /// <param name="text">Full text</param>
        /// <param name="subText">Text to search in Full text</param>
        /// <returns> Position of all the subtexts in text  </returns>
        [HttpGet]
        public string Get(string text, string subText)
        {
            List<string> allMatches = new List<string>();
            try
            {                
                var rx = new Regex(subText, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                Match match = rx.Match(text);

                while (match.Success)
                {
                    allMatches.Add(Convert.ToString(match.Index));
                    match = match.NextMatch();
                }

                return string.Join(",", allMatches);
            }
            catch (Exception ex)
            {
                //Log error to database or file for debugging purposes.
                _logger.LogError(ex.Message);
                return string.Empty;                
            }
        }
    }
}
