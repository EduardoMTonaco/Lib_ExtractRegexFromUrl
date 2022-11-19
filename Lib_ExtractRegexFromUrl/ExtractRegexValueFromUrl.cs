using Lib_RegexHandler;
using Lib_UrlDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_ExtractRegexFromUrl
{
    /// <summary>
    /// Class To extract a regular expression from a url's HMTL
    /// </summary>
    public class ExtractRegexValueFromUrl
    {
        /// <summary>
        /// Variable use to download the HTML from URL
        /// </summary>
        private IUrlDownload _urlDownload;
        /// <summary>
        /// Variable that define the full regular expression and extract from a text
        /// </summary>
        private IExpressionExtrator _expressionExtrator;
        /// <summary>
        /// Constructor with the needed classes to extract a regular expression from an URL
        /// </summary>
        /// <param name="urlDownload">This variable need to transform the URL's HTML in string</param>
        /// <param name="expressionExtrator">This variable need a regular expression and function to extract the regular expression from a text</param>
        public ExtractRegexValueFromUrl(IUrlDownload urlDownload, IExpressionExtrator expressionExtrator)
        {
            _urlDownload = urlDownload;
            _expressionExtrator = expressionExtrator;
        }
        /// <summary>
        /// Extract the regular expression from an URL as a string
        /// </summary>
        /// <returns>Return just the regular expression from a URL</returns>
        public async Task<string> GetStringExpression()
        {
            string url = await _urlDownload.GetSiteToString();
            return _expressionExtrator.GetRegexExpression(url);
        }
        /// <summary>
        /// Get the regular expression from a URL and convert to double, it is needed that the regular expression is a number
        /// </summary>
        /// <param name="decimalPoint">If the format's result of regular expression is decimal international notation set this true</param>
        /// <returns>Return the regular expression as a double</returns>
        public async Task<double> GetDoubleExpression(bool decimalPoint) 
        {
            try
            {
                string url = await GetStringExpression();
                if (decimalPoint)
                {
                    url = url.Replace(",", "");
                }
                else
                {
                    url = url.Replace(",", "").Replace(".", ",");
                }
                double value = Convert.ToDouble(url);
                return value;
            }
            catch(ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}