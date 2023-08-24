using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AMS.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class DocumentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _db;


        public DocumentController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                IWebHostEnvironment webHostEnvironment

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public IActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(DocumentM model, ICollection<IFormFile> files)
        {
            // Iterate through each file
            foreach (var file in files)
            {
                // Read the file data into a byte array
                byte[] fileData;
                using (var stream = file.OpenReadStream())
                {
                    fileData = new byte[file.Length];
                    await stream.ReadAsync(fileData, 0, (int)file.Length);
                }

                // Create a new FileModel object
                var fileModel = new DocumentM
                {
                    FileName = file.FileName,
                    Description = model.Description,
                    FileType = file.ContentType,
                    FileData = fileData,
                    isDeleted = "no",
                    DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt")
                };

                // Save the FileModel to the database
                await _db.Documents.AddAsync(fileModel);
                await _db.SaveChangesAsync();

            }

            // Redirect to the file management page
            return RedirectToAction("ListFiles");
        }


        public IActionResult ListFiles()
        {
            var files = _db.Documents.Where(x => x.isDeleted == "no").ToList();
            return View(files);
        }
        public IActionResult Delete(int id)
        {
            var file = _db.Documents.Find(id);
            file.isDeleted = "yes";
            _db.Documents.Update(file);
            _db.SaveChanges();

            return RedirectToAction("ListFiles");
        }
        public IActionResult Download(int id)
        {
            var file = _db.Documents.Find(id);
            return File(file.FileData, file.FileType, file.FileName);
        }

    }
}
