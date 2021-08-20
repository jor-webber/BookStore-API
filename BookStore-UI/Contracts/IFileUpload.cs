using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_UI.Contracts
{
    interface IFileUpload
    {
        public Task UploadFile(IFileListEntry file, MemoryStream msFile, string picName);
        public void RemoveFile(string picName);
    }
}
