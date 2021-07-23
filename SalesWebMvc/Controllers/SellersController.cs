using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController (SellerService sellerService, DepartmentService departmentService)//injeção de dependencia
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();//retorna a lista de seller
            return View(list); //list representado por @model na view
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);//quando iniciar a tela, já vem com os departamentos populados
        }
        [HttpPost]//Para identificar que é a requisição post
        [ValidateAntiForgeryToken] //segurança nos submits
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
