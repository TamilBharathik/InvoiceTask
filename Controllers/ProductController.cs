using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backendtask.Repo;
using backendtask.Model;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Dapper.Oracle;
using System.Data;
using Newtonsoft.Json;

namespace backendtask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await this.repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyCode/{ProductID}")]
        public async Task<IActionResult> GetbyCode(int ProductID)
        {
            var _list = await this.repo.Getbycode(ProductID);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }


 [HttpPost("Create")]
    public async Task<IActionResult> Create(Product entry)
    {
        try
        {
            var result = await this.repo.Create(entry);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the product: {ex.Message}");
        }
    }


        [HttpPut("Update/{ProductID}")]
        public async Task<IActionResult> Update([FromBody] Product entry, int ProductID)
        {
            var result = await this.repo.Update(entry, ProductID);
            return Ok(result);
        }

        [HttpDelete("Remove/{ProductID}")]
        public async Task<IActionResult> Remove(int ProductID)
        {
            var result = await this.repo.Remove(ProductID);
            return Ok(result);
        }
    }
}
