using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHall4.Business;
using ProjectHall4.Models;

namespace ProjectHall4.Controllers
{
    public class FileUploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: FileUpload
        public ActionResult Index()
        {
            List<FileUploadModel> fileUp = db.fileUploadModel.ToList();
            return View(fileUp);
        }
        public ActionResult FileUploadProcess()
        {
            var model = new FileUploadVm();
            return View(model);
        }
        [HttpPost]
        public ActionResult FileUploadProcess(FileUploadVm model, FileUpload fileUploadBusiness)
        {
            fileUploadBusiness.UploadFile(model);
            return RedirectToAction("Index");
        }
        public FileContentResult FileDownload(int? id, FileUpload fileUploadBusiness)
        {
            var file = fileUploadBusiness.SearchFile(id);
            return File(fileUploadBusiness.fileData(file), "text", fileUploadBusiness.fileName(file));
        }
    }
}