
using Microsoft.EntityFrameworkCore.Storage;
using Service.Helpers.Constans;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ConsoleApp.Miniproject2.Controllers
{
    public class EducationControllers
    {
        private readonly IEducationService _educationService;

        public EducationControllers()
        {
            _educationService = new EducationService();
        }

        public async Task CreateAsync()
        {

            ConsoleColor.Magenta.WriteConsole("Add Education name: ");
        Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Name;
            }

            var result = await _educationService.GetAllAsync();
            if(result.Any(m=>m.Name == name))
            {
                ConsoleColor.Red.WriteConsole("Please add new name ");
                goto Name;
            }

            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Name;
            }

            if (name.Length < 3)
            {
                ConsoleColor.Red.WriteConsole(" Name or Surname must not be less than three letters ");
                goto Name;
            }

              ConsoleColor.Magenta.WriteConsole("Add Education color: ");
           Color: string color= Console.ReadLine();


            if (string.IsNullOrWhiteSpace(color))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Color;
            }

            var response = await _educationService.GetAllAsync();
            if (response.Any(m => m.Color == color))
            {
                ConsoleColor.Red.WriteConsole("Please add new color ");
                goto Color;
            }
            else
            {
                try
                {

                    await _educationService.CreateAsync(new Domain.Models.Education { Name = name.Trim(), Color = color.Trim() });
                    ConsoleColor.Green.WriteConsole("Data successfully added");

                }
                catch(Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Color;
                }
            }



        }

        public async Task DeleteAsync()
        {


            ConsoleColor.Cyan.WriteConsole("Add education id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                       _educationService.DeleteAsync(id);

                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }

        }

        public async Task GetAllAsync()
        {
            var response = await _educationService.GetAllAsync();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Education name : {item.Name}, Education color : {item.Color}  ";

                Console.WriteLine(data);
            }
        }

        public async Task GetAllWithGroupsAsync()
        {
            try
            {
                var educations = await _educationService.GetAllWithGroupsAsync();

                if(educations.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                }
                foreach(var item  in educations)
                {
                    string result = $"Name : {item.Name}, Groups : {string.Join(", ", item.Groups)}";
                    Console.WriteLine(result);
                }
            }
            catch(Exception ex) 
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

        public async Task GetByIdAsync()
        {
            ConsoleColor.Cyan.WriteConsole("Add Id: ");
        Id: string idStr = Console.ReadLine();
            int id;

            bool isCorrectIdFormat = int.TryParse(idStr, out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }
            try
            {

                var response = await _educationService.GetByIdAsync(id);

                string data = $"Id: {response.Id}, Education name : {response.Name} , Education color : {response.Color} ";
                Console.WriteLine(data);

            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole(" Id notfound ");
            }
        }


        public async Task SearchAsync()

        {

        SearchAsync: ConsoleColor.Cyan.WriteConsole("Add search text: ");

        Name: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto SearchAsync;
            }
            try
            {
                var response = await _educationService.SearchAsync(searchText);


                if (response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Name  notfaound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id},Education name : {item.Name}, Education color : {item.Color} ";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchAsync;
            }

        }

        public async Task SortWithCreatedDateAsync()
        {
            ConsoleColor.DarkCyan.WriteConsole("Enter Name of the student you want to delete: (Press Enter to cancel)");
        Name: string sortName = Console.ReadLine();

            if (sortName == "asc" || sortName == "desc")
            {
                


            }



        }




        public async Task UpdateAsync()
        {
        //    if (_educationService.GetAllAsync().Count == 0)
        //    {
        //        ConsoleColor.Red.WriteConsole("There is not any group. Please create one");
        //        return;
        //    }

        //    Console.WriteLine();
        //    ConsoleColor.Yellow.WriteConsole("Groups:");
        //    _educationService.GetAllAsync();

        //    ConsoleColor.Yellow.WriteConsole("Enter id of the group you want to update: (Press Enter to cancel)");
        //Id: string idStr = Console.ReadLine();

        //    if (string.IsNullOrWhiteSpace(idStr))
        //    {
        //        return;
        //    }

        //    int id;

        //    if (!int.TryParse(idStr, out id))
        //    {
        //        ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidIdFormat + ". Please try again:");
        //        goto Id;
        //    }
        //    else
        //    {
        //        if (id < 1)
        //        {
        //            ConsoleColor.Red.WriteConsole("Id cannot be less than 1. Please try again:");
        //            goto Id;
        //        }

        //        if (!_educationService.GetAll().Any(m => m.Id == id))
        //        {
        //            ConsoleColor.Red.WriteConsole(ResponseMessages.DataNotFound);
        //            return;
        //        }

        //        ConsoleColor.Yellow.WriteConsole("Enter name (Press Enter if you don't want to change):");
        //        string updatedName = Console.ReadLine().Trim();

        //        ConsoleColor.Yellow.WriteConsole("Enter teacher name of this group (Press Enter if you don't want to change):");
        //    Teacher: string updatedTeacher = Console.ReadLine().Trim();

        //        if (!string.IsNullOrEmpty(updatedTeacher))
        //        {
        //            if (!Regex.IsMatch(updatedTeacher, @"^[\p{L}]+(?:\s[\p{L}]+)?$"))
        //            {
        //                ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidNameFormat);
        //                goto Teacher;
        //            }
        //        }

        //        ConsoleColor.Yellow.WriteConsole("Enter room name of this group (Press Enter if you don't want to change):");
        //        string updatedRoom = Console.ReadLine().Trim();

        //        try
        //        {
        //            _educationService.Update(new() { Id = id, Name = updatedName, Teacher = updatedTeacher, Room = updatedRoom });

        //            ConsoleColor.Green.WriteConsole(ResponseMessages.UpdateSuccess);
        //        }
        //        catch (Exception ex)
        //        {
        //            ConsoleColor.Red.WriteConsole(ex.Message);
        //        }
        //    }


        }
    
    
    }
}