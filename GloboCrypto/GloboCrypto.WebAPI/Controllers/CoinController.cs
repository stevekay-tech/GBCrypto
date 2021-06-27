﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboCrypto.WebAPI.Services.Coins;
using GloboCrypto.Models.Data;

namespace GloboCrypto.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ICoinService CoinService;

        public CoinController(ICoinService coinService)
        {
            CoinService = coinService;
        }

        [HttpGet("{coinId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CoinInfo>> Get(string coinId)
        {
            var result = await CoinService.GetCoinInfo(coinId);
            if (result is null)
                return NotFound();
            else
                return Ok(result);
        }
    }
}
