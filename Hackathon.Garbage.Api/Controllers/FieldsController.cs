﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldsRepository _fieldsRepository;

        public FieldsController(
            IFieldsRepository fieldsRepository
            )
        {
            _fieldsRepository = fieldsRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            
            var fields =await _fieldsRepository.GetAll();
            return Ok(fields);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FieldEntity fieldEntity)
        {
            try
            {


                return Ok(_fieldsRepository.CreateOrUpdate(fieldEntity));
            }
            catch (ArgumentException)
            {
                return
                    BadRequest();
            }
        }
    }
}