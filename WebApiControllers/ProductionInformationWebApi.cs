using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product_Inventory_Management_System.Interface;
using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.WebApiControllers
{
    public class ProductionInformationWebApi : Controller
    {
        private readonly IProductInformationService productInformationService;
        private readonly IValidator<ProductInformation> validator;

        public ProductionInformationWebApi(IProductInformationService productInformationService, IValidator<ProductInformation> validator)
        {
            this.productInformationService = productInformationService;
            this.validator = validator;

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
            this.productInformationService.Add(model);
            return this.Ok(model);
        }

        [HttpPut]
        public IActionResult Update(int key, string values) 
        {
            var model = this.productInformationService.GetById(key);
            JsonConvert.PopulateObject(values, model);
            this.productInformationService.Update(model);

            return this.Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int key) 
        {
            var model = this.productInformationService.GetById(key);
            this.productInformationService.Delete(key);
            return this.Ok();
        }
    }
}
