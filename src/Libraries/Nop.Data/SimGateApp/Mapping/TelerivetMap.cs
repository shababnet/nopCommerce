using Nop.Core.SimGateApp.Domain.Telerivet;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.SimGateApp.Mapping
{
    public partial class Telerivet_RoutetMap : NopEntityTypeConfiguration<Telerivet_Route>
    {
        public Telerivet_RoutetMap()
        {
            this.ToTable("Telerivet_Route");
            this.HasKey(c => c.Id);
        }
    }




    public partial class Telerivet_MessageMap : NopEntityTypeConfiguration<Telerivet_Message>
    {
        public Telerivet_MessageMap()
        {
            this.ToTable("Telerivet_Message");
            this.HasKey(c => c.Id);
        }
    }



    public partial class Telerivet_ProjectMap : NopEntityTypeConfiguration<Telerivet_Project>
    {
        public Telerivet_ProjectMap()
        {
            this.ToTable("Telerivet_Project");
            this.HasKey(c => c.Id);
        }
    }


    public partial class Telerivet_PhoneMap : NopEntityTypeConfiguration<Telerivet_Phone>
    {
        public Telerivet_PhoneMap()
        {
            this.ToTable("Telerivet_Phone");
            this.HasKey(c => c.Id);
        }
    }


    public partial class Telerivet_GroupMap : NopEntityTypeConfiguration<Telerivet_Group>
    {
        public Telerivet_GroupMap()
        {
            this.ToTable("Telerivet_Group");
            this.HasKey(c => c.Id);
        }
    }


    public partial class Telerivet_ContactMap : NopEntityTypeConfiguration<Telerivet_Contact>
    {
        public Telerivet_ContactMap()
        {
            this.ToTable("Telerivet_Contact");
            this.HasKey(c => c.Id);
        }
    }




    public partial class Telerivet_Messages_By_DayMap : NopEntityTypeConfiguration<Telerivet_Messages_By_Day>
    {
        public Telerivet_Messages_By_DayMap()
        {
            this.ToTable("Telerivet_Messages_By_Day");
            this.HasKey(c => c.Id);
            // Property(c => c.ProjectId).HasColumnAnnotation("index", new IndexAnnotation(new IndexAttribute("IX_ProjectId") { IsUnique = false }));
        }
    }

}
