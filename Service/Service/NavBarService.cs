using DTO;
using IService;
using Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NavBarService : INavBarService
    {
        public long Add(long menuId, string menuName, string url, long sort)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                NavBarEntity entity = new NavBarEntity();
                entity.MenuId = menuId;
                entity.MenuName = menuName;
                entity.Url = url;
                entity.ParentId = 0;
                entity.Sort = sort;
                dbc.NavBars.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
        public bool Update(long id, string menuName, string url, long sort)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var entity = dbc.GetAll<NavBarEntity>().SingleOrDefault(n=>n.Id==id);
                if(entity==null)
                {
                    return false;
                }
                entity.MenuName = menuName;
                entity.Url = url;
                entity.Sort = sort;
                dbc.SaveChanges();
                return true;
            }
        }
        public long AddChild(string menuName, string url, long sort, long parentId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                NavBarEntity entity = new NavBarEntity();
                entity.MenuId = 0;
                entity.MenuName = menuName;
                entity.Url = url;
                entity.Sort = sort;
                entity.ParentId = parentId;
                dbc.NavBars.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
        public NavBarDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var entity = dbc.GetAll<NavBarEntity>().SingleOrDefault(n => n.Id == id);
                if (entity == null)
                {
                    return null;
                }
                return ToDTO(entity);
            }
        }
        public NavBarDTO[] GetByParentId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var navbars = dbc.GetAll<NavBarEntity>().Where(n=>n.ParentId==id);
                return navbars.OrderBy(n => n.Sort).ToList().Select(n => ToDTO(n)).ToArray();
            }
        }
        private NavBarDTO ToDTO(NavBarEntity entity)
        {
            NavBarDTO dto = new NavBarDTO();
            dto.CreateTime = entity.CreateTime;
            dto.Id = entity.Id;
            dto.MenuName = entity.MenuName;
            dto.ParentId = entity.ParentId;
            dto.Sort = entity.Sort;
            dto.Url = entity.Url;
            dto.MenuId = entity.MenuId;
            dto.IsLock = entity.IsLock;
            return dto;
        }
    }
}
