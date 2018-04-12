using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface INavBarService:IServiceSupport
    {
        long Add(long menuId, string menuName,string url,long sort);
        bool Update(long id, string menuName, string url, long sort);
        long AddChild(string menuName, string url, long sort, long parentId);
        NavBarDTO GetById(long id);
        NavBarDTO[] GetByParentId(long id);
    }
}
