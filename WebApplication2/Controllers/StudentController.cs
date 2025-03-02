using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private string Url = "https://localhost:7128/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(Url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);

                if(data != null )
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data , Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(Url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added..";
                return RedirectToAction("index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();    
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if(data != null )
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(Url+ student.studentId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student updated..";
                return RedirectToAction("index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost , ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
           
            HttpResponseMessage response = client.DeleteAsync(Url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_message"] = "Student Deleted..";
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
