using System.ComponentModel.DataAnnotations;

namespace LogiinLogout.Models
{
	public class employee
	{
		[Key]
        public int Id { get; set; }
        public string  employeename { get; set; }
		public string employeemail { get; set; }
		public string employeepassword { get; set; }
	}
}
