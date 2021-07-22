﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController (SellerService sellerService)//injeção de dependencia
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();//retorna a lista de seller
            return View(list); //list representado por @model na view
        }

        public IActionResult Create()
        {
            return View();
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
