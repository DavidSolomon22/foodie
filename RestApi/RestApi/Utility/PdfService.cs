using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;

namespace RestApi.Utility
{
    public class PdfService: IPdfService
    {
        public string GenerateDietPdf(Diet diet, List<Recipe> recpies)
        {
            return "sth";
        }
    }
}