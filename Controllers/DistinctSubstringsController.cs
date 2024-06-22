using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assign2.Controllers
{
    public class DistinctSubstringsController : ApiController
    {
        // GET api/DistinctSubstrings?inputString={inputString}
        public IHttpActionResult GetDistinctSubstringCount(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return BadRequest("Input string cannot be null or empty.");
            }

            int count = CountDistinctSubstrings(inputString);
            return Ok(count);
        }

        private int CountDistinctSubstrings(string s)
        {
            int n = s.Length;
            List<string> suffixes = new List<string>();

            // Generate all suffixes and store them in a list
            for (int i = 0; i < n; i++)
            {
                suffixes.Add(s.Substring(i));
            }

            // Sort suffixes lexicographically
            suffixes.Sort();

            int distinctSubstrings = 0;
            string prevSuffix = "";

            // Count distinct substrings using sorted suffixes
            foreach (string suffix in suffixes)
            {
                int lcp = 0;
                while (lcp < suffix.Length && lcp < prevSuffix.Length && suffix[lcp] == prevSuffix[lcp])
                {
                    lcp++;
                }
                distinctSubstrings += suffix.Length - lcp;
                prevSuffix = suffix;
            }
            distinctSubstrings++;
            return distinctSubstrings;
        }
    }
}

