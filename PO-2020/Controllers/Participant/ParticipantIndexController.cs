﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Participant
{
    public class ParticipantIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}