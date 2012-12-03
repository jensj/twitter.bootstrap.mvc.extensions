using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcApplication_EricHexter_Bootstrap.Models
{
    public class HomeInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Country { get; set; }

        [DataType(DataType.Url)]
        public string Blog { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


    }

    public static class ModelIntializer
    {
        public static List<HomeInputModel> CreateHomeInputModels()
        {
            var list = new List<HomeInputModel>
                       {
                           new HomeInputModel
                               {
                                   Id = 1,
                                   Blog = "http://foobar.com",
                                   Name = "asdf",
                                   Password = "asdfsd",
                                   StartDate = DateTime.Now.AddYears(1)
                               },
                           new HomeInputModel
                               {
                                   Id = 2,
                                   Blog = "http://foobar.com",
                                   Name = "fffff",
                                   Password = "dddddddasdfsd",
                                   StartDate = DateTime.Now.AddYears(2)
                               },
                       };


            for (int i = 0; i < 120; i++)
            {
                list.Add(new HomeInputModel(){Id = 2+i,Blog = "http://",Password = "pwd"+i,StartDate = DateTime.Now});
            }

            return list;
        }
    }

    public static class ModelExtention
    {
        public static HomeInputModel Get(this List<HomeInputModel> models, int id)
        {
            return models.First(x => x.Id == id);
        }
    }
}