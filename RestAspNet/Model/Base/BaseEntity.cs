using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }

}
