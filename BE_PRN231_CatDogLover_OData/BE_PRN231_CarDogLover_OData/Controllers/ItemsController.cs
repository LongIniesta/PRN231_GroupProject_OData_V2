using AutoMapper;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using Repositories.Interface;

namespace BE_PRN231_CarDogLover_OData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ODataController
    {
        private readonly IMapper mapper;
        private IItemRepository itemRepository;
        public ItemsController( IMapper mapper)
        {
            itemRepository = new ItemRepository();
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [EnableQuery]
        public ActionResult<List<ItemDTO>> GetItems()
        {
            List<ItemDTO> result;
            try
            {
                result = mapper.Map<List<ItemDTO>>(itemRepository.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return result;
        }
    }

}
