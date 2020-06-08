using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IPdfService
    {
        Task<string> GenerateDietPdf(Diet die);
    }
}