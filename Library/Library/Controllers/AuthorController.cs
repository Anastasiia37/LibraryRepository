using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.BusinessLogic.DTOs;
using Library.BusinessLogic.Interfaces;
using Library.ViewModels.RequestViewModels;
using Library.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService, ICountryService countryService, IMapper mapper)
        {
            _logger = logger;
            _authorService = authorService;
            _mapper = mapper;
            _countryService = countryService;
        }

        // GET: AuthorController
        public async Task<ActionResult<List<AuthorResponseViewModel>>> AuthorList()
        {
            var authors = await _authorService.GetAll();
            return View(_mapper.Map<List<AuthorResponseViewModel>>(authors));
        }
                
        [HttpGet]
        public async Task<ActionResult> CreateUpdate(int id)
        {
            var author = await _authorService.GetById(id);
            var countries = await _countryService.GetAll();
            ViewBag.CountryList = _mapper.Map<List<CountryResponseViewModel>>(countries);
            
            return View(_mapper.Map<AuthorResponseViewModel>(author));
        }

        [HttpPost] //?
        public async Task<ActionResult> Update(AuthorRequestViewModel author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Update(_mapper.Map<AuthorDTO>(author));
            }

            return RedirectToAction(nameof(CreateUpdate), new { id = author.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Create(AuthorRequestViewModel author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Create(_mapper.Map<AuthorDTO>(author));
            }

            return RedirectToAction(nameof(CreateUpdate), new { id = author.Id });
        }

        // GET: AuthorController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return RedirectToAction(nameof(AuthorList));
        }

        #region additional
        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(AuthorList));
            }
            catch
            {
                return View();
            }
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(AuthorList));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
