using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using DinkToPdf;

namespace Contracts
{
    public interface IPdfService
    {
        GlobalSettings GetGlobalSettings();

        Task<ObjectSettings> GetObjectSettings(Diet dietEntity);
        Task<string> GenerateDietPdf(Diet die);
    }
}