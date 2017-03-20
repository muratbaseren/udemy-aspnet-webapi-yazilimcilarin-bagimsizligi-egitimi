using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UdemyWebApiEgitimi.Routing.Models;

namespace UdemyWebApiEgitimi.Routing.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        static List<Employee> Employees = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "PersonA" },
            new Employee() { Id = 2, Name = "PersonB" },
            new Employee() { Id = 3, Name = "PersonC" }
        };

        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return Employees;
        }



        [Route("detail/{id:decimal=2}")]
        public Employee Get(decimal id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }


        [Route("{id:int:range(1,5)}", Name = "GetById")]
        public Employee Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        [Route("{name:alpha:lastletter}")]
        public Employee Get(string name)
        {
            return Employees.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }

        [Route("add")]
        public HttpResponseMessage Post(Employee emp)
        {
            emp.Id = Employees.Max(x => x.Id) + 1;
            Employees.Add(emp);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri("/api/employee/" + emp.Id.ToString());
            //response.Headers.Location = new Uri(Request.RequestUri + "/" + emp.Id.ToString());
            response.Headers.Location = new Uri(Url.Link("GetById", new { id = emp.Id }));

            return response;
        }



        [Route("{id}/tasks")]
        public IEnumerable<string> GetEmployeeTasks(int id)
        {
            switch (id)
            {
                case 1:
                    return new List<string> { "Task 1-1", "Task 1-2", "Task 1-3" };
                case 2:
                    return new List<string> { "Task 2-1", "Task 2-2", "Task 2-3" };
                case 3:
                    return new List<string> { "Task 3-1", "Task 3-2", "Task 3-3" };
                default:
                    return null;
            }
        }

        [Route("~/api/tasks")]
        public IEnumerable<string> GetTasks()
        {
            return new List<string> { "Task 1-1", "Task 1-2", "Task 1-3", "Task 2-1", "Task 2-2", "Task 2-3", "Task 3-1", "Task 3-2", "Task 3-3" };
        }
    }
}
