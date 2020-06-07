using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IPdfService
    {
        string GenerateDietPdf(Diet diet, List<Recipe> recpies);
    }
}