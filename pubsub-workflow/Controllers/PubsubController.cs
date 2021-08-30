// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PubsubWorkflow
{
    [ApiController]
    public class PubsubController : ControllerBase
    {
        internal static DateTime lastRapidCall = DateTime.Now;
        internal static DateTime lastMediumCall = DateTime.Now;
        internal static DateTime lastSlowCall = DateTime.Now;

        [Topic("longhaul-sb", "rapidtopic")]
        [HttpPost("rapidMessage")]
        public IActionResult RapidMessageHandler() {
            var lastHit = lastRapidCall;
            lastRapidCall = DateTime.Now;
            Console.WriteLine($"Rapid subscription hit at {lastRapidCall}, previous hit at {lastHit}");
            return Ok();
        }

        [Topic("longhaul-sb", "mediumtopic")]
        [HttpPost("mediumMessage")]
        public IActionResult MediumMessageHandler() {
            var lastHit = lastMediumCall;
            lastMediumCall = DateTime.Now;
            Console.WriteLine($"Medium subscription hit at {lastMediumCall}, previous hit at {lastHit}");
            return Ok();
        }

        [Topic("longhaul-sb", "slowtopic")]
        [HttpPost("slowMessage")]
        public IActionResult SlowMessageHandler() {
            var lastHit = lastSlowCall;
            lastSlowCall = DateTime.Now;
            Console.WriteLine($"Slow subscription hit at {lastSlowCall}, previous hit at {lastHit}");
            return Ok();
        }
    }
}