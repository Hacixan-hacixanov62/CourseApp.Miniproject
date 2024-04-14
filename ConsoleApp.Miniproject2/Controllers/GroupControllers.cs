using Domain.Models;
using Service.Helpers.Constans;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp.Miniproject2.Controllers
{
    public class GroupControllers
    {
        private readonly IGroupService _groupService;

        public GroupControllers()
        {
            _groupService = new GroupService();

        }

        public async Task CreateAsync()
        {

            ConsoleColor.Magenta.WriteConsole("Add Group name: ");
        Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Name;
            }

            var result = await _groupService.GetAllAsync();
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


            ConsoleColor.Magenta.WriteConsole("Add Group capacity : ");
        Capacity: string capacityStr = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Capacity;
            }

            int capacity;

            if (!int.TryParse(capacityStr, out capacity))
            {
                ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidCapacityFormat + ". Please try again:");
                goto Capacity;
            }

            Domain.Models.Group addedGroup;


            try
            {
                addedGroup = await _groupService.GetByIdAsync(capacity);
            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole("There is no group with specified id. Please try again:");
                goto Capacity;
            }

            try
            {
                if (addedGroup.GroupCount == 5)
                {
                    ConsoleColor.Red.WriteConsole("Group can have maximum 5 students. Please choose another group:");
                    goto Capacity;
                }

                _groupService.Create(new  Group() { Name = name, Capacity = capacity});

                ConsoleColor.Green.WriteConsole("Data successfully added");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

            

            ConsoleColor.Magenta.WriteConsole("Add Group EducationId : ");
       EducationId: string educationStr = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(educationStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto EducationId;
            }

            int educationId;

            if (!int.TryParse(educationStr, out educationId))
            {
                ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidIdFormat + ". Please try again:");
                goto EducationId;
            }
            else if (educationId < 1)
            {
                ConsoleColor.Red.WriteConsole("Id cannot be less than 1. Please try again:");
                goto EducationId;
            }

            //if()



            //    ConsoleColor.Red.WriteConsole("There is no group with specified id. Please try again:");
            //goto EducationId;

        }

        public async Task DeleteAsync()
        {

            ConsoleColor.Cyan.WriteConsole("Add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _groupService.DeleteAsync(id);
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
            var response = await _groupService.GetAllAsync();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Group name : {item.Name}, Group capacity : {item.Capacity}  ";

                Console.WriteLine(data);
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
                var response = await _groupService.SearchAsync(searchText);


                if (response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Name  notfaound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id},Group name : {item.Name}, Group capacity : {item.Capacity} ";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchAsync;
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

                var response = await _groupService.GetByIdAsync(id);

                string data = $"Id: {response.Id}, Education name : {response.Name} , Group capacity : {response.Capacity}";
                Console.WriteLine(data);

            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole(" Id notfound ");
            }
        }

        public async Task FilterByEducationNameAsync()
        {
          
            ConsoleColor.White.WriteConsole("Add Education Id: ");
            string date = Console.ReadLine();

            var educations = await _groupService.FilterByEducationNameAsync(date);
            foreach (var item in educations)
            { 
                Console.WriteLine(item.Name);
            }
        }

        public async Task GetAllWithEducationIdAsync(int id)
        {
            ConsoleColor.Cyan.WriteConsole("Add Group education id: ");
        Id: string idStr = Console.ReadLine();
            

            bool isCorrectIdFormat = int.TryParse(idStr, out id);


            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }

            if (isCorrectIdFormat)
            {
                try
                { 

                    List<Domain.Models.Group> response = await  _groupService.GetAllWithEducationIdAsync(id);
                     
                    if (response.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole(" Group educatio Id notfound ");
                        return;

                    }
                    else
                    {

                        foreach (var item in response)
                        {
                            string data = $" Id: {item.Id}, Group name : {item.Name}, Group Capacity : {item.Capacity}, Group EducationId : {item.EducationId}";
                            Console.WriteLine(data);
                        }
                    }


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole(" Group education id notfound , please corect group id");
                goto Id;
            }

        }


        public async Task SortWithCapacityAsync()
        {
            try
            {
                ConsoleColor.Cyan.WriteConsole(" Choose sort capacity: ");
                 string test = Console.ReadLine();
                var datas = await _groupService.SortWithCapacityAsync(test);

                foreach (var data in datas)
                {
                  
                    Console.WriteLine("Name" + data.Name + "CreateDate" + data.Capacity);

                }

            }
            catch(Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

        public async Task UpdateAsync()
        {

        }

    }
}
