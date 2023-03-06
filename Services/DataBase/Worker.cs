using DeriDeveloperWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeriDeveloperWebApp.Services.DataBase
{
    public class Worker
    {
        internal static void RestartDataBase()
        {
            using (var db = new DBConnection())
            {
                db.RestartDataBase();
            }


        }

        internal static Soft[]? GetSofts(int skipQuantity = 0)
        {
            try
            {
                using(var db  =  new DBConnection())
                {
                   return db.Softs.Skip(skipQuantity).Take(DataBase.Config.CountSoftsToReturn).ToArray();
                }
            }
            catch (Exception error)
            {
                DeriLibrary.Console.Worker.NotifyErrorMessageCall(error);
                return null;
            }
        }

		internal static async void FillDefaultData()
		{
            try
            {
                using(var db = new DBConnection())
                {
                    List<Soft> softs = new List<Soft>()
                    {
                        new Soft(){
                            Name = "Windows 10 Pro 64 bit",
                            Description = "С инструкцией и вспомогательными инструментами",
                            PathProgram = "C://"
                        }
                    };


                    db.Softs.AddRange(softs);
                    await db.SaveChangesAsync();

                }
            }
            catch(Exception error)
            {
                DeriLibrary.Console.Worker.NotifyErrorMessageCall(error);
            }
		}
	}
}
