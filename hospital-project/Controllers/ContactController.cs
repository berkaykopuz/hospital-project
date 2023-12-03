using hospital_project.Interfaces;
using hospital_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;


public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;
    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }



    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        if(!ModelState.IsValid)
        {
            return View(contact);

        }
        _contactRepository.Add(contact);
        return RedirectToAction("Index");
    }

}
