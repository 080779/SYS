﻿using Common;
using IService;
using Service;
using Service.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models.NavBar;

namespace Web.Areas.Admin.Controllers
{
    public class NavBarController : Controller
    {
        public INavBarService navbarService { get; set; }
        public async Task<ActionResult> Parents()
        {
            //MyDbContext dbc = new MyDbContext();
            //var model= dbc.Database.SqlQuery<NavBarEntity>("select * from t_navbars where isdeleted=0").ToArray();

            var model = await navbarService.GetByParentId(0);
            return View(model);
        }
        public async Task<ActionResult> AddParent(AddParentModel model)
        {
            long id= await navbarService.Add(model.MenuId,model.MenuName, model.Url, model.Sort);
            return Json(new AjaxResult { Status = "1" });
        }
        public async Task<ActionResult> GetEditParent(long id)
        {
            return Json(new AjaxResult { Status = "1", Data = await navbarService.GetById(id) });
        }
        public async Task<ActionResult> EditParent(EditParentModel model)
        {
            await navbarService.Update(model.Id, model.MenuName, model.Url, model.Sort);
            return Json(new AjaxResult { Status = "1" });
        }
        public async Task<ActionResult> Children(long menuId)
        {
            ChildrenViewModel model = new ChildrenViewModel();
            model.ParentId = menuId;
            model.NavBars = await navbarService.GetByParentId(menuId);
            return View(model);
        }
        public async Task<ActionResult> AddChild(AddChildModel model)
        {
            await navbarService.AddChild(model.MenuName, model.Url, model.Sort, model.ParentId);
            return Json(new AjaxResult { Status = "1" });
        }
    }
}