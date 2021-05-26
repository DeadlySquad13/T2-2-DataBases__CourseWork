using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace HappyPocket.DataModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Custom collection that stores instances of FamilyMember assigned to this Role.
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
        public Role()
        {
            FamilyMembers = new ObservableCollection<FamilyMember>();
        }
    }
}
