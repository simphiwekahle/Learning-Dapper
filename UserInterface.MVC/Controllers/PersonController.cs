using Data.Layer.Models.Domain;
using Data.Layer.Repo;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepo _personRepo;

        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(person);
                }
                bool addPersonResult = await _personRepo.AddAsync(person);
                if (addPersonResult)
                    TempData["msg"] = "Person Added Successfully";
                else
                    TempData["msg"] = "Person Not Added ";

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Person NOT Added";
            }
            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personRepo.GetByIdAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(person);

                bool updateResult = await _personRepo.UpdateAsync(person);
                if(updateResult)
                {
                    TempData["msg"] = "Update Completed";
                    //return RedirectToAction(nameof(DisplayAll));
                }
                else
                {
                    TempData["msg"] = "Update Not Executed";
                    return View(person);
                }
                
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Update Not Executed";
            }
            return View(person);
        }

        //public async Task<IActionResult> GetById(int id)
        //{
        //    return View();
        //}

        public async Task<IActionResult> DisplayAll()
        {
            var people = await _personRepo.GetAllAsync();
            return View(people);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _personRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
