 



using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopOneApi.Model;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Data.Entity.Validation;
using TopOneApi.Controllers;
using System.Data.Entity.Validation;
#nullable disable

namespace TopOneApi.Controllers
{
    public class Utile
    {

        public DateTime GetDateSystem(TOPONEContext dbContext)
        {
            try
            {

                var test = dbContext
                   .Set<User>()
                   .FromSqlRaw("SELECT '1' AS Code,'1' AS code_article,'1' AS Libelle,convert(numeric(18,0),0)  as Quantite,  GETDATE() AS Date_creation , '' as User_creation , convert(bit,0) as Actif ,'' as  CodeUnite , convert(bit,0) as UtiliseParDefault,'' as Nature,convert(numeric(18,0),0)  as PoidsTotal ")
                   .First();

                return (DateTime)test.DateCreation;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
 

        public static string LogAG(Exception ex)
        {
            #region Exception 
            if (ex.InnerException != null && ex.InnerException.Message.ToUpper().Equals("Csys Group".ToUpper()))
            {
                return ex.Message;
            }
            else
            {
                DbEntityValidationException a = ex as DbEntityValidationException;
                var fullErrorMessage = string.Empty;
                if (a != null)
                {
                    var errorMessages = a.EntityValidationErrors
                         .SelectMany(x => x.ValidationErrors)
                         .Select(x => x.ErrorMessage);
                    fullErrorMessage = string.Join("; ", errorMessages);
                }
                System.Data.SqlClient.SqlException s = ex as System.Data.SqlClient.SqlException;
                if (s != null)
                {
                    for (int j = 0; j < s.Errors.Count; j++)
                    {
                        var errorMessages = "Index #" + j + "\n" +
                          "Message: " + s.Errors[j].Message + "\n" +
                          "LineNumber: " + s.Errors[j].LineNumber + "\n" +
                          "Source: " + s.Errors[j].Source + "\n" +
                          "Procedure: " + s.Errors[j].Procedure + "\n";

                        fullErrorMessage = string.Join("; ", errorMessages);
                    }
                }

                logErreur.trace_erreur(ex);
                return ("Erreur de chargement");
            }
            #endregion
        }
    }
}
