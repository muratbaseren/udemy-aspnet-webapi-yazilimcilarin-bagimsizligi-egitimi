using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UdemyWebApiEgitimi.JqueryKullanmi;

namespace UdemyWebApiEgitimi.JqueryKullanimi.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities db = new EmployeeDBEntities();


        public HttpResponseMessage Get(string gender = "all", int? top = 0)
        {
            IQueryable<Employee> query = db.Employees;

            gender = gender.ToLower();

            switch (gender)
            {
                case "all":
                    break;
                case "male":
                case "female":
                    query = query.Where(e => e.Gender.ToLower() == gender);
                    break;
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"{gender} is not a valid gender. Please use all,male or female.");
            }

            if (top > 0)
            {
                query = query.Take(top.Value);
            }

            return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
        }


        public HttpResponseMessage Get(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan çalışan bulunamadı.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }


        public HttpResponseMessage Post(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);

                if (db.SaveChanges() > 0)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employee.Id);

                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri ekleme işlemi yapılamadı.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Put([FromBody]int id, [FromUri]Employee employee)
        {
            try
            {
                Employee emp = db.Employees.FirstOrDefault(e => e.Id == id);

                if (emp == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Id : " + employee.Id);
                }
                else
                {
                    emp.Name = employee.Name;
                    emp.Surname = employee.Surname;
                    emp.Salary = employee.Salary;
                    emp.Gender = employee.Gender;

                    if (db.SaveChanges() > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Güncelleme yapılamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Employee emp = db.Employees.FirstOrDefault(e => e.Id == id);

                if (emp == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Id : " + id);
                }
                else
                {
                    db.Employees.Remove(emp);

                    if (db.SaveChanges() > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Employee id : " + id);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Kayıt Silinemedi. Employee ID : " + id);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }

    public class MyBodyType
    {
        public int id { get; set; }
        public string second { get; set; }
    }
}
