using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Core.Events;
using Nop.Core.SimGateApp.Domain.Telerivet;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.SimGateApp.Telerivet
{
    public partial class Telerivet_RouteService : ITelerivet_RouteService
    {
        private readonly IRepository<Telerivet_Route> _itemRepository;
        public Telerivet_RouteService(IRepository<Telerivet_Route> itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public void Delete(Telerivet_Route item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Route> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Route> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Route GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Route GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Route item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Route item)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Telerivet_MessageService : ITelerivet_MessageService
    {
        private readonly IRepository<Telerivet_Message> _itemRepository;
        public Telerivet_MessageService(IRepository<Telerivet_Message> itemRepository)
        {
            this._itemRepository = itemRepository;
        }
        public void Delete(Telerivet_Message item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Message> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Message> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Message GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Message item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Message item)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Telerivet_ProjectService : ITelerivet_ProjectService
    {

        private readonly IRepository<Telerivet_Project> _itemRepository;
        public Telerivet_ProjectService(IRepository<Telerivet_Project> itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public void Delete(Telerivet_Project item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Project> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _itemRepository.Table;
            var items = new PagedList<Telerivet_Project>(query, pageIndex, pageSize);
            return items;

        }

        public IList<Telerivet_Project> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Project GetById(int id)
        {
            if (id == 0)
                return null;

            return _itemRepository.GetById(id);
        }

        public Telerivet_Project GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Project item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Project item)
        {
            throw new NotImplementedException();
        }



        public void InsertOrUpdate(Telerivet_Project item)
        {

            var query = _itemRepository.Table;

            Telerivet_Project dataBaseItem = query.Where(m => m.TelerivetID == item.TelerivetID).SingleOrDefault<Telerivet_Project>();
            if (dataBaseItem == null)
            {
                _itemRepository.Insert(item);

            }
            else
            {
                dataBaseItem.Contacts = item.Contacts;
                dataBaseItem.DataTables = item.DataTables;
                dataBaseItem.Groups = item.Groups;
                dataBaseItem.Labels = item.Labels;
                dataBaseItem.Messages = item.Messages;
                dataBaseItem.Name = item.Name;
                dataBaseItem.Phones = item.Phones;
                dataBaseItem.Receipts = item.Receipts;
                dataBaseItem.Routes = item.Routes;
                dataBaseItem.ScheduledMessages = item.ScheduledMessages;
                dataBaseItem.Services = item.Services;
                dataBaseItem.TimezoneId = item.TimezoneId;
                dataBaseItem.UserID = item.UserID;
                _itemRepository.Update(dataBaseItem);
            }

            // query.Where(m => m. == item.ProjectId  && i.Year == item.Year  i.Month == item.Month && i.Day == item.Day);
        }

    }

    public partial class Telerivet_PhoneService : ITelerivet_PhoneService
    {

        private readonly IRepository<Telerivet_Phone> _itemRepository;
        public Telerivet_PhoneService(IRepository<Telerivet_Phone> itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public void Delete(Telerivet_Phone item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Phone> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Phone> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Phone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Phone GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Phone item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Phone item)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Telerivet_GroupService : ITelerivet_GroupService
    {

        private readonly IRepository<Telerivet_Group> _itemRepository;
        public Telerivet_GroupService(IRepository<Telerivet_Group> itemRepository)
        {
            this._itemRepository = itemRepository;
        }


        public void Delete(Telerivet_Group item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Group> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Group> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Group GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Group item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Group item)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Telerivet_ContactService : ITelerivet_ContactService
    {

        private readonly IRepository<Telerivet_Contact> _itemRepository;
        public Telerivet_ContactService(IRepository<Telerivet_Contact> itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public void Delete(Telerivet_Contact item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Contact> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Contact> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Contact GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Contact item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Contact item)
        {
            throw new NotImplementedException();
        }
    }



    public partial class Telerivet_Messages_By_DayService : ITelerivet_Messages_By_DayService
    {
        private readonly IRepository<Telerivet_Messages_By_Day> _itemRepository;
        public Telerivet_Messages_By_DayService(IRepository<Telerivet_Messages_By_Day> itemRepository)
        {
            this._itemRepository = itemRepository;
        }
        public void Delete(Telerivet_Messages_By_Day item)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Telerivet_Messages_By_Day> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Telerivet_Messages_By_Day> GetAllByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Messages_By_Day GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Telerivet_Messages_By_Day GetByTelerivetID(string telerivetID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Telerivet_Messages_By_Day item)
        {
            throw new NotImplementedException();
        }

        public void Update(Telerivet_Messages_By_Day item)
        {
            throw new NotImplementedException();
        }


        public void InsertOrUpdate(Telerivet_Messages_By_Day item)
        {

            var query = _itemRepository.Table;

            Telerivet_Messages_By_Day dataBaseItem = query.Where(m => m.ProjectId == item.ProjectId && m.Year == item.Year && m.Month == item.Month && m.Day == item.Day).SingleOrDefault<Telerivet_Messages_By_Day>();
            if (dataBaseItem == null)
            {
                _itemRepository.Insert(item);

            }
            else
            {
                dataBaseItem.Incoming = item.Incoming;
                dataBaseItem.Outgoing = item.Outgoing;
                dataBaseItem.Total = item.Total;
                _itemRepository.Update(dataBaseItem);
            }

            // query.Where(m => m. == item.ProjectId  && i.Year == item.Year  i.Month == item.Month && i.Day == item.Day);
        }

        public IList<Telerivet_Messages_By_Day> GetCountByProjectId(string projectId, int count)
        {
            var query = _itemRepository.Table;
            query = query.Where(m => m.ProjectId == projectId);
            query = query.OrderByDescending(m => m.TimeCreated).Take(count);

            return query.ToList();

        }
    }

}
