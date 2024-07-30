using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refit.Demo
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public override string ToString() =>
            string.Join(Environment.NewLine, $"Id: {Id}, Name: {Name}, Email: {Email}");
    }
}
