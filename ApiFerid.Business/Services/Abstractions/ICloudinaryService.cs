using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
    public interface ICloudinaryService
    {
        Task<string> FileUploadAsync(IFormFile file);
        Task<bool> FileDeleteAsync(string filePath);
    }
}
