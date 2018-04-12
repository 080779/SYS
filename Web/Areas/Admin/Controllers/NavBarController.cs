using Common;
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models.NavBar;

namespace Web.Areas.Admin.Controllers
{
    public class NavBarController : Controller
    {
        public INavBarService navbarService { get; set; }
        public ActionResult Parents()
        {
            var model=navbarService.GetByParentId(0);
            return View(model);
        }
        public ActionResult AddParent(AddParentModel model)
        {
            long id= navbarService.Add(model.MenuId,model.MenuName, model.Url, model.Sort);
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult GetEditParent(long id)
        {
            return Json(new AjaxResult { Status = "1", Data = navbarService.GetById(id) });
        }
        public ActionResult EditParent(EditParentModel model)
        {
            navbarService.Update(model.Id, model.MenuName, model.Url, model.Sort);
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult Children(long menuId)
        {
            ChildrenViewModel model = new ChildrenViewModel();
            model.ParentId = menuId;
            model.NavBars = navbarService.GetByParentId(menuId);
            return View(model);
        }
        public ActionResult AddChild(AddChildModel model)
        {
            navbarService.AddChild(model.MenuName, model.Url, model.Sort, model.ParentId);
            return Json(new AjaxResult { Status = "1" });
        }
    }
}