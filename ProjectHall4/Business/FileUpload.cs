﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectHall4.Models;

namespace ProjectHall4.Business
{
    public class FileUpload
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void UploadFile(FileUploadVm model)
        {
            FileUploadModel fileUpload = new FileUploadModel();
            byte[] uploadFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);
            fileUpload.FileName = model.File.FileName;
            fileUpload.File = uploadFile;
            UploadFileToDb(fileUpload);
        }
        private void UploadFileToDb(FileUploadModel fileUpload)
        {
            db.fileUploadModel.Add(fileUpload);
            db.SaveChanges();
        }
        public FileUploadModel SearchFile(int? id)
        {
            FileUploadModel fileRecord = db.fileUploadModel.Find(id);
            return fileRecord;
        }
        public string fileName(FileUploadModel fileRecord)
        {
            return fileRecord.FileName;
        }
        public byte[] fileData(FileUploadModel fileData)
        {
            return (byte[])fileData.File.ToArray();
        }
    }
}