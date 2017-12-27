using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Cmis.Infrastructure;
using RufaPoint.Cmis.Infrastructure.Services;
using RufaPoint.Cmis.Interface.Converter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Extensions;

namespace RufaPoint.CmisServer.Controllers
{
    [Route("api/[controller]")]
    public class CmisAtomServiceController : Controller
    {
        #region Fields

        /// <summary>
        /// The CMIS repository service instance.
        /// </summary>
        readonly ICmisRepositoryService _repositoryService;

        /// <summary>
        /// The AtomPub service converter.
        /// </summary>
        readonly AtomServiceXDocumentConverter _serviceConverter;

        /// <summary>
        /// The logger.
        /// </summary>
        readonly ILogger<CmisAtomServiceController> _logger;

        #endregion
        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Service.CmisAtomServiceController"/> class.
        /// </summary>
        /// <param name="repositoryService">CMIS repository service instance.</param>
        public CmisAtomServiceController(ICmisRepositoryService repositoryService, ILogger<CmisAtomServiceController> logger)
        {
            _repositoryService = repositoryService;
            _serviceConverter = new AtomServiceXDocumentConverter();
            _logger = logger;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the list of repositories.
        /// </summary>
        /// <returns>AtomPub service document containing the repositories list.</returns>
        [HttpGet("api/cmis/1.1/atom")]
        public async Task<IActionResult> GetRepositories()
        {
            SetServiceRoot();

            var result = await _repositoryService.GetServiceDocumentAsync();
            return new XmlResult(_serviceConverter.Convert(result)/*, Constants.CmisMediaTypeService*/);
        }

        /// <summary>
        /// Gets the repository info for a specific CMIS repository.
        /// </summary>
        /// <returns>AtomPub service document containing repository informations for a specific repository.</returns>
        /// <param name="repositoryId">Repository identifier.</param>
        [HttpGet("api/{repositoryId}/cmis/1.1/atom")]
        public async Task<IActionResult> GetRepository(string repositoryId)
        {
            SetServiceRoot();
            var result = await _repositoryService.GetServiceDocumentAsync(repositoryId);
            return new XmlResult(_serviceConverter.Convert(result)/*, Constants.CmisMediaTypeService*/);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the service root URI.
        /// </summary>
        void SetServiceRoot()
        {
            var serviceRoot = $"{Request.Scheme}://{Request.Host}";
            _repositoryService.ServiceRoot = serviceRoot;
        }

        #endregion



        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
