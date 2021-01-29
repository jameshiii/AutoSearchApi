using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoSearchApi.Models;
using AutoSearchApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoSearchApi.Controllers
{
    // code generated using dotnet tool aspnet-codegenerator:
    // dotnet aspnet-codegenerator controller -name VehicleController -async -api -m Vehicle -dc VehicleContext -outDir Controllers
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _context;
        private readonly IMapper _mapper;

        public VehicleController(VehicleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Vehicle
        // using "async" action methods allow the handling of thousands of concurrent requests
        // refer to this page for best practices: https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ViewModels.Vehicle>>> GetVehicles(string dealer)
        {
            if (string.Compare("Dealer 1", dealer, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                // ProjectTo<T> creates IQueryable and uses deferred execution which allows these two code segments to remain async. be mindful that there are limits to this refer to automapper documentation
                return await _context
                    .Vehicles
                    .ProjectTo<Dealer1Vehicle>(_mapper.ConfigurationProvider) 
                    .ToListAsync();

            }
            else if (string.Compare("Dealer 2", dealer, System.StringComparison.OrdinalIgnoreCase) == 0)
            {   
                return await _context
                    .Vehicles
                    .ProjectTo<Dealer2Vehicle>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            else
            {
                // TODO: Add some logging
                return BadRequest("Invalid dealer provided in Vehicle request.");
            }
        }
    }
}
