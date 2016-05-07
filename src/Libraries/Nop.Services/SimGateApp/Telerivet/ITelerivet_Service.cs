using Nop.Core;
using Nop.Core.SimGateApp.Domain.Telerivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.SimGateApp.Telerivet
{
    public partial interface ITelerivet_RouteService
    {
        IPagedList<Telerivet_Route> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Route> GetAllByProjectId(string projectId);

        Telerivet_Route GetById(int id);

        Telerivet_Route GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Route item);

        void Update(Telerivet_Route item);

        void Delete(Telerivet_Route item);

    }

    public partial interface ITelerivet_MessageService
    {
        IPagedList<Telerivet_Message> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Message> GetAllByProjectId(string projectId);

        Telerivet_Message GetById(int id);

        Telerivet_Message GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Message item);

        void Update(Telerivet_Message item);

        void Delete(Telerivet_Message item);
    }

    public partial interface ITelerivet_ProjectService
    {
        IPagedList<Telerivet_Project> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Project> GetAllByProjectId(string projectId);

        Telerivet_Project GetById(int id);

        Telerivet_Project GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Project item);

        void Update(Telerivet_Project item);

        void Delete(Telerivet_Project item);
    }

    public partial interface ITelerivet_PhoneService
    {
        IPagedList<Telerivet_Phone> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Phone> GetAllByProjectId(string projectId);

        Telerivet_Phone GetById(int id);

        Telerivet_Phone GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Phone item);

        void Update(Telerivet_Phone item);

        void Delete(Telerivet_Phone item);
    }

    public partial interface ITelerivet_GroupService
    {
        IPagedList<Telerivet_Group> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Group> GetAllByProjectId(string projectId);

        Telerivet_Group GetById(int id);

        Telerivet_Group GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Group item);

        void Update(Telerivet_Group item);

        void Delete(Telerivet_Group item);
    }

    public partial interface ITelerivet_ContactService
    {
        IPagedList<Telerivet_Contact> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Contact> GetAllByProjectId(string projectId);

        Telerivet_Contact GetById(int id);

        Telerivet_Contact GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Contact item);

        void Update(Telerivet_Contact item);

        void Delete(Telerivet_Contact item);
    }



    public partial interface ITelerivet_Messages_By_DayService
    {
        IPagedList<Telerivet_Messages_By_Day> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<Telerivet_Messages_By_Day> GetAllByProjectId(string projectId);

        Telerivet_Messages_By_Day GetById(int id);

        Telerivet_Messages_By_Day GetByTelerivetID(string telerivetID);

        void Insert(Telerivet_Messages_By_Day item);

        void Update(Telerivet_Messages_By_Day item);

        void Delete(Telerivet_Messages_By_Day item);

        void InsertOrUpdate(Telerivet_Messages_By_Day item);

        IList<Telerivet_Messages_By_Day> GetCountByProjectId(string projectId, int count);
    }

}
