using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnologyKeeda.Entity;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.StateViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    //To pass data from controller to View we can Use-> 1.Viewbag 2.ViewData 3.TempData
    // Viewbag.Dynamic_Variable - Stores Dynamic Variable -> Works for single http request
    //ViewData["key"]=Value - Store Dictionary Tye Data -> Works for single http request
    //TempData["key"]=Value - Stores Dictionary Data -> Works for two http requests-hv two method - 1.keep(),2.peek()

    public class StatesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var states = await _stateRepo.GetAll();
            var vm = new List<StateViewModel>();
            foreach (var state in states)
            {
                vm.Add(new StateViewModel { Id = state.Id, StateName = state.Name, CountryName = state.Country.Name });
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStateViewModel vm)
        {
            var state = new State
            {
                Name = vm.StateName,
                CountryId = vm.CountryId
            };
            await _stateRepo.Save(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var state = await _stateRepo.GetById(id);
            var vm = new EditStateViewModel
            {
                Id = state.Id,
                StateName = state.Name,
                CountryId = state.CountryId
            };
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStateViewModel vm)
        {
            var state = new State
            {
                Id = vm.Id,
                Name = vm.StateName,
                CountryId = vm.CountryId
            };
            await _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var state = await _stateRepo.GetById(id);
            await _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }
    }
}
