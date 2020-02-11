using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouse.Models;
using WarehouseBL.Models.DataBase;
using WarehouseBL.Models.Repositories;
using WarehouseBL.Models.View;

namespace Warehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly StaffRepository staffRepository;
        private readonly ProductRepository productRepository;
        private readonly OperationRepository operationRepository;

        public HomeController(StaffRepository staffRepository, ProductRepository productRepository, OperationRepository operationRepository)
        {
            this.staffRepository = staffRepository;
            this.productRepository = productRepository;
            this.operationRepository = operationRepository;
        }

        public IActionResult Index()
        {
            var model = new ViewModel();
            model.staffs = staffRepository.GetAll();
            model.products = productRepository.GetAll();
            model.operations = operationRepository.GetAll();
            return View(model);
        }


        [HttpPost]
        public IActionResult ProductAdd(string Name, string Price, string Description, string DropDownStaff)
        {
            if (DropDownStaff != null)
            {
                Product model = new Product();
                if (Price.All(char.IsDigit) && Name != "")
                {
                    model.Name = Name;
                    model.Price = Int32.Parse(Price);
                    model.Description = Description;
                    model.Status = Product.ProductStatus.Accept;
                    productRepository.Add(model);
                    AddOperations(model, Product.ProductStatus.Accept, Int32.Parse(DropDownStaff));
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeStatus(Product.ProductStatus Status, int ProductId, string DropDownStaff)
        {
            if (DropDownStaff != null)
            {
                AddOperations(productRepository.GetById(ProductId), Status, Int32.Parse(DropDownStaff));
                productRepository.ChangeStatus(productRepository.GetById(ProductId), Status);
                
            }
            return RedirectToAction("Index");
        }

        private void AddOperations(Product product, Product.ProductStatus status, int StuffId)
        {
            Operation model = new Operation();
            model.ProductId = product.ProdictId;
            model.ProductName = product.Name;
            model.OldStatus = product.Status;
            model.NewStatus = status;
            model.StaffId = StuffId;
            model.DateTime = DateTime.UtcNow;
            operationRepository.Add(model);
        }

        public IActionResult Report(string DropDownStatus, DateTime start, DateTime end)
        {
            var model = new ViewModel();
            model.products = productRepository.GetAll();
            model.staffs = staffRepository.GetAll();
            if(DropDownStatus == null)
            {
                DropDownStatus = "All";
            }
            model.Status = DropDownStatus;

            model.operations = operationRepository.GetAll();
            if (start != DateTime.MinValue && end != DateTime.MinValue)
            {
                model.operations = operationRepository.GetAll(start, end);

            }
           
           
            return View(model);
        }




        [HttpPost]
        public IActionResult ReportStatus(string DropDownStatus)
        {
            return RedirectToAction("Report");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
