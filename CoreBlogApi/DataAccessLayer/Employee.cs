using System.ComponentModel.DataAnnotations;

namespace CoreBlogApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
    }
}
