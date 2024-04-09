

using System.Data;

namespace Domain.Comman
{
    public abstract class BaseEntity
    { 
        public int Id { get; set; }
        public  DateTime  createdDate { get; set; }
    }
}
