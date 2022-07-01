using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        //Namespace ve sınıf adını karşılar
        public string FullName { get; set; } 

        //Class daki metodun adını karşılar
        public string MethodName { get; set; }

        //Metodun parametrelerini karşılar
        public List<LogParameter> Parameters { get; set; }
    }
}
