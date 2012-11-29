using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using System.IO;
using System.Reflection;

namespace LearnSSIS.Execution
{
    public class SsisValidation:ILearn
    {
        private Application ssisApplication;
        private static string location;
        private const string packageName = "TestPackageOne.dtsx";
        private const string errorPackageName = "TestPackageError.dtsx";
        private const string packageFolder = "SSISPackage";
        private Package package;
        private string packageXml = string.Empty;
        private DtsErrors errors;
        
        public SsisValidation()
        {
            location = Directory.GetCurrentDirectory();
        }

        #region ILearn Members

        public void Learn()
        {
            string packageLocation = Path.Combine(Path.Combine(location, packageFolder), errorPackageName);

            try
            {
                ssisApplication = new Application();
                package = ssisApplication.LoadPackage(packageLocation, null);



                DTSExecResult result = package.Validate(null, null, null, null);

                //errors = package.Errors;
                //foreach (DtsError dtsError in errors)
                //{
                //    Console.WriteLine(dtsError.Description);
                //    Console.WriteLine(dtsError.Source);
                //    Console.WriteLine(dtsError.ErrorCode);
                //}
                package.Execute();
                errors = package.Errors;
                foreach (DtsError dtsError in errors)
                {
                    Console.WriteLine(dtsError.Description);
                    Console.WriteLine(dtsError.Source);
                    Console.WriteLine(dtsError.ErrorCode);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                package.Dispose();
            }

        }

        internal void IsInternal()
        {
        }

        #endregion
    }
}
