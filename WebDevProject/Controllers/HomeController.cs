﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDevProject.Controllers;
using WebDevProject.Models;
//using WebDevProject.ViewModels;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        private ModelContext _context;
        private IConfigurationRoot _config;

        public HomeController(ModelContext context, IConfigurationRoot config)
        {
            _context = context;
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var moduleInfo = from mod in _context.Module
                              select mod;

            IndexViewModel model = new IndexViewModel();

            IList<Module> modules = null;
            if(moduleInfo != null)
            {
                model.Modules = (from module in moduleInfo
                                 select new Module()
                                 {
                                     moduleTitle = module.moduleTitle,
                                     Id = module.Id
                                 }).ToList();
            }
            return View(model);
        }

        public IActionResult ModuleView(int Id)
        {
            Module module = _context.Module.SingleOrDefault(mod => mod.Id == Id);
            return View(module);
        }

        public IActionResult TopicView()
        {
            return View();
        }

        public IActionResult MultipleChoiceView()
        {
            return View();
        }
    }
}
