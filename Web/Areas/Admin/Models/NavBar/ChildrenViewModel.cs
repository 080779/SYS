﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models.NavBar
{
    public class ChildrenViewModel
    {
        public NavBarDTO[] NavBars { get; set; }
        public long ParentId { get; set; }
    }
}