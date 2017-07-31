using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstagramGot.InstagramHttpClient
{
    class CommentsEndPoint : InstagramHttpClient
    {
        /// <summary>
        /// Get infomation of all comments of a media.
        /// </summary>
        public static string GetCommentsAPICall(string mediaId)
        {
            string urlParameters = String.Format(endPoints[EndPointsTypes.Comments], mediaId) + "?access_token=" + context.AccessToken;

            var response = client.GetAsync(urlParameters).Result;

            return ReadRespone(response);
        }

        /// <summary>
        /// Publish a comment.
        /// </summary>
        /// <exception cref="Exceptions.CommentFormatException">Error formating comment.</exception>
        public static bool PostCommentAPICall(string mediaId, string text)
        {
            // Check message length
            if (text.Length >= 300)
                throw new Exceptions.CommentFormatException("Comment length must be less than 300 characters.");

            // Check that all letters can't be capital case
            if(text.Count() == text.Where(c => Char.IsUpper(c)).Count())
                throw new Exceptions.CommentFormatException("The comment cannot consist of all capital letters.");

            // Check that comment contains les than 5 hastags
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(text);
            if (matches.Count > 4)
                throw new Exceptions.CommentFormatException("The comment must have less than 5 hastags.");

            // Check that comment contains less than 2 uri
            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            matches = regx.Matches(text);

            if (matches.Count > 1)
                throw new Exceptions.CommentFormatException("Comment can only contain one uri.");

            // Format url parameters
            string urlParameters = String.Format(endPoints[EndPointsTypes.Comments], mediaId) + "?access_token=" + context.AccessToken;

            // POST parameters
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("text", text)
                });

            // Post request
            var response = client.PostAsync(urlParameters, content).Result;

            ReadRespone(response);

            // If status code is not 200 ReadRespones already throws an exception
            return true;
        }

        /// <summary>
        /// Delete an specific comment.
        /// </summary>
        public static bool DeleteCommentAPICall(string mediaId, string commentId)
        {
            string urlParameters = String.Format(endPoints[EndPointsTypes.Comments], mediaId) + commentId.ToString() +"/?access_token=" + context.AccessToken;

            var response = client.DeleteAsync(urlParameters).Result;

            ReadRespone(response);

            // If status code is not 200 ReadRespones already throws an exception
            return true;
        }
    }
}
