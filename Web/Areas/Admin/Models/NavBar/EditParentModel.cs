﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models.NavBar
{
    public class EditParentModel
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public long Sort { get; set; }
    }
}