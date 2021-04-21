using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Models;

namespace TopicTweets.Controllers
{
    /// <summary>
    /// Add, Delete and Get related to Topic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicHandler _topicHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="topicHandler"></param>
        public TopicsController(ITopicHandler topicHandler)
        {
            _topicHandler = topicHandler;
        }

        //GET: api/<TopicsController>
        /// <summary>
        /// Gets all the Topics
        /// </summary>
        /// <returns>List of Topic</returns>
        [HttpGet]
        public IEnumerable<TopicResponse> GetTopics()
        {
            return _topicHandler.GetAllTopics();
        }

        // GET api/<TopicsController>/5
        /// <summary>
        /// Gets the Topic based on the Topic id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Topic</returns>
        [HttpGet("{id}")]
        public TopicResponse GetTopic(Guid id)
        {
            return _topicHandler.GetTopic(id);
        }

        // POST api/<TopicsController>
        /// <summary>
        /// Adds the Topic and related Tweets
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddTopic([FromBody] TopicRequest topic)
        {
            await _topicHandler.AddTopic(topic);
        }

        // DELETE api/<TopicsController>/5
        /// <summary>
        /// Deletes the Topic and related Tweets based on the Topic id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void RemoveTopic(Guid id)
        {
            _topicHandler.RemoveTopic(id);
        }
    }
}