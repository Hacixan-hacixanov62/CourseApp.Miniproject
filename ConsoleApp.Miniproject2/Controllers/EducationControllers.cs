
using Domain.Models;
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

        public async Task EducationCreateAsync()
        {

            ConsoleColor.Magenta.WriteConsole("Add Education name: ");
        Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Name;
            }

            var result = await _educationService.GetAllAsync();
            if (result.Any(m => m.Name == name))
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
        Color: string color = Console.ReadLine();


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
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole("There is no group with specified id. Please try again :");
                    goto Color;
                }
            }



        }

        public async Task EducationUpdateAsync()
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    List<Education> educations = await _educationService.GetAllAsync();

                    Console.WriteLine("Exist Educations:");
                    foreach (Education education in educations)
                    {
                        Console.WriteLine($"EducationId: {education.Id}, Name: {education.Name}");
                    }

                    Console.WriteLine("Please write education ID:");

                uId: string idStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(idStr))
                    {
                        ConsoleColor.Red.WriteConsole("ID can't be empty ,please write again.");
                        goto uId;
                    }

                    if (!int.TryParse(idStr, out int id))
                    {
                        ConsoleColor.Red.WriteConsole("Format is wrong, please write correctly.");
                        goto uId;
                    }

                    var existingEducation = await _educationService.GetByIdAsync(id);
                    if (existingEducation == null)
                    {
                        ConsoleColor.Red.WriteConsole("Education not found.");
                        goto uId;
                    }

                    ConsoleColor.Cyan.WriteConsole("Please write new education name:");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        name = existingEducation.Name;
                    }
                    else if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
                    {
                        ConsoleColor.Red.WriteConsole("Input isn't correct, please try again.");
                        continue;
                    }

                    ConsoleColor.Cyan.WriteConsole("Please write new education color:");
                    string color = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(color))
                    {
                        color = existingEducation.Color;
                    }
                    else if (!Regex.IsMatch(color, @"^[\p{L}\p{M}' \.\-]+$"))
                    {
                        ConsoleColor.Red.WriteConsole("Input isn't correct, please try again.");
                        continue;
                    }

                    existingEducation.Name = name;
                    existingEducation.Color = color;

                    DateTime time = DateTime.Now;
                    await _educationService.UpdateAsync(existingEducation);
                    ConsoleColor.Green.WriteConsole("Education successfully updated.");
                    isInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }


        public async Task EducationDeleteAsync()
        {


            ConsoleColor.White.WriteConsole("Add education id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                  await  _educationService.DeleteAsync(id);

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

        public async Task EducationGetAllAsync()
        {
            var response = await _educationService.GetAllAsync();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Education name : {item.Name}, Education color : {item.Color}  ";

                Console.WriteLine(data);
            }
        }

        public async Task EducationGetAllWithGroupsAsync()
        {
            try
            {
                var educations = await _educationService.GetAllWithGroupsAsync();

                if (educations.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                }
                foreach (var item in educations)
                {
                    string result = $"Name : {item.Name}, Groups : {string.Join(", ", item.Groups)}";
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

        public async Task EducationGetByIdAsync()
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


        public async Task EducationSearchAsync()

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

        public async Task<List<Education>> EducationSortWithCreatedDateAsync()
        {
            try
            {
                string sortType;
                do
                {
                    ConsoleColor.White.WriteConsole("Choose sort type: Asc or Desc");
                        sortType = Console.ReadLine();

                    if (sortType.ToLower() != "asc" && sortType.ToLower() != "desc")
                    {
                        ConsoleColor.White.WriteConsole("Please choose sorting type 'Asc' or 'Desc'. ");
                    }

                }
                while (sortType.ToLower() != "asc" && sortType.ToLower() != "desc");

                var educations = await _educationService.SortWithCreatedDateAsync(sortType);

                foreach(var education in educations)
                {
                    Console.WriteLine($"Name: {education.Name}, CreateDate: {education.CreatedDate}");

                }

                return educations ;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Education> { };

            }
        }


    }

}