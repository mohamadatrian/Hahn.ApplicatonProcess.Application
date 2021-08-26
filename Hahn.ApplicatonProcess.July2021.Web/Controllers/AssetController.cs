using Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Command.AddAsset;
using Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAllAssets;
using Hahn.ApplicatonProcess.July2021.Domain.Features.Asset.Query.GetAssetById;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Web.SwaggerExamples;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AssetController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AssetModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssetModel>>> Get()
        {
            var assets = await _mediator.Send(new GetAllAssetsQuery());
            return Ok(assets);
        }

        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AssetModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AssetModel>> Get(string id)
        {
            var asset = await _mediator.Send(new GetAssetByIdQuery(id));
            return Ok(asset);
        }

        // POST api/<AssetController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerRequestExample(typeof(AddUserAssetCommand), typeof(AddUserAssetCommandExample))]
        public async Task<ActionResult<AssetModel>> Post([FromBody] AddUserAssetCommand command)
        {
            var assetId = await _mediator.Send(command);
            return CreatedAtAction("Get", new { controller = "User", id = command.UserId }, assetId);
        }

        //// PUT api/<AssetController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AssetController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
