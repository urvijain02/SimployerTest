using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Models;

namespace TopicTweets.Controllers
{
    /// <summary>
    /// Add, Delete and Get related to Tweet
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetHandler _tweetHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tweetHandler"></param>
        public TweetsController(ITweetHandler tweetHandler)
        {
            _tweetHandler = tweetHandler;
        }

        // GET: api/<TopicsController>
        /// <summary>
        /// Fetches all the Tweets for a Topic based on the Topic id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Tweet</returns>
        [HttpGet]
        public IEnumerable<TweetResponse> GetTweetsByTopic(Guid id)
        {
            return _tweetHandler.GetTweetsByTopic(id);
        }

        // GET api/<TopicsController>/5
        /// <summary>
        /// Fetches the Tweet based on the Tweet id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tweet</returns>
        [HttpGet("{id}")]
        public TweetResponse GetTweet(string id)
        {
            return _tweetHandler.GetTweet(id);
        }
    }
}