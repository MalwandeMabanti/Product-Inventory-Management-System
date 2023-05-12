using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product_Inventory_Management_System.Interface;
using Product_Inventory_Management_System.Models;
using Product_Inventory_Management_System.Validators;
using System.Diagnostics;

namespace Product_Inventory_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductInformationService productInformationService;
        private readonly IValidator<ProductInformation> validator;

        public HomeController(ILogger<HomeController> logger, IProductInformationService productInformationService, IValidator<ProductInformation> validator)
        {
            _logger = logger;
            this.productInformationService = productInformationService;
            this.validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var productsInformation = this.productInformationService.GetAll();

            return this.Json(DataSourceLoader.Load(productsInformation, loadOptions));

        }

        [HttpPost]
        public IActionResult Create(string values)
        {
            var model = JsonConvert.DeserializeObject<ProductInformation>(values);

            model.ProductId = Id();

            if (model == null)
            {
                this.ModelState.AddModelError("all", "1 one or more properties malformed");
                return this.BadRequest(this.ModelState);
            }

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets());

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return this.BadRequest(this.ModelState);
            }

            this.productInformationService.Add(model);

            return this.Ok(model);
        }

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var model = this.productInformationService.GetById(key);

            JsonConvert.PopulateObject(values, model);

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets());

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return this.BadRequest(this.ModelState);
            }

            this.productInformationService.Update(model);

            return this.Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var model = this.productInformationService.GetById(key);

            this.productInformationService.Delete(model.ProductId);

            return this.Ok();
        }

        private int Id()
        {
            Random random = new Random();
           
            int randomNumber = random.Next(10000000);
            return randomNumber;
        }

    }
}